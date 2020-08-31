using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using UnityEngine.SceneManagement;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;
using BS_Utils.Utilities;
using System.IO;
using Newtonsoft.Json;

namespace DisableSmoothCamera
{

    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin instance { get; private set; }
        internal static string Name => "DisableSmoothCamera";

        public static SettingsFlowCoordinator settingsFlowCoordinator;

        public static MainSettingsModelSO setting;

        string filePath = Application.persistentDataPath + "/settings.cfg";
        //string tempFilePath = Application.persistentDataPath + "/settings.cfg.tmp";
        //string backupFilePath = Application.persistentDataPath + "/settings.cfg.bak";

        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        public void Init(IPALogger logger)
        {
            instance = this;
            Logger.log = logger;
            Logger.log.Debug("Logger initialized.");
            try {
                var settings = JsonConvert.DeserializeObject<ConfigEntity>(File.ReadAllText(this.filePath));
                if (settings.smoothCameraEnabled == 1) {
                    settings.smoothCameraEnabled = 0;
                    File.WriteAllText(filePath, JsonConvert.SerializeObject(settings));
                }
            }
            catch (Exception e) {
                Logger.log.Error(e);
            }
            
        }

        #region BSIPA Config
        //Uncomment to use BSIPA's config
        /*
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Logger.log.Debug("Config loaded");
        }
        */
        #endregion

        [OnStart]
        public void OnApplicationStart()
        {
            Logger.log.Debug("OnApplicationStart");
            BSEvents.earlyMenuSceneLoadedFresh += this.BSEvents_earlMenuSceneLoadedFresh;
        }

        private void BSEvents_earlMenuSceneLoadedFresh(ScenesTransitionSetupDataSO obj)
        {
            settingsFlowCoordinator = Resources.FindObjectsOfTypeAll<SettingsFlowCoordinator>().FirstOrDefault();
            setting = settingsFlowCoordinator.GetPrivateField<MainSettingsModelSO>("_mainSettingsModel");

            setting.smoothCameraEnabled.didChangeEvent -= this.SmoothCameraEnabled_didChangeEvent;
            setting.smoothCameraEnabled.didChangeEvent += this.SmoothCameraEnabled_didChangeEvent;
        }


        private void SmoothCameraEnabled_didChangeEvent()
        {
            Logger.log.Info($"Change value : {setting.smoothCameraEnabled.value}");
            if (setting.smoothCameraEnabled.value) {
                setting.smoothCameraEnabled.value = false;
            }
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Logger.log.Debug("OnApplicationQuit");
        }
    }
}
