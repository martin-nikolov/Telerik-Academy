namespace NewsSystem.Web.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using NewsSystem.Web.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsSystem.Web.Models.ApplicationDbContext>
    {
        public static Random Rand = new Random();
        public List<Category> Categories;
        public List<Article> Articles;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "NewsSystem.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(NewsSystem.Web.Models.ApplicationDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            this.Categories = new List<Category>();
            this.Categories.Add(new Category() { Name = "Art" });
            this.Categories.Add(new Category() { Name = "Economy" });
            this.Categories.Add(new Category() { Name = "Technology" });
            this.Categories.Add(new Category() { Name = "Education" });
            this.Categories.Add(new Category() { Name = "Sports" });
            this.Categories.Add(new Category() { Name = "Science" });
            this.Categories.Add(new Category() { Name = "Weather" });

            var user = new ApplicationUser() { UserName = "Anonimous" };

            this.Articles = new List<Article>();

            this.Articles.Add(new Article()
            {
                Category = this.Categories[1],
                Title = "What is Lorem Ipsum?",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&amp;amp;amp;#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                Author = user,
                DateCreated = DateTime.Now.AddDays(Rand.Next(-5, 5))
            });

            this.Articles.Add(new Article()
            {
                Category = this.Categories[1],
                Title = "Why do we use it?",
                Content = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using &amp;amp;amp;#39;Content here, content here&amp;amp;amp;#39;, making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for &amp;amp;amp;#39;lorem ipsum&amp;amp;amp;#39; will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                Author = user,
                DateCreated = DateTime.Now.AddDays(Rand.Next(-5, 5))
            });

            this.Articles.Add(new Article()
            {
                Category = this.Categories[3],
                Title = "Where does it come from?",
                Content = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of &amp;amp;amp;quot;de Finibus Bonorum et Malorum&amp;amp;amp;quot; (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, &amp;amp;amp;quot;Lorem ipsum dolor sit amet..&amp;amp;amp;quot;, comes from a line in section 1.10.32.",
                Author = user,
                DateCreated = DateTime.Now.AddDays(Rand.Next(-5, 5))
            });

            this.Articles.Add(new Article()
            {
                Category = this.Categories[4],
                Title = "Where can I get some more?",
                Content = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don&amp;amp;amp;#39;t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn&amp;amp;amp;#39;t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                Author = user,
                DateCreated = DateTime.Now.AddDays(Rand.Next(-5, 5))
            });

            this.Articles.Add(new Article()
            {
                Category = this.Categories[3],
                Title = "Where can I get some?",
                Content = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don&#39;t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn&#39;t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                Author = user,
                DateCreated = DateTime.Now.AddDays(Rand.Next(-5, 5))
            });

            this.Articles.Add(new Article()
            {
                Category = this.Categories[5],
                Title = "de Finibus Bonorum et Malorum",
                Content = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?",
                Author = user,
                DateCreated = DateTime.Now.AddDays(Rand.Next(-5, 5))
            });

            this.Articles.Add(new Article()
            {
                Category = this.Categories[5],
                Title = "1914 translation by H. Rackham",
                Content = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful. Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain, but because occasionally circumstances occur in which toil and pain can procure him some great pleasure. To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has no annoying consequences, or one who avoids a pain that produces no resultant pleasure?",
                Author = user,
                DateCreated = DateTime.Now.AddDays(Rand.Next(-5, 5))
            });

            foreach (var category in this.Categories)
            {
                context.Categories.Add(category);
            }

            context.Users.Add(user);

            foreach (var article in this.Articles)
            {
                context.Articles.Add(article);
            }

            context.SaveChanges();
        }
    }
}