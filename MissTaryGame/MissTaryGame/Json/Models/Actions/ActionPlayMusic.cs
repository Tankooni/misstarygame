/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/24/2014
 * Time: 2:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Indigo;
using MissTaryGame;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MissTaryGame.Json.Models.Actions {
    /// <summary>
    /// Description of ActionAddObjectToInventory.
    /// </summary>
    public class ActionPlayMusic : IAction {
        public string MusicName;

        public override void run(Action[] remainingActions) {
            SoundManager.PlayMusic(MusicName);

            Action.runActions(remainingActions);
        }
    }
}
