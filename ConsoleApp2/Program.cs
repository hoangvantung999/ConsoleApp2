using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"[{

                            'i_date':'2014-03-20',
                            'i_location':'test',
                            'i_summary':'test test',
                            'people':[
                              {
                                'first_name':'first name test1',
                                'last_name':'last name test1'
                              },
                              {
                                'first_name':'first name test2',
                                'last_name':'last name test2'
                              },
                              {
                                'first_name': 'first name test3',
                                'last_name':'last name test3'
                              }
                            ]
                          },{

                            'i_date':'2014-04-20',
                            'i_location':'test1',
                            'i_summary':'test test',
                            'people':[
                              {
                                'first_name':'first name test1',
                                'last_name':'last name test1'
                              },
                              {
                                'first_name':'first name test2',
                                'last_name':'last name test2'
                              },
                              {
                                'first_name': 'first name test3',
                                'last_name':'last name test3'
                              }
                            ]
                          },{

                            'i_date':'2014-05-20',
                            'i_location':'test1',
                            'i_summary':'test test',
                            'people':[
                              {
                                'first_name':'first name test1',
                                'last_name':'last name test1'
                              },
                              {
                                'first_name':'first name test2',
                                'last_name':'last name test2'
                              },
                              {
                                'first_name': 'first name test3',
                                'last_name':'last name test3'
                              }
                            ]
                          }]
                        ";

            var lstDic = JsonConvert.DeserializeObject<List<Dictionary<dynamic,dynamic>>>(json);
            List<CustomConfig> lstCus = new List<CustomConfig>();
            Dictionary<string, List<dynamic>> dictionary = new Dictionary<string, List<dynamic>>();

            //====================Save Field Key=============================//
            int idx = 1;
            foreach (var item in lstDic[0])
            {
                var key = "CustomField" + (idx).ToString();
                CustomConfig cus = new CustomConfig()
                {
                    CustomField = key,
                    FieldKey = item.Key
                  
                };
                lstCus.Add(cus);

                idx++;
            }
            foreach(var item in lstCus)
            {
                Console.WriteLine(item.CustomField + ": " + item.FieldKey);
            }

            //=================================================//
            
            //=====================Save Values============================//


            foreach (var items in lstDic)
            {
                int index = 0;
                foreach(KeyValuePair<dynamic,dynamic> item in items)
                {
                    string key = "CustomField" + (index + 1).ToString();
                    if (!dictionary.ContainsKey(key))
                    {
                        dictionary.Add(key, new List<dynamic>());
                    }
                    dictionary[key].Add(item.Value);
                    index++;
                }

            }

            //===============================================//

            Dictionary<string, string> strDic = new Dictionary<string, string>();
            foreach (var key in dictionary.Keys)
            {
                var str = JsonConvert.SerializeObject(dictionary[key], Newtonsoft.Json.Formatting.Indented);
                strDic[key] = str;
            }


            

            var jsonStr = JsonConvert.SerializeObject(strDic, Newtonsoft.Json.Formatting.Indented);
            var CustomConvert = JsonConvert.DeserializeObject<Custom>(jsonStr);

            Console.WriteLine(CustomConvert.CustomField2);
 

        }
    }
}
