using System.Web;
using Machine.Specifications;
using Rhino.Mocks;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(WebFormViewRegistry))]
    public class WebFormViewRegistrySpecs
    {
        public abstract class concern : Observes<IFindViews,
                                            WebFormViewRegistry>
        {
        }

        public class when_finding_a_view_for_a_model : concern
        {
            public class and_it_has_the_view
            {
                Establish c = () =>
                {
                    the_model = new TheDisplayModel();
                    path_to_page = "blah.aspx";
                    the_expected_view = MockRepository.GenerateStub<IDisplayA<TheDisplayModel>>();
                    view_url_registry = depends.on<IFindPathsToViews>();
                    depends.on<CreatePage_Behaviour>((url,page_type) =>
                    {
                        page_type.ShouldEqual(typeof(IDisplayA<TheDisplayModel>));
                        url.ShouldEqual(path_to_page);
                        return the_expected_view;
                    });

                    view_url_registry.setup(x => x.get_the_url_to_the_view_that_displays<TheDisplayModel>()).Return(path_to_page);
                };

                Because b = () =>
                    result = sut.find_view_that_can_display(the_model);

                It should_populate_the_view_with_its_data = () =>
                    the_expected_view.model.ShouldEqual(the_model);

                    
                It should_return_the_view_that_can_display_the_model = () =>
                    result.ShouldEqual(the_expected_view);

                static IHttpHandler result;
                static IDisplayA<TheDisplayModel> the_expected_view;
                static TheDisplayModel the_model;
                static IFindPathsToViews view_url_registry;
                static string path_to_page;
            }
        }

        public class TheDisplayModel
        {
        }
    }
}