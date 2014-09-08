namespace Cars.XML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cars.Data;
    using Cars.Models;
    using Cars.XML.XmlModels;

    public class XmlQueryBuilder
    {
        private const string ContainsWhereClauseType = "Contains";
        private const string EqualsWhereClauseType = "Equals";
        private const string GreaterThanWhereClause = "GreaterThan";
        private const string LessThanWhereClause = "LessThan";

        private readonly CarsDbContext carsDbContext;
        private readonly XmlQueryWriter xmlQueryWriter;

        public XmlQueryBuilder(CarsDbContext carsDbContext, XmlQueryWriter xmlQueryWriter)
        {
            this.carsDbContext = carsDbContext;
            this.xmlQueryWriter = xmlQueryWriter;
        }

        public void Execute(IList<XmlQuery> xmlQueries)
        {
            foreach (var xmlQuery in xmlQueries)
            {
                IQueryable<Car> carsFromQuery = this.carsDbContext.Cars;

                foreach (var whereClause in xmlQuery.WhereClauses)
                {
                    this.BuildWhereQuery(ref carsFromQuery, whereClause);
                }

                this.BuildOrderQuery(ref carsFromQuery, xmlQuery.OrderByProperty);
                this.xmlQueryWriter.Save(carsFromQuery.ToList(), xmlQuery.OutputFileName);
            }
        }

        private void BuildWhereQuery(ref IQueryable<Car> carsQuery, WhereClause whereClause)
        {
            var whereClauseType = whereClause.Type;
            var whereClauseValue = whereClause.Value;

            switch (whereClause.PropertyName)
            {
                case "City":
                    {
                        if (whereClauseType == EqualsWhereClauseType)
                        {
                            carsQuery = carsQuery.Where(i => i.Dealer.Cities.Any(c => c.Name == whereClauseValue));
                        }

                        break;
                    }

                case "Dealer":
                    {
                        if (whereClauseType == ContainsWhereClauseType)
                        {
                            carsQuery = carsQuery.Where(i => i.Dealer.Name.Contains(whereClauseValue));
                        }
                        else if (whereClauseType == EqualsWhereClauseType)
                        {
                            carsQuery = carsQuery.Where(i => i.Dealer.Name == whereClauseValue);
                        }
                        
                        break;
                    }

                case "Manufacturer":
                    {
                        if (whereClauseType == ContainsWhereClauseType)
                        {
                            carsQuery = carsQuery.Where(i => i.Manufacturer.Name.Contains(whereClauseValue));
                        }
                        else if (whereClauseType == EqualsWhereClauseType)
                        {
                            carsQuery = carsQuery.Where(i => i.Manufacturer.Name == whereClauseValue);
                        }

                        break;
                    }

                case "Model":
                    {
                        if (whereClauseType == ContainsWhereClauseType)
                        {
                            carsQuery = carsQuery.Where(i => i.Model.Contains(whereClauseValue));
                        }
                        else if (whereClauseType == EqualsWhereClauseType)
                        {
                            carsQuery = carsQuery.Where(i => i.Model == whereClauseValue);
                        }

                        break;
                    }

                case "Price":
                    {
                        var valueToDecimal = decimal.Parse(whereClauseValue);

                        if (whereClauseType == GreaterThanWhereClause)
                        {
                            carsQuery = carsQuery.Where(i => i.Price > valueToDecimal);
                        }
                        else if (whereClauseType == LessThanWhereClause)
                        {
                            carsQuery = carsQuery.Where(i => i.Price < valueToDecimal);
                        }
                        else if (whereClauseType == EqualsWhereClauseType)
                        {
                            carsQuery = carsQuery.Where(i => i.Price == valueToDecimal);
                        }
                        
                        break;
                    }

                case "Id":
                    {
                        var valueToInt = int.Parse(whereClauseValue);

                        if (whereClauseType == GreaterThanWhereClause)
                        {
                            carsQuery = carsQuery.Where(i => i.CarId > valueToInt);
                        }
                        else if (whereClauseType == LessThanWhereClause)
                        {
                            carsQuery = carsQuery.Where(i => i.CarId < valueToInt);
                        }
                        else if (whereClauseType == EqualsWhereClauseType)
                        {
                            carsQuery = carsQuery.Where(i => i.CarId == valueToInt);
                        }

                        break;
                    }

                case "Year":
                    {
                        var valueToInt = int.Parse(whereClauseValue);

                        if (whereClauseType == GreaterThanWhereClause)
                        {
                            carsQuery = carsQuery.Where(i => i.Year > valueToInt);
                        }
                        else if (whereClauseType == LessThanWhereClause)
                        {
                            carsQuery = carsQuery.Where(i => i.Year < valueToInt);
                        }
                        else if (whereClauseType == EqualsWhereClauseType)
                        {
                            carsQuery = carsQuery.Where(i => i.Year == valueToInt);
                        }

                        break;
                    }
            }
        }

        private void BuildOrderQuery(ref IQueryable<Car> carsQuery, string orderByProperty)
        {
            switch (orderByProperty)
            {
                case "Id":
                    {
                        carsQuery = carsQuery.OrderBy(c => c.CarId);
                        break;
                    }
                case "Year":
                    {
                        carsQuery = carsQuery.OrderBy(c => c.Year);
                        break;
                    }
                case "Model":
                    {
                        carsQuery = carsQuery.OrderBy(c => c.Model);
                        break;
                    }
                case "Price":
                    {
                        carsQuery = carsQuery.OrderBy(c => c.Price);
                        break;
                    }
                case "Manufacturer":
                    {
                        carsQuery = carsQuery.OrderBy(c => c.Manufacturer.Name);
                        break;
                    }
                case "Dealer":
                    {
                        carsQuery = carsQuery.OrderBy(c => c.Dealer.Name);
                        break;
                    }
            }
        }
    }
}