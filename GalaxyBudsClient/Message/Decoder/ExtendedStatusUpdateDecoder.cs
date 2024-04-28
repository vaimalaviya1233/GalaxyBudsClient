﻿using System;
using System.IO;
using GalaxyBudsClient.Generated.Model.Attributes;
using GalaxyBudsClient.Model.Attributes;
using GalaxyBudsClient.Model.Constants;
using GalaxyBudsClient.Model.Specifications;
using GalaxyBudsClient.Utils;

namespace GalaxyBudsClient.Message.Decoder;

[MessageDecoder(MsgIds.EXTENDED_STATUS_UPDATED)]
public class ExtendedStatusUpdateDecoder : BaseMessageDecoder, IBasicStatusUpdate
{
    public int Revision { init; get; }
    public int EarType { init; get; }
    public int BatteryL { init; get; }
    public int BatteryR { init; get; }
    public bool IsCoupled { init; get; }
    public DevicesInverted MainConnection { init; get; }
    public LegacyWearStates WearState { init; get; }
    public int EqualizerMode { init; get; }
    public bool TouchpadLock { init; get; }
    public TouchOptions TouchpadOptionL { init; get; }
    public TouchOptions TouchpadOptionR { init; get; }
    public bool SeamlessConnectionEnabled { init; get; }
    
    [Device(Models.Buds, Models.BudsPlus)]
    public bool AmbientSoundEnabled { init; get; }
    [Device(Models.BudsLive, Selector.NotEqual)]
    public int AmbientSoundVolume { init; get; }


    [Device(Models.Buds)]
    public AmbientTypes AmbientSoundMode { init; get; }
    [Device(Models.Buds)]
    public bool EqualizerEnabled { init; get; }


    [Device(Models.BudsPlus, Selector.GreaterEqual)]
    public PlacementStates PlacementL { init; get; }
    [Device(Models.BudsPlus, Selector.GreaterEqual)]
    public PlacementStates PlacementR { init; get; }
    [Device(Models.BudsPlus, Selector.GreaterEqual)]
    public int BatteryCase { init; get; }
    [Device(Models.BudsPlus, Selector.GreaterEqual)]
    public bool OutsideDoubleTap { init; get; }

    [Device(Models.BudsPlus, Selector.GreaterEqual)]
    public Colors ColorL { init; get; }
    [Device(Models.BudsPlus, Selector.GreaterEqual)]
    public Colors ColorR { init; get; }
    [Device(Models.BudsPlus, Selector.GreaterEqual)]
    public Colors DeviceColor => IsCoupled ? ColorR != 0 ? ColorR : ColorL : 
        (MainConnection == DevicesInverted.R ? ColorR : ColorL);
    
    [Device(Models.BudsPlus, Selector.GreaterEqual)]
    public bool AdjustSoundSync { init; get; }
    [Device(Models.BudsPlus, Selector.GreaterEqual)]
    public bool SideToneEnabled { init; get; }
    [Device(Models.BudsPlus, Selector.GreaterEqual)]
    public bool ExtraHighAmbientEnabled { init; get; }


    [Device(Models.BudsLive)]
    public bool RelieveAmbient { init; get; }
    [Device(Models.BudsLive, Selector.GreaterEqual)]
    public bool VoiceWakeUp { init; get; }
    [Device(Models.BudsLive, Selector.GreaterEqual)]
    public int VoiceWakeUpLang { init; get; }
    [Device(Models.BudsLive, Selector.GreaterEqual)]
    public int FmmRevision { init; get; }
    [Device(Models.BudsLive)]
    public bool NoiseCancelling { init; get; }


    [Device(Models.BudsPro, Selector.GreaterEqual)]
    public NoiseControlModes NoiseControlMode { init; get; }
    [Device(Models.BudsPro, Selector.GreaterEqual)]
    public bool NoiseControlTouchOff { init; get; }
    [Device(Models.BudsPro, Selector.GreaterEqual)]
    public bool NoiseControlTouchAnc { init; get; }
    [Device(Models.BudsPro, Selector.GreaterEqual)]
    public bool NoiseControlTouchAmbient { init; get; }
        
        
    [Device(Models.Buds2, Selector.GreaterEqual)]
    public bool NoiseControlTouchLeftOff { init; get; }
    [Device(Models.Buds2, Selector.GreaterEqual)]
    public bool NoiseControlTouchLeftAnc { init; get; }
    [Device(Models.Buds2, Selector.GreaterEqual)]
    public bool NoiseControlTouchLeftAmbient { init; get; }
        
        
    [Device(Models.BudsPro, Selector.GreaterEqual)]
    public bool SpeakSeamlessly { init; get; }

    [Device(Models.BudsPro, Selector.GreaterEqual)]
    public byte NoiseReductionLevel { init; get; }
    [Device(Models.BudsPro, Selector.GreaterEqual)]
    public bool AutoSwitchAudioOutput { init; get; }

    [Device(Models.BudsPro, Models.Buds2Pro)]
    public bool DetectConversations { init; get; } = true;
    [Device(Models.BudsPro, Models.Buds2Pro)]
    public byte DetectConversationsDuration { init; get; }
    [Device(Models.BudsLive, Selector.GreaterEqual)]
    public bool SpatialAudio { init; get; }
        
    [Device(Models.BudsLive, Selector.GreaterEqual)]
    public byte HearingEnhancements { init; get; }
        
    [Device(Models.Buds2, Selector.GreaterEqual)]
    public bool SingleTapOn { init; get; }
    [Device(Models.Buds2, Selector.GreaterEqual)]
    public bool DoubleTapOn { init; get; }
    [Device(Models.Buds2, Selector.GreaterEqual)]
    public bool TripleTapOn { init; get; }
    [Device(Models.Buds2, Selector.GreaterEqual)]
    public bool TouchHoldOn { init; get; }
    [Device(Models.Buds2, Selector.GreaterEqual)]
    public bool DoubleTapForCallOn { init; get; }
    [Device(Models.Buds2, Selector.GreaterEqual)]
    public bool TouchHoldOnForCallOn { init; get; }

    [Device(Models.Buds2, Selector.GreaterEqual)]
    public byte TouchType { init; get; }
    [Device(Models.BudsPro, Selector.GreaterEqual)]
    public bool NoiseControlsWithOneEarbud { init; get; }
        
    [Device(Models.BudsPro, Selector.GreaterEqual)]
    public bool AmbientCustomVolumeOn { init; get; }
    [Device(Models.BudsPro, Selector.GreaterEqual)]
    public byte AmbientCustomVolumeLeft { init; get; }
    [Device(Models.BudsPro, Selector.GreaterEqual)]
    public byte AmbientCustomVolumeRight { init; get; }
    [Device(Models.BudsPro, Selector.GreaterEqual)]
    public byte AmbientCustomSoundTone { init; get; }
    [Device(Models.BudsLive, Selector.GreaterEqual)]
    public bool CallPathControl { init; get; } 
    
    [Device(Models.Buds2, Selector.GreaterEqual)]
    public bool IsLeftCharging { init; get; }

    [Device(Models.Buds2, Selector.GreaterEqual)]
    public bool IsRightCharging { init; get; } 
    [Device(Models.Buds2, Selector.GreaterEqual)]
    public bool IsCaseCharging { init; get; }

    [Device(Models.Buds2Pro, Selector.GreaterEqual)]
    public byte HearingTestValue { init; get; }
    [Device(Models.Buds2Pro, Selector.GreaterEqual)]
    public byte BixbyKeyword { init; get; }
    [Device(Models.Buds2Pro, Selector.GreaterEqual)]
    public bool NeckStretchCalibration { init; get; }
    [Device(Models.Buds2Pro, Selector.GreaterEqual)]
    public byte CustomizeNoiseReductionLevel { init; get; }
    [Device(Models.Buds2Pro, Selector.GreaterEqual)]
    public bool CustomizeConversationBoost { init; get; }
    [Device(Models.Buds2Pro, Selector.GreaterEqual)]
    public bool ExtraClearCallSound { init; get; }
    [Device(Models.Buds2Pro, Selector.GreaterEqual)]
    public bool SpatialAudioHeadTracking { init; get; }
    [Device(Models.Buds2Pro, Selector.GreaterEqual)]
    public bool AutoAdjustSound { init; get; }
    
    public ExtendedStatusUpdateDecoder(SppMessage msg) : base(msg)
    {
        // TODO: clean this up
        
        if (TargetModel == Models.Buds)
        {
            Revision = msg.Payload[0];
            EarType = msg.Payload[1];
            BatteryL = msg.Payload[2];
            BatteryR = msg.Payload[3];
            IsCoupled = Convert.ToBoolean(msg.Payload[4]);
            MainConnection = (DevicesInverted)msg.Payload[5];
            WearState = (LegacyWearStates)msg.Payload[6];
            AmbientSoundEnabled = Convert.ToBoolean(msg.Payload[7]);
            AmbientSoundMode = (AmbientTypes)msg.Payload[8];
            AmbientSoundVolume = msg.Payload[9];
            EqualizerEnabled = Convert.ToBoolean(msg.Payload[10]);
            EqualizerMode = msg.Payload[11];

            if (msg.Size > 13)
            {
                TouchpadLock = Convert.ToBoolean(msg.Payload[12]);
                TouchpadOptionL = DeviceSpec.TouchMap.FromByte((byte)((msg.Payload[13] & 0xF0) >> 4));
                TouchpadOptionR = DeviceSpec.TouchMap.FromByte((byte)(msg.Payload[13] & 0x0F));
                if (Revision >= 3)
                {
                    SeamlessConnectionEnabled = msg.Payload[14] == 0;
                }
            }
            else
            {
                TouchpadLock = Convert.ToBoolean((msg.Payload[12] & 0xF0) >> 4);
                TouchpadOptionL = DeviceSpec.TouchMap.FromByte((byte)(msg.Payload[12] & 0x0F));
                TouchpadOptionR = DeviceSpec.TouchMap.FromByte((byte)(msg.Payload[12] & 0x0F));
                if (Revision >= 3)
                {
                    SeamlessConnectionEnabled = msg.Payload[13] == 0;
                }
            }
                
            switch (WearState)
            {
                case LegacyWearStates.Both:
                    PlacementL = PlacementStates.Wearing;
                    PlacementR = PlacementStates.Wearing;
                    break;
                case LegacyWearStates.L:
                    PlacementL = PlacementStates.Wearing;
                    PlacementR = PlacementStates.Idle;
                    break;
                case LegacyWearStates.R:
                    PlacementL = PlacementStates.Idle;
                    PlacementR = PlacementStates.Wearing;
                    break;
                default:
                    PlacementL = PlacementStates.Idle;
                    PlacementR = PlacementStates.Idle;
                    break;
            }
        }
        else
        {
            Revision = msg.Payload[0];
            EarType = msg.Payload[1];
            BatteryL = msg.Payload[2];
            BatteryR = msg.Payload[3];
            IsCoupled = Convert.ToBoolean(msg.Payload[4]);
            MainConnection = (DevicesInverted)msg.Payload[5];

            PlacementL = (PlacementStates)((msg.Payload[6] & 240) >> 4);
            PlacementR = (PlacementStates)(msg.Payload[6] & 15);
            if (PlacementL == PlacementStates.Wearing && PlacementR == PlacementStates.Wearing)
                WearState = LegacyWearStates.Both;
            else if (PlacementL == PlacementStates.Wearing)
                WearState = LegacyWearStates.L;
            else if (PlacementR == PlacementStates.Wearing)
                WearState = LegacyWearStates.R;
            else
                WearState = LegacyWearStates.None;

            BatteryCase = msg.Payload[7];

            if (TargetModel == Models.BudsPlus)
            {
                AmbientSoundEnabled = Convert.ToBoolean(msg.Payload[8]);
                AmbientSoundVolume = msg.Payload[9];

                AdjustSoundSync = msg.Payload[10] == 1;
                EqualizerMode = msg.Payload[11];
                TouchpadLock = Convert.ToBoolean(msg.Payload[12]);

                TouchpadOptionL = DeviceSpec.TouchMap.FromByte((byte)((msg.Payload[13] & 240) >> 4));
                TouchpadOptionR = DeviceSpec.TouchMap.FromByte((byte)(msg.Payload[13] & 15));

                OutsideDoubleTap = msg.Payload[14] == 1;

                var colorL = BitConverter.ToInt16(msg.Payload, 15);
                ColorL = ColorsExtensions.IsDefined((Colors)colorL) ? (Colors)colorL : Colors.Unknown;
                var colorR = BitConverter.ToInt16(msg.Payload, 17);
                ColorR = ColorsExtensions.IsDefined((Colors)colorR) ? (Colors)colorR : Colors.Unknown;
                
                if (Revision >= 8)
                {
                    SideToneEnabled = msg.Payload[19] == 1;
                }

                if (Revision >= 9)
                {
                    ExtraHighAmbientEnabled = msg.Payload[20] == 1;
                }

                if (Revision >= 11)
                {
                    SeamlessConnectionEnabled = msg.Payload[21] == 0;
                }
                
                if (Revision >= 12)
                {
                    FmmRevision = msg.Payload[22];
                }
                
                if (Revision >= 13)
                {
                    CallPathControl = msg.Payload[23] == 0;
                }
            }
            else if (TargetModel == Models.BudsLive)
            {
                AdjustSoundSync = msg.Payload[8] == 1;
                EqualizerMode = msg.Payload[9];
                TouchpadLock = Convert.ToBoolean(msg.Payload[10]);

                TouchpadOptionL = DeviceSpec.TouchMap.FromByte((byte)((msg.Payload[11] & 240) >> 4));
                TouchpadOptionR = DeviceSpec.TouchMap.FromByte((byte)(msg.Payload[11] & 15));

                NoiseCancelling = msg.Payload[12] == 1;
                VoiceWakeUp = msg.Payload[13] == 1;

                var colorL = BitConverter.ToInt16(msg.Payload, 14);
                ColorL = ColorsExtensions.IsDefined((Colors)colorL) ? (Colors)colorL : Colors.Unknown;
                var colorR = BitConverter.ToInt16(msg.Payload, 16);
                ColorR = ColorsExtensions.IsDefined((Colors)colorR) ? (Colors)colorR : Colors.Unknown;
                
                VoiceWakeUpLang = msg.Payload[18];

                if (Revision >= 3)
                {
                    SeamlessConnectionEnabled = msg.Payload[19] == 0;
                }

                if (Revision >= 4)
                {
                    FmmRevision = msg.Payload[20];
                }

                if (Revision >= 5)
                {
                    RelieveAmbient = msg.Payload[21] == 1;
                }

                if (Revision >= 7)
                {
                    HearingEnhancements = msg.Payload[22];
                }

                if (Revision >= 8)
                {
                    CallPathControl = msg.Payload[23] == 0;
                }
                
                if (Revision >= 9)
                {
                    SpatialAudio = msg.Payload[24] == 1;
                }
            }
            else if (TargetModel == Models.BudsPro)
            {
                AdjustSoundSync = msg.Payload[8] == 1;
                EqualizerMode = msg.Payload[9];
                TouchpadLock = Convert.ToBoolean(msg.Payload[10]);

                TouchpadOptionL = DeviceSpec.TouchMap.FromByte((byte)((msg.Payload[11] & 240) >> 4));
                TouchpadOptionR = DeviceSpec.TouchMap.FromByte((byte)(msg.Payload[11] & 15));

                NoiseControlMode = (NoiseControlModes)msg.Payload[12];
                VoiceWakeUp = msg.Payload[13] == 1;

                var colorL = BitConverter.ToInt16(msg.Payload, 14);
                ColorL = ColorsExtensions.IsDefined((Colors)colorL) ? (Colors)colorL : Colors.Unknown;
                var colorR = BitConverter.ToInt16(msg.Payload, 16);
                ColorR = ColorsExtensions.IsDefined((Colors)colorR) ? (Colors)colorR : Colors.Unknown;

                VoiceWakeUpLang = msg.Payload[18];
                SeamlessConnectionEnabled = msg.Payload[19] == 0;
                FmmRevision = msg.Payload[20];

                NoiseControlTouchOff = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 0) == 1;
                NoiseControlTouchAmbient = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 1) == 2;
                NoiseControlTouchAnc = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 2) == 4;

                if (Revision >= 8)
                {
                    NoiseControlTouchLeftOff = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 4) == 16;
                    NoiseControlTouchLeftAmbient = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 5) == 32;
                    NoiseControlTouchLeftAnc = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 6) == 64;
                }

                if (Revision < 3)
                {
                    ExtraHighAmbientEnabled = msg.Payload[22] == 1;
                }
                else
                {
                    SpeakSeamlessly = msg.Payload[22] == 1;
                }

                AmbientSoundVolume = msg.Payload[23];
                NoiseReductionLevel = msg.Payload[24];
                AutoSwitchAudioOutput = msg.Payload[25] == 1;
                DetectConversations = msg.Payload[26] == 1;
                DetectConversationsDuration = msg.Payload[27];
                if (DetectConversationsDuration > 2)
                {
                    DetectConversationsDuration = 1;
                }

                if (Revision > 1)
                {
                    SpatialAudio = msg.Payload[28] == 1;
                }

                if (Revision >= 5)
                {
                    HearingEnhancements = msg.Payload[29];
                }

                if (Revision >= 6)
                {
                    ExtraHighAmbientEnabled = msg.Payload[30] == 1;
                }

                if (Revision >= 7)
                {
                    OutsideDoubleTap = msg.Payload[31] == 1;
                }

                if (Revision >= 8)
                {
                    NoiseControlsWithOneEarbud = msg.Payload[32] == 1;
                    AmbientCustomVolumeOn = msg.Payload[33] == 1;
                    AmbientCustomVolumeLeft = ByteArrayUtils.ValueOfLeft(msg.Payload[34]);
                    AmbientCustomVolumeRight = ByteArrayUtils.ValueOfRight(msg.Payload[34]);
                    AmbientCustomSoundTone = msg.Payload[35];
                }

                if (Revision >= 9)
                {
                    SideToneEnabled = msg.Payload[36] == 1;
                }
                
                if (Revision >= 10)
                {
                    CallPathControl = msg.Payload[37] == 0;
                }
            }
            else if (TargetModel == Models.Buds2)
            {
                AdjustSoundSync = msg.Payload[8] == 1;
                EqualizerMode = msg.Payload[9];

                if (Revision < 4)
                {
                    TouchpadLock = msg.Payload[10] == 1;
                }
                else
                {
                    TouchHoldOn = (msg.Payload[10] & (1 << 0)) == 1;
                    TripleTapOn = (msg.Payload[10] & (1 << 1)) == 2;
                    DoubleTapOn = (msg.Payload[10] & (1 << 2)) == 4;
                    SingleTapOn = (msg.Payload[10] & (1 << 3)) == 8;
                    TouchpadLock = (msg.Payload[10] & (1 << 7)) != 128;

                    if (Revision >= 7)
                    {
                        TouchHoldOnForCallOn = (msg.Payload[10] & (1 << 5)) == 32;
                        DoubleTapForCallOn = (msg.Payload[10] & (1 << 4)) == 16;
                    }
                }

                TouchpadOptionL = DeviceSpec.TouchMap.FromByte((byte)((msg.Payload[11] & 240) >> 4));
                TouchpadOptionR = DeviceSpec.TouchMap.FromByte((byte)(msg.Payload[11] & 15));

                NoiseControlMode = (NoiseControlModes)msg.Payload[12];
                VoiceWakeUp = msg.Payload[13] == 1;
                
                var colorL = BitConverter.ToInt16(msg.Payload, 14);
                ColorL = ColorsExtensions.IsDefined((Colors)colorL) ? (Colors)colorL : Colors.Unknown;
                var colorR = BitConverter.ToInt16(msg.Payload, 16);
                ColorR = ColorsExtensions.IsDefined((Colors)colorR) ? (Colors)colorR : Colors.Unknown;
 
                VoiceWakeUpLang = msg.Payload[18];
                SeamlessConnectionEnabled = msg.Payload[19] == 0;
                FmmRevision = msg.Payload[20];

                NoiseControlTouchOff = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 0) == 1;
                NoiseControlTouchAmbient = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 1) == 2;
                NoiseControlTouchAnc = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 2) == 4;

                if (Revision >= 5)
                {
                    NoiseControlTouchLeftOff = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 4) == 16;
                    NoiseControlTouchLeftAmbient = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 5) == 32;
                    NoiseControlTouchLeftAnc = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 6) == 64;
                }

                SpeakSeamlessly = msg.Payload[22] == 1;
                AmbientSoundVolume = msg.Payload[23];
                NoiseReductionLevel = msg.Payload[24];
                HearingEnhancements = msg.Payload[25];
                ExtraHighAmbientEnabled = msg.Payload[26] == 1;

                if (Revision >= 2)
                {
                    TouchType = msg.Payload[27];
                }

                if (Revision >= 3)
                {
                    NoiseControlsWithOneEarbud = msg.Payload[28] == 1;
                }

                if (Revision >= 5)
                {
                    AmbientCustomVolumeOn = msg.Payload[29] == 1;
                    AmbientCustomVolumeLeft = ByteArrayUtils.ValueOfLeft(msg.Payload[30]);
                    AmbientCustomVolumeRight = ByteArrayUtils.ValueOfRight(msg.Payload[30]);
                    AmbientCustomSoundTone = msg.Payload[31];
                    OutsideDoubleTap = msg.Payload[32] == 1;
                }

                if (Revision >= 6)
                {
                    SideToneEnabled = msg.Payload[33] == 1;
                }
                
                if (Revision >= 7)
                {
                    CallPathControl = msg.Payload[34] == 0;
                }
                
                if (Revision >= 8)
                {
                    SpatialAudio = msg.Payload[35] == 1;
                }

                if (Revision >= 10)
                {
                    var chargingStatus = msg.Payload[36];
                    IsLeftCharging = ByteArrayUtils.ValueOfBinaryDigit(chargingStatus, 4) == 16;
                    IsRightCharging = ByteArrayUtils.ValueOfBinaryDigit(chargingStatus, 2) == 4;
                    IsCaseCharging = ByteArrayUtils.ValueOfBinaryDigit(chargingStatus, 0) == 1;
                }
            }
            else if (TargetModel == Models.Buds2Pro)
            {
                AdjustSoundSync = msg.Payload[8] == 1;
                EqualizerMode = msg.Payload[9];

                TouchHoldOn = (msg.Payload[10] & (1 << 0)) == 1;
                TripleTapOn = (msg.Payload[10] & (1 << 1)) == 2;
                DoubleTapOn = (msg.Payload[10] & (1 << 2)) == 4;
                SingleTapOn = (msg.Payload[10] & (1 << 3)) == 8;
                TouchHoldOnForCallOn = (msg.Payload[10] & (1 << 5)) == 32;
                DoubleTapForCallOn = (msg.Payload[10] & (1 << 4)) == 16;
                TouchpadLock = (msg.Payload[10] & (1 << 7)) != 128;

                TouchpadOptionL = DeviceSpec.TouchMap.FromByte((byte)((msg.Payload[11] & 240) >> 4));
                TouchpadOptionR = DeviceSpec.TouchMap.FromByte((byte)(msg.Payload[11] & 15));

                NoiseControlMode = (NoiseControlModes)msg.Payload[12];
                VoiceWakeUp = msg.Payload[13] == 1;

                var colorL = BitConverter.ToInt16(msg.Payload, 14);
                ColorL = ColorsExtensions.IsDefined((Colors)colorL) ? (Colors)colorL : Colors.Unknown;
                var colorR = BitConverter.ToInt16(msg.Payload, 16);
                ColorR = ColorsExtensions.IsDefined((Colors)colorR) ? (Colors)colorR : Colors.Unknown;

                VoiceWakeUpLang = msg.Payload[18];
                SeamlessConnectionEnabled = msg.Payload[19] == 0;
                FmmRevision = msg.Payload[20];

                NoiseControlTouchOff = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 0) == 1;
                NoiseControlTouchAmbient = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 1) == 2;
                NoiseControlTouchAnc = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 2) == 4;

                NoiseControlTouchLeftOff = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 4) == 16;
                NoiseControlTouchLeftAmbient = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 5) == 32;
                NoiseControlTouchLeftAnc = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 6) == 64;
  
                SpeakSeamlessly = msg.Payload[22] == 1;
                AmbientSoundVolume = msg.Payload[23];
                NoiseReductionLevel = msg.Payload[24];
                HearingEnhancements = msg.Payload[25];
                    
                DetectConversations = msg.Payload[26] == 1;
                DetectConversationsDuration = msg.Payload[27];
                if (DetectConversationsDuration > 2)
                {
                    DetectConversationsDuration = 1;
                }
                    
                NoiseControlsWithOneEarbud = msg.Payload[28] == 1;
                    
                AmbientCustomVolumeOn = msg.Payload[29] == 1;
                AmbientCustomVolumeLeft = ByteArrayUtils.ValueOfLeft(msg.Payload[30]);
                AmbientCustomVolumeRight = ByteArrayUtils.ValueOfRight(msg.Payload[30]);
                AmbientCustomSoundTone = msg.Payload[31];
                OutsideDoubleTap = msg.Payload[32] == 1;
                SideToneEnabled = msg.Payload[33] == 1;

                using var reader = new BinaryReader(new MemoryStream(msg.Payload, 34, msg.Payload.Length - 34));
                
                if (Revision >= 1)
                {
                    CallPathControl = reader.ReadByte() == 0;
                    SpatialAudio = reader.ReadBoolean();
                    CustomizeConversationBoost = reader.ReadBoolean();
                    CustomizeNoiseReductionLevel = reader.ReadByte();
                    NeckStretchCalibration = reader.ReadBoolean();
                    BixbyKeyword = reader.ReadByte();
                    HearingTestValue = reader.ReadByte();
                }

                if (Revision >= 3)
                {
                    AutoAdjustSound = reader.ReadBoolean();
                }
                else
                {
                    AutoAdjustSound = HearingTestValue is not (0 or 1);
                }
                
                if(Revision >= 8)
                    SpatialAudioHeadTracking = reader.ReadBoolean();

                if (Revision >= 11)
                {
                    var chargingStatus = reader.ReadByte();
                    IsLeftCharging = ByteArrayUtils.ValueOfBinaryDigit(chargingStatus, 4) == 16;
                    IsRightCharging = ByteArrayUtils.ValueOfBinaryDigit(chargingStatus, 2) == 4;
                    IsCaseCharging = ByteArrayUtils.ValueOfBinaryDigit(chargingStatus, 0) == 1;
                }

                if (Revision >= 13)
                {
                    ExtraClearCallSound = reader.ReadBoolean();
                    if(reader.PeekChar() != -1) // Check for EOF
                        ExtraHighAmbientEnabled = reader.ReadBoolean();
                }
            }
            else if (TargetModel == Models.BudsFe)
            {
                AdjustSoundSync = msg.Payload[8] == 1;
                EqualizerMode = msg.Payload[9];

                TouchHoldOn = (msg.Payload[10] & (1 << 0)) == 1;
                TripleTapOn = (msg.Payload[10] & (1 << 1)) == 2;
                DoubleTapOn = (msg.Payload[10] & (1 << 2)) == 4;
                SingleTapOn = (msg.Payload[10] & (1 << 3)) == 8;
                TouchHoldOnForCallOn = (msg.Payload[10] & (1 << 5)) == 32;
                DoubleTapForCallOn = (msg.Payload[10] & (1 << 4)) == 16;
                TouchpadLock = (msg.Payload[10] & (1 << 7)) != 128;

                TouchpadOptionL = DeviceSpec.TouchMap.FromByte((byte)((msg.Payload[11] & 240) >> 4));
                TouchpadOptionR = DeviceSpec.TouchMap.FromByte((byte)(msg.Payload[11] & 15));

                NoiseControlMode = (NoiseControlModes)msg.Payload[12];
                VoiceWakeUp = msg.Payload[13] == 1;

                var colorL = BitConverter.ToInt16(msg.Payload, 14);
                ColorL = ColorsExtensions.IsDefined((Colors)colorL) ? (Colors)colorL : Colors.Unknown;
                var colorR = BitConverter.ToInt16(msg.Payload, 16);
                ColorR = ColorsExtensions.IsDefined((Colors)colorR) ? (Colors)colorR : Colors.Unknown;

                VoiceWakeUpLang = msg.Payload[18];
                SeamlessConnectionEnabled = msg.Payload[19] == 0;
                FmmRevision = msg.Payload[20];

                NoiseControlTouchOff = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 0) == 1;
                NoiseControlTouchAmbient = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 1) == 2;
                NoiseControlTouchAnc = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 2) == 4;

                NoiseControlTouchLeftOff = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 4) == 16;
                NoiseControlTouchLeftAmbient = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 5) == 32;
                NoiseControlTouchLeftAnc = ByteArrayUtils.ValueOfBinaryDigit(msg.Payload[21], 6) == 64;
  
                SpeakSeamlessly = msg.Payload[22] == 1;
                AmbientSoundVolume = msg.Payload[23];
                NoiseReductionLevel = msg.Payload[24];
                HearingEnhancements = msg.Payload[25];
                    
                DetectConversations = msg.Payload[26] == 1;
                DetectConversationsDuration = msg.Payload[27];
                if (DetectConversationsDuration > 2)
                {
                    DetectConversationsDuration = 1;
                }
                    
                NoiseControlsWithOneEarbud = msg.Payload[28] == 1;
                    
                AmbientCustomVolumeOn = msg.Payload[29] == 1;
                AmbientCustomVolumeLeft = ByteArrayUtils.ValueOfLeft(msg.Payload[30]);
                AmbientCustomVolumeRight = ByteArrayUtils.ValueOfRight(msg.Payload[30]);
                AmbientCustomSoundTone = msg.Payload[31];
                OutsideDoubleTap = msg.Payload[32] == 1;
                SideToneEnabled = msg.Payload[33] == 1;

                using var reader = new BinaryReader(new MemoryStream(msg.Payload, 34, msg.Payload.Length - 34));
            
                CallPathControl = reader.ReadByte() == 0;
                SpatialAudio = reader.ReadBoolean();
                CustomizeConversationBoost = reader.ReadBoolean();
                CustomizeNoiseReductionLevel = reader.ReadByte();
                NeckStretchCalibration = reader.ReadBoolean();
                BixbyKeyword = reader.ReadByte();
                HearingTestValue = reader.ReadByte();
                AutoAdjustSound = HearingTestValue is not (0 or 1);

                _ = reader.ReadByte(); // Unused amplifyAmbientSound value
                SpatialAudioHeadTracking = reader.ReadBoolean();
                
                var chargingStatus = reader.ReadByte();
                IsLeftCharging = ByteArrayUtils.ValueOfBinaryDigit(chargingStatus, 4) == 16;
                IsRightCharging = ByteArrayUtils.ValueOfBinaryDigit(chargingStatus, 2) == 4;
                IsCaseCharging = ByteArrayUtils.ValueOfBinaryDigit(chargingStatus, 0) == 1;
            }
        }
        
        if (DeviceSpec.Supports(Features.ChargingState, Revision))
        {
            if(IsLeftCharging)
                PlacementL = PlacementStates.Charging;
            if(IsRightCharging)
                PlacementR = PlacementStates.Charging;
        }
    }
}