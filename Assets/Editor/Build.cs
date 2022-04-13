using UnityEditor;
using UnityEditor.Build.Reporting;
using System;
class MacOS
{	static void Version() {

		// Get arguments from environment variables
		string releaseType = Environment.GetEnvironmentVariable("__releaseType");

		// Check mandatory environment variables
		if(releaseType == null)
		{
			Console.WriteLine("MacOS.Build: Mandatory environment variable releaseType missing");
			EditorApplication.Exit(1);
		}

		// Set version for this release
		Console.WriteLine("MacOS.Version: Current version = " + PlayerSettings.bundleVersion);
		string currentVersion = PlayerSettings.bundleVersion;
		int majorIndex = Convert.ToInt32(currentVersion.Substring(0, 1));
		int minorIndex = Convert.ToInt32(currentVersion.Substring(2, 1));
		int patchIndex = Convert.ToInt32(currentVersion.Substring(4, 1));
		switch (releaseType)
		{
			case "major":
				majorIndex++;
				minorIndex = 0;
				patchIndex = 0;
				break;
			case "minor":
				minorIndex++;
				patchIndex = 0;
				break;
			case "patch":
				patchIndex++;
				break;
			case "overwrite":
				break;
			default:
				Console.WriteLine("MacOS.Build: Unknown releaseType: " + releaseType);
				EditorApplication.Exit(1);
				break;
		}
		// Set bundleVersion based on releaseType
		PlayerSettings.bundleVersion = majorIndex.ToString() + "." + minorIndex.ToString() + "." + patchIndex.ToString();
		// Always step bundleVersionCode
		Console.WriteLine("MacOS.Build: New version = " + PlayerSettings.bundleVersion);
	}
	static void Build() {

		string[] scenes = {"Assets/Scenes/Run.unity"};

		// Get arguments from environment variables
		string targetFile = Environment.GetEnvironmentVariable("__targetFile");
		string targetDir = Environment.GetEnvironmentVariable("__targetDir");

		// Check mandatory environment variables
		if(targetFile == null || targetDir == null)
		{
			if (targetFile == null)
				Console.WriteLine("MacOS.Build: Mandatory environment variable targetFile missing");
			if (targetDir == null)
				Console.WriteLine("MacOS.Build: Mandatory environment variable targetDir missing");
			EditorApplication.Exit(1);
		}
		// Set Build path
		string buildPath = targetDir + "/" + targetFile;

		// EditorUserBuildSettings
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneOSX);

		// PlayerSettings
		PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.Mono2x);

		// Build options
		BuildOptions buildOptions = BuildOptions.StrictMode;

		// Build Player
		BuildPipeline.BuildPlayer(scenes, buildPath, BuildTarget.StandaloneOSX, buildOptions);
	}
}
