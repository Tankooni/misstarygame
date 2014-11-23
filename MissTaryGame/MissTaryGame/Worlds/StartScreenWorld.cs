/*
 * Created by SharpDevelop.
 * User: Croanc
 * Date: 11/21/2014
 * Time: 11:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Timers;
using System.Collections.Generic;
using Indigo;
using Indigo.Inputs;
using Indigo.Graphics;
using Microsoft.Win32;
using MissTaryGame.UI;

using MissTaryGame.Json;
using MissTaryGame.Json.Models;
using Action = MissTaryGame.Json.Models.Action;

namespace MissTaryGame
{
	/// <summary>
	/// Description of StartScreenGame.
	/// </summary>
	public class StartScreenWorld : World
	{
		private Text start;
        private Text instructions;
		public StartScreenWorld()
		{
            start = new Text("Start [Enter]");
            start.X = (FP.Width / 2) - (start.Width / 2);
            start.Y = (FP.Height / 3) + 25;

            instructions = new Text("Instructions [Space]");
            instructions.X = (FP.Width / 2) - (instructions.Width / 2);
            instructions.Y = (FP.Height / 3) + 50;

            // Testing stuff
            //SceneData sd = JsonLoader.LoadStream<SceneData>("{Name: \"testscene\", Objects: [{Name: \"Cool Beans\", Position: {X: 40, Y:50}, DefaultAnimation: \"Idle\"}], Regions: [] }");
            var iobj = JsonLoader.Load<InteractiveObjectData>("Testdata");
            
            TextBox box = new TextBox("Testing! dkfn aiofnosdian fiasdiof asdio fnasdion fioasdnf oasdnio fsdnoifn asiodnf oasdn fioasdnfio nasdiof nioasdnf ioasdnf iosadnf sndoafn asdiofn ioasdnf ioasdnfo iasdnoif nsdio fnaiosdnf oiasdnf onfiosdfioasndiofnasodn fd af sd fsdjf sdajf huisdafsduif uisdhf sdhi fasdui fhasduifh uisdh fuiasdhfiwehiufhasdufh wuhgidfb gidf giuadfhgiadhilgh weuifh uisdfh uiasdgh uidfh gfui asdh fpwe ip weipfj sdipj fkasdf lkasdnfjkwenuohweruoig adui ghodg ipsdj fosdfljasdnkfbweruih uisdh ud sh sdhof hauodhfbsda bnvbgnbvhyjhnbgdhyjfnbhjcdn vjdn vbnhjcm njcm nhmjc bnh mc njm c nm cnm vf cn mcbxn cnh  cbhnxs xcbxns cbhxjzmx cbvchxnjzsmn cbz cbxnhsjax cbxnhzsx dsf sd fds asd sad fasd fjsdah isdaf shadiufhvb chnbvhndhfg bidfhgh yudbhdbyshg idyfh byusdfg yusdfysdgyufg yusdg fsduayf gyusdg fyusd yufgsd ufgufasd fasd fasdf sdf ttt");
            box.show();
            
            Timer t = new Timer(3000);
            t.Elapsed += new ElapsedEventHandler( (Object sender, ElapsedEventArgs e) => {
                                                 	t.Stop();
                                                 	List<CommandData> cl = new List<CommandData>();
                                                 	var c = new CommandData();
                                     	            c.Name = "Talk";
                                     	            c.Actions = null;
                                     	            cl.Add(c);
                                                 	
                                     	            c = new CommandData();
                                     	            c.Name = "Use";
                                     	            c.Actions = null;
                                     	            cl.Add(c);
                                     	            
                                     	            c = new CommandData();
                                     	            c.Name = "Look";
                                     	            c.Actions = null;
                                     	            cl.Add(c);
                                     	            
                                     	            CommandWheel wheel = new CommandWheel(cl.ToArray());
                                     	            

                                                 	Add(wheel);
                                                 });
            
            t.Start();
            Add(box);
            //Add(wheel);
            
            AddGraphic(start);
            AddGraphic(instructions);
		}

		public override void Update()
		{
			base.Update();
//            if (Keyboard.Return.Pressed)
//                FP.World = new GameWorld();
//
//            if (Keyboard.Space.Pressed)
//                FP.World = new InstructionsScreenWorld();
		}
	}
}
