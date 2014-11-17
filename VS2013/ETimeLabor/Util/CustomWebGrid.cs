using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ETimeLabor.Util
{
    public class CustomWebGrid<T> : WebGrid
    {
        public CustomWebGrid(IEnumerable<T> source = null): base(
              source.Cast<object>()
              )
        { }
        public WebGridColumn Column(
                    string columnName = null,
                    string header = null,
                    Func<T, object> format = null,
                    string style = null,
                    bool canSort = true)
        {
            Func<dynamic, object> wrappedFormat = null;
            if (format != null)
            {
                wrappedFormat = o => format((T)o.Value);
            }
            WebGridColumn column = base.Column(
                          columnName, header,
                          wrappedFormat, style, canSort);
            return column;
        }
        public CustomWebGrid<T> Bind(
                IEnumerable<T> source,
                IEnumerable<string> columnNames = null,
                bool autoSortAndPage = true,
                int rowCount = -1)
        {
            base.Bind(
                 source.Cast<object>(),
                 columnNames,
                 autoSortAndPage,
                 rowCount);
            return this;
        }
    }    
}