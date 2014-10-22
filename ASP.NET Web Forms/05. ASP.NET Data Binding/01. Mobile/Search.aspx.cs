namespace Mobile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public partial class Search : Page
    {
        private IList<Producer> producers = SeedProducers();
        private IList<Extra> extras = SeedExtras();
        private IList<string> engineTypes = SeedEngineTypes();

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.ProducersDropDownList.DataSource = this.producers;
                this.ProducersDropDownList.DataBind();

                this.ProducerModelsDropDownList.DataSource = this.producers[0].Models;
                this.ProducerModelsDropDownList.DataBind();

                this.ExtrasCheckBoxList.DataSource = this.extras;
                this.ExtrasCheckBoxList.DataBind();

                this.EnginesRadioButtonList.DataSource = this.engineTypes;
                this.EnginesRadioButtonList.DataBind();
                this.EnginesRadioButtonList.SelectedIndex = 0;
            }
        }

        protected void OnProducerSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProducer = this.producers[this.ProducersDropDownList.SelectedIndex];
            this.ProducerModelsDropDownList.DataSource = selectedProducer.Models;
            this.ProducerModelsDropDownList.DataBind();
        }

        protected void OnSearchButtonClicked(object sender, EventArgs e)
        {
            var selectedProducer = this.ProducersDropDownList.SelectedValue;
            var selectedModel = this.ProducerModelsDropDownList.SelectedValue;
            var selectedExtras = this.ExtrasCheckBoxList.Items
                                     .Cast<ListItem>()
                                     .Where(x => x.Selected)
                                     .Select(x => x.Text);
            var selectedEngine = this.EnginesRadioButtonList.SelectedValue;

            this.SummaryContainer.Controls.Add(new HtmlGenericControl()
            {
                TagName = "p",
                InnerText = "Producer: " + selectedProducer,
            });

            this.SummaryContainer.Controls.Add(new HtmlGenericControl()
            {
                TagName = "p",
                InnerText = "Model: " + selectedModel,
            });

            this.SummaryContainer.Controls.Add(new HtmlGenericControl()
            {
                TagName = "p",
                InnerText = "Extras: " + (selectedExtras.Any() ? string.Join(", ", selectedExtras) : "without extras"),
            });

            this.SummaryContainer.Controls.Add(new HtmlGenericControl()
            {
                TagName = "p",
                InnerText = "Engine: " + selectedEngine,
            });

            this.SummaryContainer.Visible = true;
        }

        private static IList<Producer> SeedProducers()
        {
            var producers = new List<Producer>();

            producers.Add(new Producer()
            {
                Name = "All",
                Models = new List<string>() { "All" }
            });

            producers.Add(new Producer()
            {
                Name = "Bugatti",
                Models = new List<string>() { "Veyron" }
            });

            producers.Add(new Producer()
            {
                Name = "Cadillac",
                Models = new List<string>() { "Allante", "Deville", "Eldorado", "Seville" }
            });

            producers.Add(new Producer()
            {
                Name = "Chevrolet",
                Models = new List<string>() { "Alero", "Astro", "Aveo" }
            });

            producers.Add(new Producer()
            {
                Name = "Aston martin",
                Models = new List<string>() { "DBS", "Db7", "Db9" }
            });

            return producers;
        }

        private static IList<Extra> SeedExtras()
        {
            var extras = new List<Extra>();

            extras.Add(new Extra()
            {
                Name = "Projection display"
            });

            extras.Add(new Extra()
            {
                Name = "Navigation system"
            });

            extras.Add(new Extra()
            {
                Name = "Keyless entry"
            });

            extras.Add(new Extra()
            {
                Name = "Seats and steering wheel memory"
            });

            return extras;
        }

        private static IList<string> SeedEngineTypes()
        {
            var engineTypes = new List<string>()
            {
                "All",
                "Diesel",
                "Petrol",
                "Electrical",
                "Hybrid"
            };

            return engineTypes;
        }
    }
}