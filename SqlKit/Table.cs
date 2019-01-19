using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlKit
{
    public enum ConstraintType
    {
        NOT_NULL,
        UNIQUE,
        PRIMARY_KEY,
        FOREIGN_KEY,
        CHECK,
        DEFAULT,
        INDEX
    }

    public class Constraint
    {
        public
        string Name
        { get; set; }
        public ConstraintType Type { get; set; }
    }

    public class ForeignKeyConstraint : Constraint
    {
        public Column ReferencedColumn { get; set; }
    }

    public class DefaultConstraint : Constraint
    {
        public string Value { get; set; }
    }

    public class Column
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Nullable { get; set; }
        public Table Table { get; set; }
        public List<Constraint> Constraints { get; set; }
        public string Definition => $"{Name} {Type}";
    }

    public class Table
    {
        public string Name { get; set; }
        public List<Column> Columns { get; set; }
        public List<Column> PrimaryKey { get; set; }
        public string CreateTableStatement
        {
            get
            {
                return $"CREATE TABLE {Name} ({Columns.Select(c => c.Definition).Aggregate((agg, e) => $"{agg}, {e}")});";
            }
        }
    }
}
