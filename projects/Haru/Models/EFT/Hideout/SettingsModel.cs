using Newtonsoft.Json;

namespace Haru.Models.EFT.Hideout
{
    public struct SettingsModel
    {
        [JsonProperty("generatorSpeedWithoutFuel")]
        public double GeneratorSpeedWithoutFuel;

        [JsonProperty("generatorFuelFlowRate")]
        public double GeneratorFuelFlowRate;

        [JsonProperty("airFilterUnitFlowRate")]
        public double AirFilterUnitFlowRate;

        [JsonProperty("gpuBoostRate")]
        public double GpuBoostRate;
    }
}