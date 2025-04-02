using FrooxEngine;
using HarmonyLib;
using ResoniteModLoader;

namespace ResoniteAprilFools;
//More info on creating mods can be found https://github.com/resonite-modding-group/ResoniteModLoader/wiki/Creating-Mods
public class ResoniteAprilFools : ResoniteMod {
	internal const string VERSION_CONSTANT = "1.0.0"; //Changing the version here updates it in all locations needed
	public override string Name => "ResoniteAprilFools";
	public override string Author => "__Choco__";
	public override string Version => VERSION_CONSTANT;
	public override string Link => "https://github.com/AwesomeTornado/ResoniteAprilFools/";

	public override void OnEngineInit() {
		Harmony harmony = new Harmony("com.__Choco__.ResoniteAprilFools");

		harmony.Patch(AccessTools.Method(typeof(Engine), "<get_IsAprilFools>g__IsAprilFools|2_0"), prefix: AccessTools.Method(typeof(AprilFoolsPatch), "Prefix"));

		harmony.PatchAll();

		Msg("Resonite April Fools has initialized");
		Msg("Enjoy the tomfoolery!");
	}

	class AprilFoolsPatch{
		static bool Prefix(ref bool __result) {
			__result = true;
			return false;
		}
	}
}
