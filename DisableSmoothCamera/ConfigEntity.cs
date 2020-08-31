using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisableSmoothCamera
{
	public class ConfigEntity
	{
		
		public string version = "1.5.0";

		
		public int windowResolutionWidth = 1280;

		
		public int windowResolutionHeight = 720;

		
		public MainSettingsModelSO.WindowMode windowMode = MainSettingsModelSO.WindowMode.Fullscreen;

		
		public float vrResolutionScale = 1f;

		
		public float menuVRResolutionScaleMultiplier = 1f;

		
		public bool useFixedFoveatedRenderingDuringGameplay;

		
		public int antiAliasingLevel = 2;

		
		public int mirrorGraphicsSettings = 2;

		
		public int mainEffectGraphicsSettings = 1;

		
		public int bloomGraphicsSettings;

		
		public int smokeGraphicsSettings = 1;

		
		public bool burnMarkTrailsEnabled = true;

		
		public bool screenDisplacementEffectsEnabled = true;

		
		public float roomCenterX;

		
		public float roomCenterY;

		
		public float roomCenterZ;

		
		public float roomRotation;

		
		public float controllerPositionX;

		
		public float controllerPositionY;

		
		public float controllerPositionZ;

		
		public float controllerRotationX;

		
		public float controllerRotationY;

		
		public float controllerRotationZ;

		
		public int smoothCameraEnabled;

		
		public float smoothCameraFieldOfView = 70f;

		
		public float smoothCameraThirdPersonPositionX;

		
		public float smoothCameraThirdPersonPositionY = 1.5f;

		
		public float smoothCameraThirdPersonPositionZ = -1.5f;

		
		public float smoothCameraThirdPersonEulerAnglesX;

		
		public float smoothCameraThirdPersonEulerAnglesY;

		
		public float smoothCameraThirdPersonEulerAnglesZ;

		
		public int smoothCameraThirdPersonEnabled;

		
		public float smoothCameraRotationSmooth = 4f;

		
		public float smoothCameraPositionSmooth = 4f;

		
		public float volume = 1f;

		
		public bool controllersRumbleEnabled = true;

		
		public int enableAlphaFeatures;

		
		public int pauseButtonPressDurationLevel;

		
		public int maxShockwaveParticles = 1;

		
		public bool overrideAudioLatency;

		
		public float audioLatency;

		
		public int maxNumberOfCutSoundEffects = 24;

		
		public bool onlineServicesEnabled;

		
		public bool oculusMRCEnabled;
	}
}
