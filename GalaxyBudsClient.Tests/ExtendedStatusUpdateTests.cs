using GalaxyBudsClient.Message;
using GalaxyBudsClient.Message.Decoder;
using GalaxyBudsClient.Model.Constants;

namespace GalaxyBudsClient.Tests;

[TestFixture, Description("Test ExtendedStatusUpdate parsers"), TestOf(typeof(ExtendedStatusUpdateDecoder))]
public class ExtendedStatusUpdateTests : MessageTests<ExtendedStatusUpdateDecoder>
{
    protected override string TestDataGroup => "ExtendedStatusUpdate";
    
    [Test, TestCaseSource(nameof(_testCases)), Description("Decode ExtendedStatusUpdate message")]
    public void Decode(TestCase testCase) => DecodeAndVerify(testCase);

    private static object[] _testCases =
    [
        new TestCase { Revision = 10, Model = Models.BudsPro, ExpectedResult = new ExtendedStatusUpdateDecoder(new SppMessage())
        {
            TargetModel = Models.BudsPro,

            Revision = 10,
            EarType = 2,
            BatteryL = 89,
            BatteryR = 94,
            IsCoupled = true,
            MainConnection = DevicesInverted.L,
            WearState = LegacyWearStates.L,
            EqualizerMode = 1,
            TouchpadLock = false,
            TouchpadOptionL = TouchOptions.NoiseControl,
            TouchpadOptionR = TouchOptions.NoiseControl,
            SeamlessConnectionEnabled = true,
            AmbientSoundVolume = 2,
            PlacementL = PlacementStates.Wearing,
            PlacementR = PlacementStates.Case,
            BatteryCase = 100,
            OutsideDoubleTap = true,
            ColorL = DeviceIds.BudsProBlack,
            ColorR = DeviceIds.BudsProBlack,
            AdjustSoundSync = false,
            SideToneEnabled = false,
            ExtraHighAmbientEnabled = false,
            VoiceWakeUp = false,
            VoiceWakeUpLang = 1,
            FmmRevision = 3,
            NoiseControlMode = NoiseControlModes.Off,
            NoiseControlTouchOff = true,
            NoiseControlTouchAnc = true,
            NoiseControlTouchAmbient = false,
            NoiseControlTouchLeftOff = true,
            NoiseControlTouchLeftAnc = true,
            NoiseControlTouchLeftAmbient = false,
            SpeakSeamlessly = false,
            NoiseReductionLevel = 1,
            AutoSwitchAudioOutput = false,
            DetectConversations = false,
            DetectConversationsDuration = 2,
            SpatialAudio = false,
            HearingEnhancements = 16,
            NoiseControlsWithOneEarbud = false,
            AmbientCustomVolumeOn = false,
            AmbientCustomVolumeLeft = 2,
            AmbientCustomVolumeRight = 2,
            AmbientCustomSoundTone = 2,
            CallPathControl = true
        }},
        new TestCase { Revision = 13, Model = Models.Buds2Pro, ExpectedResult = new ExtendedStatusUpdateDecoder(new SppMessage())
        {
            TargetModel = Models.Buds2Pro,

            Revision = 13,
            EarType = 4,
            BatteryL = 100,
            BatteryR = 100,
            IsCoupled = true,
            MainConnection = DevicesInverted.R,
            WearState = LegacyWearStates.None,
            EqualizerMode = 1,
            TouchpadLock = false,
            TouchpadOptionL = TouchOptions.NoiseControl,
            TouchpadOptionR = TouchOptions.NoiseControl,
            SeamlessConnectionEnabled = true,
            AmbientSoundVolume = 3,
            PlacementL = PlacementStates.Case,
            PlacementR = PlacementStates.Case,
            BatteryCase = 88,
            OutsideDoubleTap = true,
            ColorL = DeviceIds.Buds2ProGrey,
            ColorR = DeviceIds.Buds2ProGrey,
            AdjustSoundSync = false,
            SideToneEnabled = true,
            ExtraHighAmbientEnabled = true,
            VoiceWakeUp = true,
            VoiceWakeUpLang = 0,
            FmmRevision = 3,
            NoiseControlMode = NoiseControlModes.Off,
            NoiseControlTouchOff = true,
            NoiseControlTouchAnc = true,
            NoiseControlTouchAmbient = false,
            NoiseControlTouchLeftOff = true,
            NoiseControlTouchLeftAnc = false,
            NoiseControlTouchLeftAmbient = true,
            SpeakSeamlessly = false,
            NoiseReductionLevel = 0,
            AutoSwitchAudioOutput = false,
            DetectConversations = true,
            DetectConversationsDuration = 1,
            SpatialAudio = false,
            HearingEnhancements = 16,
            SingleTapOn = true,
            DoubleTapOn = true,
            TripleTapOn = true,
            TouchHoldOn = true,
            DoubleTapForCallOn = true,
            TouchHoldOnForCallOn = true,
            TouchType = 0,
            NoiseControlsWithOneEarbud = true,
            AmbientCustomVolumeOn = true,
            AmbientCustomVolumeLeft = 3,
            AmbientCustomVolumeRight = 2,
            AmbientCustomSoundTone = 3,
            CallPathControl = false,
            IsLeftCharging = false,
            IsRightCharging = false,
            IsCaseCharging = false,
            HearingTestValue = 3,
            BixbyKeyword = 0,
            NeckStretchCalibration = true,
            CustomizeNoiseReductionLevel = 174, // unused value; doesn't seem right
            CustomizeConversationBoost = true, // unused
            ExtraClearCallSound = true,
            SpatialAudioHeadTracking = true,
            AutoAdjustSound = false
        }}
    ];
}