using AIMLbot;
using AIMLbot.Utils;
using System;
using System.Xml;

namespace AIMLbot.AIMLTagHandlers
{
	public class system : AIMLTagHandler
	{
		public system(Bot bot, User user, SubQuery query, Request request, Result result, XmlNode templateNode) : base(bot, user, query, request, result, templateNode)
		{
		}

		protected override string ProcessChange()
		{
			this.bot.writeToLog("The system tag is not implemented in this bot");
			return string.Empty;
		}
	}
}