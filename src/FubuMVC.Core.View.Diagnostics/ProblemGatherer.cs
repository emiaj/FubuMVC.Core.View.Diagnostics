using System.Collections.Generic;
using System.Linq;
using Bottles;
using Bottles.Diagnostics;
using FubuCore;
using FubuMVC.Core.Registration;
using FubuMVC.Core.View.Diagnostics.Strings;
using FubuMVC.Core.View.Model;
using FubuMVC.Spark.SparkModel;

namespace FubuMVC.Core.View.Diagnostics
{
    public class ProblemGatherer : IActivator
    {
        private readonly BehaviorGraph _graph;
        private readonly IViewProblemStoreCache _cache;
        private readonly ITemplateRegistry<ITemplate> _sparkTemplates;
        private readonly IParsingRegistrations<ITemplate> _parsings;

        public ProblemGatherer(BehaviorGraph graph, IViewProblemStoreCache cache, ITemplateRegistry<ITemplate> sparkTemplates, IParsingRegistrations<ITemplate> parsings)
        {
            _graph = graph;
            _cache = cache;
            _sparkTemplates = sparkTemplates;
            _parsings = parsings;
        }


        public void Activate(IEnumerable<IPackageInfo> packages, IPackageLog log)
        {
            var items = new List<TemplateBindingItem>();
            foreach (var template in _sparkTemplates.Where(x => x.IsSparkView()).Where(x => !x.IsXml()).Where(x => !x.IsPartial()))
            {
                var declaredViewModel = _parsings.ParsingFor(template).ViewModelType;
                var viewModelType = template.Descriptor.As<ViewDescriptor<ITemplate>>().ViewModel;
                items.Add(new TemplateBindingItem
                    {
                        DeclaredViewModel = declaredViewModel,
                        ViewModelType = viewModelType,
                        ViewPath = template.ViewPath,
                        FilePath = template.FilePath,
                        Origin = template.Origin
                    });
            }

            // Grabbing duplicated view models
            items.Where(x => x.ViewModelType != null)
                .GroupBy(x => x.ViewModelType).Where(x => x.Count() > 1)
                .Each(group =>
                    {
                        var problem = new ViewProblem();
                        problem.Description =
                            "Duplicated View Model Type: {0}, there are {1} views with this problem, this prevents binding them to action endpoints."
                                .ToFormat(group.Key, group.Count());
                        foreach (var item in group)
                        {
                            problem.AddItem(item);
                        }
                        problem.AddWorkaround("One of the views shouldn't exist, remove the one that you find unneeded.");
                        problem.AddWorkaround("One of the views has declared the view model wrong, find which one is the right one.");
                        _cache.Append(problem);
                    });

            // Grabbing views without view models
            var actionOutputModels = _graph.Behaviors
                .Where(x => x.HasResourceType())
                .Select(x => x.ResourceType())
                .Distinct()
                .ToList();

            items.Where(x => x.ViewModelType == null).Where(x => x.DeclaredViewModel.IsNotEmpty())
                .Each(item =>
                    {
                        var problem = new ViewProblem();
                        problem.Description = "Cannot resolve the declared View Model Type from {0}".ToFormat(item.DeclaredViewModel);
                        problem.AddItem(item);
                        actionOutputModels
                            .Select(x => new
                                {
                                    Level = LevenshteinDistance.Compute(item.DeclaredViewModel, x.FullName),
                                    Type = x
                                })
                            .OrderBy(x => x.Level)
                            .Take(3)
                            .Select(x => x.Type)
                            .Each(candidate => problem.AddWorkaround("Set the view model type to: {0}".ToFormat(candidate.FullName)));
                        _cache.Append(problem);
                    });

        }
    }
}