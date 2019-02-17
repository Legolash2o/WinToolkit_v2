namespace WinToolkitDLL
{
    /// <summary>
    ///     Used for specify x64 or x86 values.
    /// </summary>
    public enum Architecture
    {
        /// <summary>
        ///     64-bit Architecture.
        ///     Value in XML is 9.
        /// </summary>
        X64,

        /// <summary>
        ///     32-bit Architecture.
        ///     Value in XML is 0.
        /// </summary>
        X86,

        /// <summary>
        ///     Item is both 32-bit and 64-bit
        /// </summary>
        Mix
    }

    /// <summary>
    ///     Status of a mounted image.
    /// </summary>
    public enum WimImageStatus
    {
        /// <summary>
        ///     Used by images which are not mounted.
        /// </summary>
        NotApplicable,

        /// <summary>
        ///     Everything is working as expected.
        /// </summary>
        Ok,

        /// <summary>
        ///     Corrupted - Need to discard.
        /// </summary>
        Corrupt,

        /// <summary>
        ///     Image is still mounting.
        /// </summary>
        Mounting,

        /// <summary>
        ///     Image is still unmounting.
        /// </summary>
        Unmounting,

        /// <summary>
        ///     The image needs remounting.
        /// </summary>
        NeedsRemount
    }

    /// <summary>
    ///     Edition of the windows image.
    /// </summary>
    public enum WimImageFlag
    {
        /// <summary>
        ///     Windows Starter Edition
        /// </summary>
        Starter,

        /// <summary>
        ///     Windows HomeBasic Edition
        /// </summary>
        HomeBasic,

        /// <summary>
        ///     Windows HomePremium Edition
        /// </summary>
        HomePremium,

        /// <summary>
        ///     Windows Professional Edition
        /// </summary>
        Professional,

        /// <summary>
        ///     Windwos Professional Edition with Windows Media Center
        /// </summary>
        // ReSharper disable once InconsistentNaming
        ProfessionalWMC,

        /// <summary>
        ///     Windows Ultimate Edition.
        /// </summary>
        Ultimate,

        /// <summary>
        ///     Windows Business Edition
        /// </summary>
        Business,

        /// <summary>
        ///     Windows Core Edition
        /// </summary>
        Core,

        /// <summary>
        ///     Windows Enterprise Edition
        /// </summary>
        Enterprise,

        /// <summary>
        ///     Windows Server Standard Edition
        /// </summary>
        ServerStandard,

        /// <summary>
        ///     Windows Server Enterprise Edition
        /// </summary>
        ServerEnterprise,

        /// <summary>
        ///     Windows Server Datacenter Edition
        /// </summary>
        ServerDatacenter
    }

    /// <summary>
    ///     Used to determine if an update supports
    ///     LDR/QFE Mode or not.
    /// </summary>
    public enum UpdateType
    {
        /// <summary>
        ///     Normal Windows update.
        /// </summary>
        GDR,

        /// <summary>
        ///     LDR Windows update.
        /// </summary>
        LDR,

        /// <summary>
        ///     Not know whether or not it is
        ///     LDR or GDR yet.
        /// </summary>
        Unknown
    }

    /// <summary>
    ///     List of supported Windows versions
    /// </summary>
    public enum WindowsVersion
    {
        /// <summary>
        ///     Windows Vista
        /// </summary>
        Vista,

        /// <summary>
        ///     Windows 7
        /// </summary>
        Seven,

        /// <summary>
        ///     Windows 8.0
        /// </summary>
        Eight0,

        /// <summary>
        ///     Windows 8.1
        /// </summary>
        Eight1,

        /// <summary>
        ///     Windows 10
        /// </summary>
        Ten
    }

    public enum Status
    {
        /// <summary>
        ///     No status.
        /// </summary>
        None,

        /// <summary>
        ///     The item is currently being worked on.
        /// </summary>
        Working,

        /// <summary>
        ///     An error occured.
        /// </summary>
        Failed,

        /// <summary>
        ///     Everything worked as expected.
        /// </summary>
        Success,

        /// <summary>
        ///     This item can't be worked with.
        /// </summary>
        Incompatible
    }

    /// <summary>
    ///     A USB/HDD device drive format.
    /// </summary>
    public enum DriveFormat
    {
        /// <summary>
        ///     Default for Windows XP or later.
        /// </summary>
        NTFS,

        /// <summary>
        ///     Old format with 2GB file limit.
        /// </summary>
        FAT,

        /// <summary>
        ///     General format with 4GB file limit.
        /// </summary>
        FAT32,

        /// <summary>
        ///     FAT64 format with 16EB file limit. Not standard.
        /// </summary>
        exFAT,

        /// <summary>
        ///     Drive has not been formatted.
        /// </summary>
        RAW,

        /// <summary>
        ///     Unknown file system. Could be Mac or Linux.
        /// </summary>
        Unknown
    }

    /// <summary>
    ///     A USB/HDD boot information.
    /// </summary>
    public enum BootRecord
    {
        /// <summary>
        ///     Used for BIOS computers.
        /// </summary>
        MBR,

        /// <summary>
        ///     Used of UEFI computers.
        /// </summary>
        GPT,

        /// <summary>
        ///     Mixture of BIOS and UEFI.
        /// </summary>
        Hybrid,

        /// <summary>
        ///     The device boot record has not been set yet.
        /// </summary>
        RAW
    }

    /// <summary>
    ///     Set different priorities for different tasks.
    /// </summary>
    public enum Priority
    {
        /// <summary>
        ///     Highest Priority - Unhandled Errors
        /// </summary>
        Highest,

        /// <summary>
        ///     High Priority
        /// </summary>
        High,

        /// <summary>
        ///     Normal Priority
        /// </summary>
        Normal,

        /// <summary>
        ///     Low Priority
        /// </summary>
        Low,

        /// <summary>
        ///     Lowest Priority - Minor Errors
        /// </summary>
        Lowest
    }
}