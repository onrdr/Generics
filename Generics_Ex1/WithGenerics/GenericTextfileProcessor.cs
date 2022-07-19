using System.Text;

namespace Generics_Ex1.WithGenerics
{
    public static class GenericTextfileProcessor
    {
        public static List<T> LoadFromTextFile<T>(string filePath) where T : class, new()
        {
            var lines = File.ReadAllLines(filePath).ToList();
            List<T> output = new();
            T entry = new();
            var cols = entry.GetType().GetProperties();

            // Checks to be sure we have as least one header row and one data row
            if (lines.Count < 2)
            {
                throw new IndexOutOfRangeException("The file was either empty or missing");
            }

            // Splits the header into one column header per entry
            var headers = lines[0].Split(',');

            // Removes the header row from the lines so we don't have to worry about skipping over that first row
            lines.RemoveAt(0);

            lines.ForEach(row =>
            {
                entry = new T();

                /* Splits the row into individual column. Now the index of this row matches the index of the header 
                 so the FirstName column header lines up with the FirstName value in this row */
                var vals = row.Split(',');

                /* Loops through each header entry so we can compare that against the list of columns from reflection
                   Once we get the matching column, we can do the "setValue" method to set the column value for our entry variable
                   to the vals item at the same index as this particular header */
                for (int i = 0; i < headers.Length; i++)
                {
                    foreach (var col in cols)
                    {
                        if (col.Name == headers[i])
                        {
                            col.SetValue(entry, Convert.ChangeType(vals[i], col.PropertyType));
                        }
                    }
                }
                output.Add(entry);
            });
            return output;
        }

        public static void SaveToTextFile<T>(List<T> data, string filePath) where T : class, new()
        {
            List<string> lines = new();
            StringBuilder line = new();

            if (data == null || data.Count == 0)
            {
                throw new ArgumentNullException("data", "You must populate the data parameter with at least ...");
            }
            var cols = data[0].GetType().GetProperties();

            /* Loops through each column and gets the name so it can comma seperate it into the header row */
            foreach (var col in cols)
            {
                line.Append(col.Name);
                line.Append(',');

                /* Adds the column header entries to the first line (removing the last comma from the and first) */
                lines.Add(line.ToString().Substring(0, line.Length - 1));
            }
            File.WriteAllLines(filePath, lines); 
        } 
    }
}
