using System;
using PluginBase;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace RA
{
	public class PluginM
	{
		public List<IGame> plugins;
		public List<IGame> games;
		public PluginM ()
		{
		}
		public void Search(){
			PluginManager pm = new PluginManager ();
			games = new List<IGame> ();
			plugins = new List<IGame> ();
			pm.ScanPlugins (AppDomain.CurrentDomain.BaseDirectory+"Plugins\\");
			Console.WriteLine ("TS");
			foreach(IGame pl in pm.Plugins){
				Console.WriteLine ("TS");
				if (pl.plugin.Type == PlugType.Game) {
					
					games.Add (pl);
				} else {
					plugins.Add (pl);
				}
			}
		}
		public void Refresh(){
			PluginManager pm = new PluginManager ();
			pm.ScanPlugins (AppDomain.CurrentDomain.BaseDirectory+"Plugins\\");
			foreach(IGame pl in pm.Plugins){
				if (!plugins.Contains (pl) && !games.Contains (pl)) {
					if (pl.plugin.Type == PlugType.Game) {
						games.Add (pl);
					} else {
						plugins.Add (pl);
					}
				}
			}
		}
	}
}

