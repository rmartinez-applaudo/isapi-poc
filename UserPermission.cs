using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace IsapiPoC.Models
{
    [XmlRoot("UserPermission", Namespace = "http://www.hikvision.com/ver20/XMLSchema")]
    public class UserPermission
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("userID")]
        public int UserID { get; set; }

        [XmlElement("userType")]
        public string UserType { get; set; }

        [XmlElement("remotePermission")]
        public RemotePermission RemotePermission { get; set; }

        [XmlElement("localPermission")]
        public LocalPermission LocalPermission { get; set; }
    }

    public class LocalPermission
    {
        [XmlElement("backup")]
        public bool Backup { get; set; }

        [XmlElement("record")]
        public bool Record { get; set; }

        [XmlElement("playBack")]
        public bool PlayBack { get; set; }

        [XmlElement("preview")]
        public bool Preview { get; set; }

        [XmlArray("videoChannelPermissionList")]
        [XmlArrayItem("videoChannelPermission")]
        public List<LocalVideoChannelPermission> VideoChannelPermissionList { get; set; }

        [XmlElement("ptzControl")]
        public bool PtzControl { get; set; }

        [XmlArray("ptzChannelPermissionList")]
        [XmlArrayItem("ptzChannelPermission")]
        public List<LocalPtzChannelPermission> PtzChannelPermissionList { get; set; }

        [XmlElement("logOrStateCheck")]
        public bool LogOrStateCheck { get; set; }

        [XmlElement("parameterConfig")]
        public bool ParameterConfig { get; set; }

        [XmlElement("restartOrShutdown")]
        public bool RestartOrShutdown { get; set; }

        [XmlElement("upgrade")]
        public bool Upgrade { get; set; }

        [XmlElement("manageChannel")]
        public bool ManageChannel { get; set; }

        [XmlElement("AIModelManagement")]
        public bool AIModelManagement { get; set; }

        [XmlElement("AITaskManagement")]
        public bool AITaskManagement { get; set; }

        [XmlElement("subSysOrZoneArm")]
        public bool SubSysOrZoneArm { get; set; }

        [XmlElement("subSysOrZoneDisarm")]
        public bool SubSysOrZoneDisarm { get; set; }

        [XmlElement("operateOutput")]
        public bool OperateOutput { get; set; }

        [XmlArray("subSystemList")]
        [XmlArrayItem("subSystem")]
        public List<int> SubSystemList { get; set; }

        [XmlElement("localFileMgr")]
        public bool LocalFileMgr { get; set; }

        [XmlElement("LEDConfig")]
        public bool LEDConfig { get; set; }

        [XmlElement("logMgr")]
        public bool LogMgr { get; set; }

        [XmlElement("TIPConfig")]
        public bool TIPConfig { get; set; }

        [XmlElement("securityFunctionCfg")]
        public bool SecurityFunctionCfg { get; set; }

        [XmlElement("netWorkCfg")]
        public bool NetWorkCfg { get; set; }

        [XmlElement("ISUPAccess")]
        public bool ISUPAccess { get; set; }

        [XmlElement("timeMgr")]
        public bool TimeMgr { get; set; }

        [XmlElement("HDDMgr")]
        public bool HDDMgr { get; set; }

        [XmlElement("securitySystemMaintenance")]
        public bool SecuritySystemMaintenance { get; set; }

        [XmlElement("securityCheckingPicExport")]
        public bool SecurityCheckingPicExport { get; set; }

        [XmlElement("securityCheckingPicDelete")]
        public bool SecurityCheckingPicDelete { get; set; }

        [XmlArray("operationScheduleList")]
        [XmlArrayItem("operationSchedule")]
        public List<OperationSchedule> OperationScheduleList { get; set; }
    }

    public class LocalVideoChannelPermission
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("playBack")]
        public bool PlayBack { get; set; }

        [XmlElement("preview")]
        public bool Preview { get; set; }

        [XmlElement("record")]
        public bool Record { get; set; }

        [XmlElement("backup")]
        public bool Backup { get; set; }

        [XmlElement("playBackDoubleVerification")]
        public bool PlayBackDoubleVerification { get; set; }

        [XmlElement("backupDoubleVerification")]
        public bool BackupDoubleVerification { get; set; }
    }

    public class LocalPtzChannelPermission
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("ptzControl")]
        public bool PtzControl { get; set; }
    }

    public class OperationSchedule
    {
        [XmlElement("operationScheduleEnabled")]
        public bool OperationScheduleEnabled { get; set; }

        [XmlElement("operationDetailItem")]
        public string OperationDetailItem { get; set; }

        [XmlElement("timeRange")]
        public TimeRange TimeRange { get; set; }
    }

    public class TimeRange
    {
        [XmlElement("beginTime")]
        public string BeginTime { get; set; }

        [XmlElement("endTime")]
        public string EndTime { get; set; }
    }

    public class RemotePermission
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("playBack")]
        public bool PlayBack { get; set; }

        [XmlElement("preview")]
        public bool Preview { get; set; }

        [XmlElement("record")]
        public bool Record { get; set; }

        [XmlArray("videoChannelPermissionList")]
        [XmlArrayItem("videoChannelPermission")]
        public List<VideoChannelPermission> VideoChannelPermissionList { get; set; }

        [XmlElement("ptzControl")]
        public bool PtzControl { get; set; }

        [XmlArray("ptzChannelPermissionList")]
        [XmlArrayItem("ptzChannelPermission")]
        public List<PtzChannelPermission> PtzChannelPermissionList { get; set; }

        [XmlElement("upgrade")]
        public bool Upgrade { get; set; }

        [XmlElement("parameterConfig")]
        public bool ParameterConfig { get; set; }

        [XmlElement("restartOrShutdown")]
        public bool RestartOrShutdown { get; set; }

        [XmlElement("logOrStateCheck")]
        public bool LogOrStateCheck { get; set; }

        [XmlElement("voiceTalk")]
        public bool VoiceTalk { get; set; }

        [XmlElement("transParentChannel")]
        public bool TransParentChannel { get; set; }

        [XmlElement("contorlLocalOut")]
        public bool ContorlLocalOut { get; set; }

        [XmlElement("alarmOutOrUpload")]
        public bool AlarmOutOrUpload { get; set; }
    }

    public class VideoChannelPermission
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("preview")]
        public bool Preview { get; set; }

        [XmlElement("playBack")]
        public bool PlayBack { get; set; }

        [XmlElement("record")]
        public bool Record { get; set; }
    }

    public class PtzChannelPermission
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("ptzControl")]
        public bool PtzControl { get; set; }
    }
}
