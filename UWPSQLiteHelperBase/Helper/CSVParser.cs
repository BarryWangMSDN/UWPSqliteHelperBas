﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPSQLiteHelperBase.Helper
{
   public class CSVParser
    {
        private const char DEFAULT_DELIMITER = ',';
        private const char DEFAULT_LINE_DELIMITER = '\n';

        public char Delimiter { get; set; }
        public char LineDelimiter { get; set; }
        public string RawText { get; set; }
        public bool HasHeaderRow { get; set; }

        public CSVParser()
        {
            this.Delimiter = DEFAULT_DELIMITER;
            this.LineDelimiter = DEFAULT_LINE_DELIMITER;
        }


        public List<Dictionary<string, string>> Parse()
        {
            List<Dictionary<string, string>> parsedResult = new List<Dictionary<string, string>>();
            string[] records = RawText.Split(this.LineDelimiter);


            int startingRow = 0;
            List<string> fieldList = new List<string>();


            if (this.HasHeaderRow)
            {
                startingRow = 1;
                fieldList = LoadFieldNamesFromHeaderRow();
            }

            for (int i = startingRow; i < records.Length; i++)
            {
                string record = records[i];

                string[] fields = record.Split(this.Delimiter);
                Dictionary<string, string> recordItem = new Dictionary<string, string>();

                int fieldIncrementer = 0;


                foreach (var field in fields)
                {
                    string key = fieldIncrementer.ToString();

                    if (this.HasHeaderRow)
                    {
                        if (fields.Length == fieldList.Count)
                        {
                            key = fieldList[fieldIncrementer];
                        }
                    }

                    recordItem.Add(key, field);
                    fieldIncrementer++;

                }

                parsedResult.Add(recordItem);
            }
            return parsedResult;
        }
        private List<string> LoadFieldNamesFromHeaderRow()
        {
            var fieldList = new List<string>();

            var firstLine = this.RawText.Split(this.LineDelimiter).FirstOrDefault();

            if (firstLine != null)
            {
                fieldList = firstLine.TrimEnd().Split(this.Delimiter).ToList();
            }

            return fieldList;
        }
    }
}
