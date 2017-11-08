using System;
using NiceJson;

namespace ESBreakerCLI
{
	public static class ParseTextStrategies
	{
		public static JsonArray UIText(object source, JsonArray existingData, bool saveJson)
		{
			JsonArray data = new JsonArray();
			Contents.Text.UI.Format textUIFormat = (Contents.Text.UI.Format)source;
			string currentAssign;

			foreach (Contents.Text.UI.Information information in textUIFormat.Information)
			{
				JsonObject savedItem = default(JsonObject);
				JsonObject item = new JsonObject();
				if (information.Assign.GetType() == typeof(Contents.Text.Assign.TypeInt))
				{
					currentAssign = ((Contents.Text.Assign.TypeInt)information.Assign).Param.ToString();
				}
				else
				{
					currentAssign = ((Contents.Text.Assign.TypeString)information.Assign).Param.Trim();
				}

				for (int idx = 0; idx < existingData.Count; idx++)
				{
					if (existingData[idx]["jp_text"] == information.Text)
					{
						savedItem = (JsonObject)existingData[idx];
						existingData.RemoveAt(idx);
						break;
					}
				}

				item["assign"] = currentAssign;
				item["jp_text"] = information.Text;
				item["tr_text"] = "";
				if (savedItem != default(JsonObject))
				{
					if (savedItem["tr_text"] != "")
					{
						information.Text = savedItem["tr_text"];
						item["tr_text"] = savedItem["tr_text"];
					}
				}
				if (saveJson)
				{
					data.Add(item);
				}
			}
			return data;
		}

		public static JsonArray IllustratorText(object source, JsonArray existingData, bool saveJson)
		{
			JsonArray data = new JsonArray();
			Contents.Text.Illustrator.Format textUIFormat = (Contents.Text.Illustrator.Format)source;
			string chipId;

			foreach (Contents.Text.Illustrator.Information information in textUIFormat.Information)
			{
				JsonObject savedItem = default(JsonObject);
				JsonObject item = new JsonObject();

				chipId = ((Contents.Text.Assign.TypeInt)information.Assign).Param.ToString();
				for (int idx = 0; idx < existingData.Count; idx++)
				{
					if (existingData[idx]["jp_name"] == information.Name)
					{
						savedItem = (JsonObject)existingData[idx];
						existingData.RemoveAt(idx);
						break;
					}
				}

				item["chip"] = chipId;
				item["jp_CV"] = information.CV;
				item["tr_CV"] = "";
				item["jp_name"] = information.Name;
				item["tr_name"] = "";
				if (savedItem != default(JsonObject))
				{
					if (savedItem["tr_name"] != "")
					{
						information.Name = savedItem["tr_name"];
						item["tr_name"] = savedItem["tr_name"];
					}
					if (savedItem["tr_CV"] != "")
					{
						information.CV = savedItem["tr_CV"];
						item["tr_CV"] = savedItem["tr_CV"];
					}
				}
				if (saveJson)
				{
					data.Add(item);
				}
			}
			return data;
		}


		public static JsonArray ChipExplain(object source, JsonArray existingData, bool saveJson)
		{
			JsonArray data = new JsonArray();
			Contents.Text.ChipExplain.Format chipExplainFormat = (Contents.Text.ChipExplain.Format)source;
			string currentAssign;

			foreach (Contents.Text.ChipExplain.Information information in chipExplainFormat.Information)
			{
				JsonObject savedItem = default(JsonObject);
				JsonObject item = new JsonObject();
				if (information.Assign.GetType() == typeof(Contents.Text.Assign.TypeInt))
				{
					currentAssign = ((Contents.Text.Assign.TypeInt)information.Assign).Param.ToString();
				}
				else
				{
					currentAssign = ((Contents.Text.Assign.TypeString)information.Assign).Param.Trim();
				}

				for (int idx = 0; idx < existingData.Count; idx++)
				{
					if (existingData[idx]["jp_explainShort"] == information.ExplainShort)
					{
						savedItem = (JsonObject)existingData[idx];
						existingData.RemoveAt(idx);
						break;
					}
				}

				item["assign"] = currentAssign;
				item["jp_explainShort"] = information.ExplainShort;
				item["tr_explainShort"] = "";
				item["jp_explainLong"] = information.ExplainLong;
				item["tr_explainLong"] = "";
				if (savedItem != default(JsonObject))
				{
					if (savedItem["tr_explainShort"] != "")
					{
						information.ExplainLong = savedItem["tr_explainShort"];
						item["tr_explainShort"] = savedItem["tr_explainShort"];
					}
					if (savedItem["tr_explainLong"] != "")
					{
						information.ExplainLong = savedItem["tr_explainLong"];
						item["tr_explainLong"] = savedItem["tr_explainLong"];
					}
				}
				if (saveJson)
				{
					data.Add(item);
				}
			}
			return data;
		}

		public static JsonArray Name(object source, JsonArray existingData, bool saveJson)
		{
			JsonArray data = new JsonArray();
			Contents.Text.Name.Format textInformationFormat = (Contents.Text.Name.Format)source;
			if (textInformationFormat != null)
			{
				Contents.Text.Name.Information information = textInformationFormat.Information[0];
				if (information.Assign != null)
				{
					string currentAssign;
					Type infoType = information.Assign.GetType();
					foreach (Contents.Text.Name.Information innerInformation in textInformationFormat.Information)
					{
						JsonObject savedItem = default(JsonObject);
						currentAssign = "";
						JsonObject item = new JsonObject();
						if (infoType == typeof(Contents.Text.Assign.Type2Int))
						{
							Contents.Text.Assign.Type2Int assign = (Contents.Text.Assign.Type2Int)innerInformation.Assign;
							for (int i = 0; i < assign.Param.Length; i++)
								currentAssign += assign.Param[i].ToString();
						}
						else if (infoType == typeof(Contents.Text.Assign.TypeInt))
						{
							Contents.Text.Assign.TypeInt assign = (Contents.Text.Assign.TypeInt)innerInformation.Assign;
							currentAssign = assign.Param.ToString();
						}
						else if (infoType == typeof(Contents.Text.Assign.TypeString))
						{
							Contents.Text.Assign.TypeString assign = (Contents.Text.Assign.TypeString)innerInformation.Assign;
							currentAssign = assign.Param;
						}
						else if (infoType == typeof(Contents.Text.Assign.Type4Int))
						{
							Contents.Text.Assign.Type4Int assign = (Contents.Text.Assign.Type4Int)innerInformation.Assign;
							for (int i = 0; i < assign.Param.Length; i++)
								currentAssign += assign.Param[i].ToString();
						}
						else
						{
							Console.Error.WriteLine("New assign format?");
						}

						for (int idx = 0; idx < existingData.Count; idx++)
						{
							if (existingData[idx]["jp_text"] == innerInformation.Name)
							{
								savedItem = (JsonObject)existingData[idx];
								existingData.RemoveAt(idx);
								break;
							}
						}
						item["assign"] = currentAssign;
						item["jp_text"] = innerInformation.Name;
						item["tr_text"] = "";
						if (savedItem != default(JsonObject))
						{
							if (savedItem["tr_text"] != "")
							{
								innerInformation.Name = savedItem["tr_text"];
								item["tr_text"] = savedItem["tr_text"];
							}
						}
						if (saveJson)
						{
							data.Add(item);
						}
					}
				}
			}
			return data;
		}

		public static JsonArray Charged(object source, JsonArray existingData, bool saveJson)
		{
			JsonArray data = new JsonArray();
			Contents.Text.Charged.Format textInformationFormat = (Contents.Text.Charged.Format)source;
			if (textInformationFormat != null)
			{
				Contents.Text.Charged.Information information = textInformationFormat.Information[0];
				if (information.Assign != null)
				{
					string currentAssign;
					Type infoType = information.Assign.GetType();
					foreach (Contents.Text.Charged.Information innerInformation in textInformationFormat.Information)
					{
						JsonObject savedItem = default(JsonObject);
						currentAssign = "";
						JsonObject item = new JsonObject();
						if (infoType == typeof(Contents.Text.Assign.Type2Int))
						{
							Contents.Text.Assign.Type2Int assign = (Contents.Text.Assign.Type2Int)innerInformation.Assign;
							for (int i = 0; i < assign.Param.Length; i++)
								currentAssign += assign.Param[i].ToString();
						}
						else if (infoType == typeof(Contents.Text.Assign.TypeInt))
						{
							Contents.Text.Assign.TypeInt assign = (Contents.Text.Assign.TypeInt)innerInformation.Assign;
							currentAssign = assign.Param.ToString();
						}
						else if (infoType == typeof(Contents.Text.Assign.TypeString))
						{
							Contents.Text.Assign.TypeString assign = (Contents.Text.Assign.TypeString)innerInformation.Assign;
							currentAssign = assign.Param;
						}
						else if (infoType == typeof(Contents.Text.Assign.Type4Int))
						{
							Contents.Text.Assign.Type4Int assign = (Contents.Text.Assign.Type4Int)innerInformation.Assign;
							for (int i = 0; i < assign.Param.Length; i++)
								currentAssign += assign.Param[i].ToString();
						}
						else
						{
							Console.Error.WriteLine("New assign format?");
						}

						for (int idx = 0; idx < existingData.Count; idx++)
						{
							if (existingData[idx]["jp_text"] == innerInformation.Name)
							{
								savedItem = (JsonObject)existingData[idx];
								existingData.RemoveAt(idx);
								break;
							}
						}
						item["assign"] = currentAssign;
						item["jp_text"] = innerInformation.Name;
						item["tr_text"] = "";
						if (savedItem != default(JsonObject))
						{
							if (savedItem["tr_text"] != "")
							{
								innerInformation.Name = savedItem["tr_text"];
								item["tr_text"] = savedItem["tr_text"];
							}
						}
						if (saveJson)
						{
							data.Add(item);
						}
					}
				}
			}
			return data;
		}

		public static JsonArray NGWord(object source, JsonArray existingData, bool saveJson)
		{
			JsonArray data = new JsonArray();
			Contents.Text.NGWord.Format textInformationFormat = (Contents.Text.NGWord.Format)source;
			if (textInformationFormat != null)
			{
				Contents.Text.NGWord.Information information = textInformationFormat.Information[0];
				if (information.Assign != null)
				{
					string currentAssign;
					Type infoType = information.Assign.GetType();
					foreach (Contents.Text.NGWord.Information innerInformation in textInformationFormat.Information)
					{
						JsonObject savedItem = default(JsonObject);
						currentAssign = "";
						JsonObject item = new JsonObject();
						if (infoType == typeof(Contents.Text.Assign.Type2Int))
						{
							Contents.Text.Assign.Type2Int assign = (Contents.Text.Assign.Type2Int)innerInformation.Assign;
							for (int i = 0; i < assign.Param.Length; i++)
								currentAssign += assign.Param[i].ToString();
						}
						else if (infoType == typeof(Contents.Text.Assign.TypeInt))
						{
							Contents.Text.Assign.TypeInt assign = (Contents.Text.Assign.TypeInt)innerInformation.Assign;
							currentAssign = assign.Param.ToString();
						}
						else if (infoType == typeof(Contents.Text.Assign.TypeString))
						{
							Contents.Text.Assign.TypeString assign = (Contents.Text.Assign.TypeString)innerInformation.Assign;
							currentAssign = assign.Param;
						}
						else if (infoType == typeof(Contents.Text.Assign.Type4Int))
						{
							Contents.Text.Assign.Type4Int assign = (Contents.Text.Assign.Type4Int)innerInformation.Assign;
							for (int i = 0; i < assign.Param.Length; i++)
								currentAssign += assign.Param[i].ToString();
						}
						else
						{
							Console.Error.WriteLine("New assign format?");
						}

						for (int idx = 0; idx < existingData.Count; idx++)
						{
							if (existingData[idx]["text"] == innerInformation.Text)
							{
								savedItem = (JsonObject)existingData[idx];
								existingData.RemoveAt(idx);
								break;
							}
						}
						item["assign"] = currentAssign;
						item["text"] = innerInformation.Text;
						if (saveJson)
						{
							data.Add(item);
						}
					}
				}
			}
			return data;
		}


		public static JsonArray SeraphyRoom(object source, JsonArray existingData, bool saveJson)
		{
			JsonArray data = new JsonArray();
			Contents.Text.SeraphyRoom.Format seraphyFormat = (Contents.Text.SeraphyRoom.Format)source;
			if (seraphyFormat != null)
			{
				Contents.Text.SeraphyRoom.Information information = seraphyFormat.Information[0];
				if (information.Assign != null)
				{
					foreach (Contents.Text.SeraphyRoom.Information innerInformation in seraphyFormat.Information)
					{
						JsonObject savedItem = default(JsonObject);
						for (int idx = 0; idx < existingData.Count; idx++)
						{
							if (existingData[idx]["jp_text"] == innerInformation.Text)
							{
								savedItem = (JsonObject)existingData[idx];
								existingData.RemoveAt(idx);
								break;
							}
						}
						JsonObject item = new JsonObject();
						item["text_id"] = innerInformation.TextId;
						item["jp_text"] = innerInformation.Text;
						item["tr_text"] = "";
						if (savedItem != default(JsonObject))
						{
							if (savedItem["tr_text"] != "")
							{
								innerInformation.Text = savedItem["tr_text"];
								item["tr_text"] = savedItem["tr_text"];
							}
						}
						if (saveJson)
						{
							data.Add(item);
						}
					}
				}
			}
			return data;
		}

		public static JsonArray Item(object source, JsonArray existingData, bool saveJson)
		{
			JsonArray data = new JsonArray();
			Contents.Text.Item.Format textInformationFormat = (Contents.Text.Item.Format)source;
			if (textInformationFormat != null && textInformationFormat.Information != null)
			{
				Contents.Text.Item.Information information = textInformationFormat.Information[0];
				if (information.Assign != null)
				{
					string currentAssign;
					Type infoType = information.Assign.GetType();
					foreach (Contents.Text.Item.Information innerInformation in textInformationFormat.Information)
					{
						JsonObject savedItem = default(JsonObject);
						currentAssign = "";
						JsonObject item = new JsonObject();
						if (infoType == typeof(Contents.Text.Assign.Type2Int))
						{
							Contents.Text.Assign.Type2Int assign = (Contents.Text.Assign.Type2Int)innerInformation.Assign;
							for (int i = 0; i < assign.Param.Length; i++)
								currentAssign += assign.Param[i].ToString();
						}
						else if (infoType == typeof(Contents.Text.Assign.TypeInt))
						{
							Contents.Text.Assign.TypeInt assign = (Contents.Text.Assign.TypeInt)innerInformation.Assign;
							currentAssign = assign.Param.ToString();
						}
						else if (infoType == typeof(Contents.Text.Assign.TypeString))
						{
							Contents.Text.Assign.TypeString assign = (Contents.Text.Assign.TypeString)innerInformation.Assign;
							currentAssign = assign.Param;
						}
						else if (infoType == typeof(Contents.Text.Assign.Type4Int))
						{
							Contents.Text.Assign.Type4Int assign = (Contents.Text.Assign.Type4Int)innerInformation.Assign;
							for (int i = 0; i < assign.Param.Length; i++)
								currentAssign += assign.Param[i].ToString();
						}
						else
						{
							Console.Error.WriteLine("New assign format?");
						}

						for (int idx = 0; idx < existingData.Count; idx++)
						{
							if (existingData[idx]["jp_text"] == innerInformation.Name)
							{
								savedItem = (JsonObject)existingData[idx];
								existingData.RemoveAt(idx);
								break;
							}

						}
						item["assign"] = currentAssign;
						item["jp_text"] = innerInformation.Name;
						item["tr_text"] = "";
						item["jp_explain"] = innerInformation.Explain;
						item["tr_explain"] = "";
						if (savedItem != default(JsonObject))
						{
							if (savedItem["tr_text"] != "")
							{
								innerInformation.Name = savedItem["tr_text"];
								item["tr_text"] = savedItem["tr_text"];
							}
							if (savedItem["tr_explain"] != "")
							{
								innerInformation.Explain = savedItem["tr_explain"];
								item["tr_explain"] = savedItem["tr_explain"];
							}
						}
						if (saveJson)
						{
							data.Add(item);
						}
					}
				}

			}
			return data;
		}

		public static JsonArray Explain(object source, JsonArray existingData, bool saveJson)
		{
			JsonArray data = new JsonArray();
			Contents.Text.Explain.Format textInformationFormat = (Contents.Text.Explain.Format)source;
			if (textInformationFormat != null && textInformationFormat.Information != null)
			{
				Contents.Text.Explain.Information information = textInformationFormat.Information[0];
				if (information.Assign != null)
				{
					string currentAssign;
					Type infoType = information.Assign.GetType();
					foreach (Contents.Text.Explain.Information innerInformation in textInformationFormat.Information)
					{
						JsonObject savedItem = default(JsonObject);
						currentAssign = "";
						JsonObject item = new JsonObject();
						if (infoType == typeof(Contents.Text.Assign.Type2Int))
						{
							Contents.Text.Assign.Type2Int assign = (Contents.Text.Assign.Type2Int)innerInformation.Assign;
							for (int i = 0; i < assign.Param.Length; i++)
								currentAssign += assign.Param[i].ToString();
						}
						else if (infoType == typeof(Contents.Text.Assign.TypeInt))
						{
							Contents.Text.Assign.TypeInt assign = (Contents.Text.Assign.TypeInt)innerInformation.Assign;
							currentAssign = assign.Param.ToString();
						}
						else if (infoType == typeof(Contents.Text.Assign.TypeString))
						{
							Contents.Text.Assign.TypeString assign = (Contents.Text.Assign.TypeString)innerInformation.Assign;
							currentAssign = assign.Param;
						}
						else if (infoType == typeof(Contents.Text.Assign.Type4Int))
						{
							Contents.Text.Assign.Type4Int assign = (Contents.Text.Assign.Type4Int)innerInformation.Assign;
							for (int i = 0; i < assign.Param.Length; i++)
								currentAssign += assign.Param[i].ToString();
						}
						else
						{
							Console.Error.WriteLine("New assign format?");
						}

						for (int idx = 0; idx < existingData.Count; idx++)
						{
							if (existingData[idx]["jp_text"] == innerInformation.Name)
							{
								savedItem = (JsonObject)existingData[idx];
								existingData.RemoveAt(idx);
								break;
							}

						}
						item["assign"] = currentAssign;
						item["jp_text"] = innerInformation.Name;
						item["tr_text"] = "";
						item["jp_explain"] = innerInformation.Explain;
						item["tr_explain"] = "";
						if (savedItem != default(JsonObject))
						{
							if (savedItem["tr_text"] != "")
							{
								innerInformation.Name = savedItem["tr_text"];
								item["tr_text"] = savedItem["tr_text"];
							}
							if (savedItem["tr_explain"] != "")
							{
								innerInformation.Explain = savedItem["tr_explain"];
								item["tr_explain"] = savedItem["tr_explain"];
							}
						}
						if (saveJson)
						{
							data.Add(item);
						}
					}
				}
			}

			return data;
		}
	}
}
