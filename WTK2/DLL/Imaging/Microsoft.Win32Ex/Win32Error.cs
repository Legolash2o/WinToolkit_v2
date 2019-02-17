namespace Microsoft.Win32
{
    /// <summary>
    ///     Provides access to a list of Win32 error codes.
    /// </summary>
    public static class Win32Error
    {
        #region 0 - 499

        /// <summary>
        ///     The operation completed successfully.
        /// </summary>
        public const int ERROR_SUCCESS = 0x00000000; // 0

        /// <summary>
        ///     Incorrect function.
        /// </summary>
        public const int ERROR_INVALID_FUNCTION = 0x00000001; // 1

        /// <summary>
        ///     The system cannot find the file specified.
        /// </summary>
        public const int ERROR_FILE_NOT_FOUND = 0x00000002; // 2

        /// <summary>
        ///     The system cannot find the path specified.
        /// </summary>
        public const int ERROR_PATH_NOT_FOUND = 0x00000003; // 3

        /// <summary>
        ///     The system cannot open the file.
        /// </summary>
        public const int ERROR_TOO_MANY_OPEN_FILES = 0x00000004; // 4

        /// <summary>
        ///     Access is denied.
        /// </summary>
        public const int ERROR_ACCESS_DENIED = 0x00000005; // 5

        /// <summary>
        ///     The handle is invalid.
        /// </summary>
        public const int ERROR_INVALID_HANDLE = 0x00000006; // 6

        /// <summary>
        ///     The storage control blocks were destroyed.
        /// </summary>
        public const int ERROR_ARENA_TRASHED = 0x00000007; // 7

        /// <summary>
        ///     Not enough storage is available to process this command.
        /// </summary>
        public const int ERROR_NOT_ENOUGH_MEMORY = 0x00000008; // 8

        /// <summary>
        ///     The storage control block address is invalid.
        /// </summary>
        public const int ERROR_INVALID_BLOCK = 0x00000009; // 9

        /// <summary>
        ///     The environment is incorrect.
        /// </summary>
        public const int ERROR_BAD_ENVIRONMENT = 0x0000000A; // 10

        /// <summary>
        ///     An attempt was made to load a program with an incorrect format.
        /// </summary>
        public const int ERROR_BAD_FORMAT = 0x0000000B; // 11

        /// <summary>
        ///     The access code is invalid.
        /// </summary>
        public const int ERROR_INVALID_ACCESS = 0x0000000C; // 12

        /// <summary>
        ///     The data is invalid.
        /// </summary>
        public const int ERROR_INVALID_DATA = 0x0000000D; // 13

        /// <summary>
        ///     Not enough storage is available to complete this operation.
        /// </summary>
        public const int ERROR_OUTOFMEMORY = 0x0000000E; // 14

        /// <summary>
        ///     The system cannot find the drive specified.
        /// </summary>
        public const int ERROR_INVALID_DRIVE = 0x0000000F; // 15

        /// <summary>
        ///     The directory cannot be removed.
        /// </summary>
        public const int ERROR_CURRENT_DIRECTORY = 0x00000010; // 16

        /// <summary>
        ///     The system cannot move the file to a different disk drive.
        /// </summary>
        public const int ERROR_NOT_SAME_DEVICE = 0x00000011; // 17

        /// <summary>
        ///     There are no more files.
        /// </summary>
        public const int ERROR_NO_MORE_FILES = 0x00000012; // 18

        /// <summary>
        ///     The media is write protected.
        /// </summary>
        public const int ERROR_WRITE_PROTECT = 0x00000013; // 19

        /// <summary>
        ///     The system cannot find the device specified.
        /// </summary>
        public const int ERROR_BAD_UNIT = 0x00000014; // 20

        /// <summary>
        ///     The device is not ready.
        /// </summary>
        public const int ERROR_NOT_READY = 0x00000015; // 21

        /// <summary>
        ///     The device does not recognize the command.
        /// </summary>
        public const int ERROR_BAD_COMMAND = 0x00000016; // 22

        /// <summary>
        ///     Data error (cyclic redundancy check).
        /// </summary>
        public const int ERROR_CRC = 0x00000017; // 23

        /// <summary>
        ///     The program issued a command but the command length is incorrect.
        /// </summary>
        public const int ERROR_BAD_LENGTH = 0x00000018; // 24

        /// <summary>
        ///     The drive cannot locate a specific area or track on the disk.
        /// </summary>
        public const int ERROR_SEEK = 0x00000019; // 25

        /// <summary>
        ///     The specified disk or diskette cannot be accessed.
        /// </summary>
        public const int ERROR_NOT_DOS_DISK = 0x0000001A; // 26

        /// <summary>
        ///     The drive cannot find the sector requested.
        /// </summary>
        public const int ERROR_SECTOR_NOT_FOUND = 0x0000001B; // 27

        /// <summary>
        ///     The printer is out of paper.
        /// </summary>
        public const int ERROR_OUT_OF_PAPER = 0x0000001C; // 28

        /// <summary>
        ///     The system cannot write to the specified device.
        /// </summary>
        public const int ERROR_WRITE_FAULT = 0x0000001D; // 29

        /// <summary>
        ///     The system cannot read from the specified device.
        /// </summary>
        public const int ERROR_READ_FAULT = 0x0000001E; // 30

        /// <summary>
        ///     A device attached to the system is not functioning.
        /// </summary>
        public const int ERROR_GEN_FAILURE = 0x0000001F; // 31

        /// <summary>
        ///     The process cannot access the file because it is being used by another process.
        /// </summary>
        public const int ERROR_SHARING_VIOLATION = 0x00000020; // 32

        /// <summary>
        ///     The process cannot access the file because another process has locked a portion of the file.
        /// </summary>
        public const int ERROR_LOCK_VIOLATION = 0x00000021; // 33

        /// <summary>
        ///     The wrong diskette is in the drive. Insert %2 (Volume Serial Number: %3) into drive %1.
        /// </summary>
        public const int ERROR_WRONG_DISK = 0x00000022; // 34

        /// <summary>
        ///     Too many files opened for sharing.
        /// </summary>
        public const int ERROR_SHARING_BUFFER_EXCEEDED = 0x00000024; // 36

        /// <summary>
        ///     Reached the end of the file.
        /// </summary>
        public const int ERROR_HANDLE_EOF = 0x00000026; // 38

        /// <summary>
        ///     The disk is full.
        /// </summary>
        public const int ERROR_HANDLE_DISK_FULL = 0x00000027; // 39

        /// <summary>
        ///     The request is not supported.
        /// </summary>
        public const int ERROR_NOT_SUPPORTED = 0x00000032; // 50

        /// <summary>
        ///     Windows cannot find the network path. Verify that the network path is correct and the destination computer is not
        ///     busy or turned off. If Windows still cannot find the network path, contact your network administrator.
        /// </summary>
        public const int ERROR_REM_NOT_LIST = 0x00000033; // 51

        /// <summary>
        ///     You were not connected because a duplicate name exists on the network. If joining a domain, go to System in Control
        ///     Panel to change the computer name and try again. If joining a workgroup, choose another workgroup name.
        /// </summary>
        public const int ERROR_DUP_NAME = 0x00000034; // 52

        /// <summary>
        ///     The network path was not found.
        /// </summary>
        public const int ERROR_BAD_NETPATH = 0x00000035; // 53

        /// <summary>
        ///     The network is busy.
        /// </summary>
        public const int ERROR_NETWORK_BUSY = 0x00000036; // 54

        /// <summary>
        ///     The specified network resource or device is no longer available.
        /// </summary>
        public const int ERROR_DEV_NOT_EXIST = 0x00000037; // 55

        /// <summary>
        ///     The network BIOS command limit has been reached.
        /// </summary>
        public const int ERROR_TOO_MANY_CMDS = 0x00000038; // 56

        /// <summary>
        ///     A network adapter hardware error occurred.
        /// </summary>
        public const int ERROR_ADAP_HDW_ERR = 0x00000039; // 57

        /// <summary>
        ///     The specified server cannot perform the requested operation.
        /// </summary>
        public const int ERROR_BAD_NET_RESP = 0x0000003A; // 58

        /// <summary>
        ///     An unexpected network error occurred.
        /// </summary>
        public const int ERROR_UNEXP_NET_ERR = 0x0000003B; // 59

        /// <summary>
        ///     The remote adapter is not compatible.
        /// </summary>
        public const int ERROR_BAD_REM_ADAP = 0x0000003C; // 60

        /// <summary>
        ///     The printer queue is full.
        /// </summary>
        public const int ERROR_PRINTQ_FULL = 0x0000003D; // 61

        /// <summary>
        ///     Space to store the file waiting to be printed is not available on the server.
        /// </summary>
        public const int ERROR_NO_SPOOL_SPACE = 0x0000003E; // 62

        /// <summary>
        ///     Your file waiting to be printed was deleted.
        /// </summary>
        public const int ERROR_PRINT_CANCELLED = 0x0000003F; // 63

        /// <summary>
        ///     The specified network name is no longer available.
        /// </summary>
        public const int ERROR_NETNAME_DELETED = 0x00000040; // 64

        /// <summary>
        ///     Network access is denied.
        /// </summary>
        public const int ERROR_NETWORK_ACCESS_DENIED = 0x00000041; // 65

        /// <summary>
        ///     The network resource type is not correct.
        /// </summary>
        public const int ERROR_BAD_DEV_TYPE = 0x00000042; // 66

        /// <summary>
        ///     The network name cannot be found.
        /// </summary>
        public const int ERROR_BAD_NET_NAME = 0x00000043; // 67

        /// <summary>
        ///     The name limit for the local computer network adapter card was exceeded.
        /// </summary>
        public const int ERROR_TOO_MANY_NAMES = 0x00000044; // 68

        /// <summary>
        ///     The network BIOS session limit was exceeded.
        /// </summary>
        public const int ERROR_TOO_MANY_SESS = 0x00000045; // 69

        /// <summary>
        ///     The remote server has been paused or is in the process of being started.
        /// </summary>
        public const int ERROR_SHARING_PAUSED = 0x00000046; // 70

        /// <summary>
        ///     No more connections can be made to this remote computer at this time because there are already as many connections
        ///     as the computer can accept.
        /// </summary>
        public const int ERROR_REQ_NOT_ACCEP = 0x00000047; // 71

        /// <summary>
        ///     The specified printer or disk device has been paused.
        /// </summary>
        public const int ERROR_REDIR_PAUSED = 0x00000048; // 72

        /// <summary>
        ///     The file exists.
        /// </summary>
        public const int ERROR_FILE_EXISTS = 0x00000050; // 80

        /// <summary>
        ///     The directory or file cannot be created.
        /// </summary>
        public const int ERROR_CANNOT_MAKE = 0x00000052; // 82

        /// <summary>
        ///     Fail on INT 24.
        /// </summary>
        public const int ERROR_FAIL_I24 = 0x00000053; // 83

        /// <summary>
        ///     Storage to process this request is not available.
        /// </summary>
        public const int ERROR_OUT_OF_STRUCTURES = 0x00000054; // 84

        /// <summary>
        ///     The local device name is already in use.
        /// </summary>
        public const int ERROR_ALREADY_ASSIGNED = 0x00000055; // 85

        /// <summary>
        ///     The specified network password is not correct.
        /// </summary>
        public const int ERROR_INVALID_PASSWORD = 0x00000056; // 86

        /// <summary>
        ///     The parameter is incorrect.
        /// </summary>
        public const int ERROR_INVALID_PARAMETER = 0x00000057; // 87

        /// <summary>
        ///     A write fault occurred on the network.
        /// </summary>
        public const int ERROR_NET_WRITE_FAULT = 0x00000058; // 88

        /// <summary>
        ///     The system cannot start another process at this time.
        /// </summary>
        public const int ERROR_NO_PROC_SLOTS = 0x00000059; // 89

        /// <summary>
        ///     Cannot create another system semaphore.
        /// </summary>
        public const int ERROR_TOO_MANY_SEMAPHORES = 0x00000064; // 100

        /// <summary>
        ///     The exclusive semaphore is owned by another process.
        /// </summary>
        public const int ERROR_EXCL_SEM_ALREADY_OWNED = 0x00000065; // 101

        /// <summary>
        ///     The semaphore is set and cannot be closed.
        /// </summary>
        public const int ERROR_SEM_IS_SET = 0x00000066; // 102

        /// <summary>
        ///     The semaphore cannot be set again.
        /// </summary>
        public const int ERROR_TOO_MANY_SEM_REQUESTS = 0x00000067; // 103

        /// <summary>
        ///     Cannot request exclusive semaphores at interrupt time.
        /// </summary>
        public const int ERROR_INVALID_AT_INTERRUPT_TIME = 0x00000068; // 104

        /// <summary>
        ///     The previous ownership of this semaphore has ended.
        /// </summary>
        public const int ERROR_SEM_OWNER_DIED = 0x00000069; // 105

        /// <summary>
        ///     Insert the diskette for drive %1.
        /// </summary>
        public const int ERROR_SEM_USER_LIMIT = 0x0000006A; // 106

        /// <summary>
        ///     The program stopped because an alternate diskette was not inserted.
        /// </summary>
        public const int ERROR_DISK_CHANGE = 0x0000006B; // 107

        /// <summary>
        ///     The disk is in use or locked by another process.
        /// </summary>
        public const int ERROR_DRIVE_LOCKED = 0x0000006C; // 108

        /// <summary>
        ///     The pipe has been ended.
        /// </summary>
        public const int ERROR_BROKEN_PIPE = 0x0000006D; // 109

        /// <summary>
        ///     The system cannot open the device or file specified.
        /// </summary>
        public const int ERROR_OPEN_FAILED = 0x0000006E; // 110

        /// <summary>
        ///     The file name is too long.
        /// </summary>
        public const int ERROR_BUFFER_OVERFLOW = 0x0000006F; // 111

        /// <summary>
        ///     There is not enough space on the disk.
        /// </summary>
        public const int ERROR_DISK_FULL = 0x00000070; // 112

        /// <summary>
        ///     No more internal file identifiers available.
        /// </summary>
        public const int ERROR_NO_MORE_SEARCH_HANDLES = 0x00000071; // 113

        /// <summary>
        ///     The target internal file identifier is incorrect.
        /// </summary>
        public const int ERROR_INVALID_TARGET_HANDLE = 0x00000072; // 114

        /// <summary>
        ///     The IOCTL call made by the application program is not correct.
        /// </summary>
        public const int ERROR_INVALID_CATEGORY = 0x00000075; // 117

        /// <summary>
        ///     The verify-on-write switch parameter value is not correct.
        /// </summary>
        public const int ERROR_INVALID_VERIFY_SWITCH = 0x00000076; // 118

        /// <summary>
        ///     The system does not support the command requested.
        /// </summary>
        public const int ERROR_BAD_DRIVER_LEVEL = 0x00000077; // 119

        /// <summary>
        ///     This function is not supported on this system.
        /// </summary>
        public const int ERROR_CALL_NOT_IMPLEMENTED = 0x00000078; // 120

        /// <summary>
        ///     The semaphore timeout period has expired.
        /// </summary>
        public const int ERROR_SEM_TIMEOUT = 0x00000079; // 121

        /// <summary>
        ///     The data area passed to a system call is too small.
        /// </summary>
        public const int ERROR_INSUFFICIENT_BUFFER = 0x0000007A; // 122

        /// <summary>
        ///     The filename, directory name, or volume label syntax is incorrect.
        /// </summary>
        public const int ERROR_INVALID_NAME = 0x0000007B; // 123

        /// <summary>
        ///     The system call level is not correct.
        /// </summary>
        public const int ERROR_INVALID_LEVEL = 0x0000007C; // 124

        /// <summary>
        ///     The disk has no volume label.
        /// </summary>
        public const int ERROR_NO_VOLUME_LABEL = 0x0000007D; // 125

        /// <summary>
        ///     The specified module could not be found.
        /// </summary>
        public const int ERROR_MOD_NOT_FOUND = 0x0000007E; // 126

        /// <summary>
        ///     The specified procedure could not be found.
        /// </summary>
        public const int ERROR_PROC_NOT_FOUND = 0x0000007F; // 127

        /// <summary>
        ///     There are no child processes to wait for.
        /// </summary>
        public const int ERROR_WAIT_NO_CHILDREN = 0x00000080; // 128

        /// <summary>
        ///     The %1 application cannot be run in Win32 mode.
        /// </summary>
        public const int ERROR_CHILD_NOT_COMPLETE = 0x00000081; // 129

        /// <summary>
        ///     Attempt to use a file handle to an open disk partition for an operation other than raw disk I/O.
        /// </summary>
        public const int ERROR_DIRECT_ACCESS_HANDLE = 0x00000082; // 130

        /// <summary>
        ///     An attempt was made to move the file pointer before the beginning of the file.
        /// </summary>
        public const int ERROR_NEGATIVE_SEEK = 0x00000083; // 131

        /// <summary>
        ///     The file pointer cannot be set on the specified device or file.
        /// </summary>
        public const int ERROR_SEEK_ON_DEVICE = 0x00000084; // 132

        /// <summary>
        ///     A JOIN or SUBST command cannot be used for a drive that contains previously joined drives.
        /// </summary>
        public const int ERROR_IS_JOIN_TARGET = 0x00000085; // 133

        /// <summary>
        ///     An attempt was made to use a JOIN or SUBST command on a drive that has already been joined.
        /// </summary>
        public const int ERROR_IS_JOINED = 0x00000086; // 134

        /// <summary>
        ///     An attempt was made to use a JOIN or SUBST command on a drive that has already been substituted.
        /// </summary>
        public const int ERROR_IS_SUBSTED = 0x00000087; // 135

        /// <summary>
        ///     The system tried to delete the JOIN of a drive that is not joined.
        /// </summary>
        public const int ERROR_NOT_JOINED = 0x00000088; // 136

        /// <summary>
        ///     The system tried to delete the substitution of a drive that is not substituted.
        /// </summary>
        public const int ERROR_NOT_SUBSTED = 0x00000089; // 137

        /// <summary>
        ///     The system tried to join a drive to a directory on a joined drive.
        /// </summary>
        public const int ERROR_JOIN_TO_JOIN = 0x0000008A; // 138

        /// <summary>
        ///     The system tried to substitute a drive to a directory on a substituted drive.
        /// </summary>
        public const int ERROR_SUBST_TO_SUBST = 0x0000008B; // 139

        /// <summary>
        ///     The system tried to join a drive to a directory on a substituted drive.
        /// </summary>
        public const int ERROR_JOIN_TO_SUBST = 0x0000008C; // 140

        /// <summary>
        ///     The system tried to SUBST a drive to a directory on a joined drive.
        /// </summary>
        public const int ERROR_SUBST_TO_JOIN = 0x0000008D; // 141

        /// <summary>
        ///     The system cannot perform a JOIN or SUBST at this time.
        /// </summary>
        public const int ERROR_BUSY_DRIVE = 0x0000008E; // 142

        /// <summary>
        ///     The system cannot join or substitute a drive to or for a directory on the same drive.
        /// </summary>
        public const int ERROR_SAME_DRIVE = 0x0000008F; // 143

        /// <summary>
        ///     The directory is not a subdirectory of the root directory.
        /// </summary>
        public const int ERROR_DIR_NOT_ROOT = 0x00000090; // 144

        /// <summary>
        ///     The directory is not empty.
        /// </summary>
        public const int ERROR_DIR_NOT_EMPTY = 0x00000091; // 145

        /// <summary>
        ///     The path specified is being used in a substitute.
        /// </summary>
        public const int ERROR_IS_SUBST_PATH = 0x00000092; // 146

        /// <summary>
        ///     Not enough resources are available to process this command.
        /// </summary>
        public const int ERROR_IS_JOIN_PATH = 0x00000093; // 147

        /// <summary>
        ///     The path specified cannot be used at this time.
        /// </summary>
        public const int ERROR_PATH_BUSY = 0x00000094; // 148

        /// <summary>
        ///     An attempt was made to join or substitute a drive for which a directory on the drive is the target of a previous
        ///     substitute.
        /// </summary>
        public const int ERROR_IS_SUBST_TARGET = 0x00000095; // 149

        /// <summary>
        ///     System trace information was not specified in your CONFIG.SYS file, or tracing is disallowed.
        /// </summary>
        public const int ERROR_SYSTEM_TRACE = 0x00000096; // 150

        /// <summary>
        ///     The number of specified semaphore events for DosMuxSemWait is not correct.
        /// </summary>
        public const int ERROR_INVALID_EVENT_COUNT = 0x00000097; // 151

        /// <summary>
        ///     DosMuxSemWait did not execute; too many semaphores are already set.
        /// </summary>
        public const int ERROR_TOO_MANY_MUXWAITERS = 0x00000098; // 152

        /// <summary>
        ///     The DosMuxSemWait list is not correct.
        /// </summary>
        public const int ERROR_INVALID_LIST_FORMAT = 0x00000099; // 153

        /// <summary>
        ///     The volume label you entered exceeds the label character limit of the target file system.
        /// </summary>
        public const int ERROR_LABEL_TOO_LONG = 0x0000009A; // 154

        /// <summary>
        ///     Cannot create another thread.
        /// </summary>
        public const int ERROR_TOO_MANY_TCBS = 0x0000009B; // 155

        /// <summary>
        ///     The recipient process has refused the signal.
        /// </summary>
        public const int ERROR_SIGNAL_REFUSED = 0x0000009C; // 156

        /// <summary>
        ///     The segment is already discarded and cannot be locked.
        /// </summary>
        public const int ERROR_DISCARDED = 0x0000009D; // 157

        /// <summary>
        ///     The segment is already unlocked.
        /// </summary>
        public const int ERROR_NOT_LOCKED = 0x0000009E; // 158

        /// <summary>
        ///     The address for the thread ID is not correct.
        /// </summary>
        public const int ERROR_BAD_THREADID_ADDR = 0x0000009F; // 159

        /// <summary>
        ///     One or more arguments are not correct.
        /// </summary>
        public const int ERROR_BAD_ARGUMENTS = 0x000000A0; // 160

        /// <summary>
        ///     The specified path is invalid.
        /// </summary>
        public const int ERROR_BAD_PATHNAME = 0x000000A1; // 161

        /// <summary>
        ///     A signal is already pending.
        /// </summary>
        public const int ERROR_SIGNAL_PENDING = 0x000000A2; // 162

        /// <summary>
        ///     No more threads can be created in the system.
        /// </summary>
        public const int ERROR_MAX_THRDS_REACHED = 0x000000A4; // 164

        /// <summary>
        ///     Unable to lock a region of a file.
        /// </summary>
        public const int ERROR_LOCK_FAILED = 0x000000A7; // 167

        /// <summary>
        ///     The requested resource is in use.
        /// </summary>
        public const int ERROR_BUSY = 0x000000AA; // 170

        /// <summary>
        ///     Device's command support detection is in progress.
        /// </summary>
        public const int ERROR_DEVICE_SUPPORT_IN_PROGRESS = 0x000000AB; // 171

        /// <summary>
        ///     A lock request was not outstanding for the supplied cancel region.
        /// </summary>
        public const int ERROR_CANCEL_VIOLATION = 0x000000AD; // 173

        /// <summary>
        ///     The file system does not support atomic changes to the lock type.
        /// </summary>
        public const int ERROR_ATOMIC_LOCKS_NOT_SUPPORTED = 0x000000AE; // 174

        /// <summary>
        ///     The system detected a segment number that was not correct.
        /// </summary>
        public const int ERROR_INVALID_SEGMENT_NUMBER = 0x000000B4; // 180

        /// <summary>
        ///     The operating system cannot run %1.
        /// </summary>
        public const int ERROR_INVALID_ORDINAL = 0x000000B6; // 182

        /// <summary>
        ///     Cannot create a file when that file already exists.
        /// </summary>
        public const int ERROR_ALREADY_EXISTS = 0x000000B7; // 183

        /// <summary>
        ///     The flag passed is not correct.
        /// </summary>
        public const int ERROR_INVALID_FLAG_NUMBER = 0x000000BA; // 186

        /// <summary>
        ///     The specified system semaphore name was not found.
        /// </summary>
        public const int ERROR_SEM_NOT_FOUND = 0x000000BB; // 187

        /// <summary>
        ///     The operating system cannot run %1.
        /// </summary>
        public const int ERROR_INVALID_STARTING_CODESEG = 0x000000BC; // 188

        /// <summary>
        ///     The operating system cannot run %1.
        /// </summary>
        public const int ERROR_INVALID_STACKSEG = 0x000000BD; // 189

        /// <summary>
        ///     The operating system cannot run %1.
        /// </summary>
        public const int ERROR_INVALID_MODULETYPE = 0x000000BE; // 190

        /// <summary>
        ///     Cannot run %1 in Win32 mode.
        /// </summary>
        public const int ERROR_INVALID_EXE_SIGNATURE = 0x000000BF; // 191

        /// <summary>
        ///     The operating system cannot run %1.
        /// </summary>
        public const int ERROR_EXE_MARKED_INVALID = 0x000000C0; // 192

        /// <summary>
        ///     %1 is not a valid Win32 application.
        /// </summary>
        public const int ERROR_BAD_EXE_FORMAT = 0x000000C1; // 193

        /// <summary>
        ///     The operating system cannot run %1.
        /// </summary>
        public const int ERROR_ITERATED_DATA_EXCEEDS_64k = 0x000000C2; // 194

        /// <summary>
        ///     The operating system cannot run %1.
        /// </summary>
        public const int ERROR_INVALID_MINALLOCSIZE = 0x000000C3; // 195

        /// <summary>
        ///     The operating system cannot run this application program.
        /// </summary>
        public const int ERROR_DYNLINK_FROM_INVALID_RING = 0x000000C4; // 196

        /// <summary>
        ///     The operating system is not presently configured to run this application.
        /// </summary>
        public const int ERROR_IOPL_NOT_ENABLED = 0x000000C5; // 197

        /// <summary>
        ///     The operating system cannot run %1.
        /// </summary>
        public const int ERROR_INVALID_SEGDPL = 0x000000C6; // 198

        /// <summary>
        ///     The operating system cannot run this application program.
        /// </summary>
        public const int ERROR_AUTODATASEG_EXCEEDS_64k = 0x000000C7; // 199

        /// <summary>
        ///     The code segment cannot be greater than or equal to 64K.
        /// </summary>
        public const int ERROR_RING2SEG_MUST_BE_MOVABLE = 0x000000C8; // 200

        /// <summary>
        ///     The operating system cannot run %1.
        /// </summary>
        public const int ERROR_RELOC_CHAIN_XEEDS_SEGLIM = 0x000000C9; // 201

        /// <summary>
        ///     The operating system cannot run %1.
        /// </summary>
        public const int ERROR_INFLOOP_IN_RELOC_CHAIN = 0x000000CA; // 202

        /// <summary>
        ///     The system could not find the environment option that was entered.
        /// </summary>
        public const int ERROR_ENVVAR_NOT_FOUND = 0x000000CB; // 203

        /// <summary>
        ///     No process in the command subtree has a signal handler.
        /// </summary>
        public const int ERROR_NO_SIGNAL_SENT = 0x000000CD; // 205

        /// <summary>
        ///     The filename or extension is too long.
        /// </summary>
        public const int ERROR_FILENAME_EXCED_RANGE = 0x000000CE; // 206

        /// <summary>
        ///     The ring 2 stack is in use.
        /// </summary>
        public const int ERROR_RING2_STACK_IN_USE = 0x000000CF; // 207

        /// <summary>
        ///     The global filename characters, * or ?, are entered incorrectly or too many global filename characters are
        ///     specified.
        /// </summary>
        public const int ERROR_META_EXPANSION_TOO_LONG = 0x000000D0; // 208

        /// <summary>
        ///     The signal being posted is not correct.
        /// </summary>
        public const int ERROR_INVALID_SIGNAL_NUMBER = 0x000000D1; // 209

        /// <summary>
        ///     The signal handler cannot be set.
        /// </summary>
        public const int ERROR_THREAD_1_INACTIVE = 0x000000D2; // 210

        /// <summary>
        ///     The segment is locked and cannot be reallocated.
        /// </summary>
        public const int ERROR_LOCKED = 0x000000D4; // 212

        /// <summary>
        ///     Too many dynamic-link modules are attached to this program or dynamic-link module.
        /// </summary>
        public const int ERROR_TOO_MANY_MODULES = 0x000000D6; // 214

        /// <summary>
        ///     Cannot nest calls to LoadModule.
        /// </summary>
        public const int ERROR_NESTING_NOT_ALLOWED = 0x000000D7; // 215

        /// <summary>
        ///     This version of %1 is not compatible with the version of Windows you're running. Check your computer's system
        ///     information and then contact the software publisher.
        /// </summary>
        public const int ERROR_EXE_MACHINE_TYPE_MISMATCH = 0x000000D8; // 216

        /// <summary>
        ///     The image file %1 is signed, unable to modify.
        /// </summary>
        public const int ERROR_EXE_CANNOT_MODIFY_SIGNED_BINARY = 0x000000D9; // 217

        /// <summary>
        ///     The image file %1 is strong signed, unable to modify.
        /// </summary>
        public const int ERROR_EXE_CANNOT_MODIFY_STRONG_SIGNED_BINARY = 0x000000DA; // 218

        /// <summary>
        ///     This file is checked out or locked for editing by another user.
        /// </summary>
        public const int ERROR_FILE_CHECKED_OUT = 0x000000DC; // 220

        /// <summary>
        ///     The file must be checked out before saving changes.
        /// </summary>
        public const int ERROR_CHECKOUT_REQUIRED = 0x000000DD; // 221

        /// <summary>
        ///     The file type being saved or retrieved has been blocked.
        /// </summary>
        public const int ERROR_BAD_FILE_TYPE = 0x000000DE; // 222

        /// <summary>
        ///     The file size exceeds the limit allowed and cannot be saved.
        /// </summary>
        public const int ERROR_FILE_TOO_LARGE = 0x000000DF; // 223

        /// <summary>
        ///     Access Denied. Before opening files in this location, you must first add the web site to your trusted sites list,
        ///     browse to the web site, and select the option to login automatically.
        /// </summary>
        public const int ERROR_FORMS_AUTH_REQUIRED = 0x000000E0; // 224

        /// <summary>
        ///     Operation did not complete successfully because the file contains a virus or potentially unwanted software.
        /// </summary>
        public const int ERROR_VIRUS_INFECTED = 0x000000E1; // 225

        /// <summary>
        ///     This file contains a virus or potentially unwanted software and cannot be opened. Due to the nature of this virus
        ///     or potentially unwanted software, the file has been removed from this location.
        /// </summary>
        public const int ERROR_VIRUS_DELETED = 0x000000E2; // 226

        /// <summary>
        ///     The pipe is local.
        /// </summary>
        public const int ERROR_PIPE_LOCAL = 0x000000E5; // 229

        /// <summary>
        ///     The pipe state is invalid.
        /// </summary>
        public const int ERROR_BAD_PIPE = 0x000000E6; // 230

        /// <summary>
        ///     All pipe instances are busy.
        /// </summary>
        public const int ERROR_PIPE_BUSY = 0x000000E7; // 231

        /// <summary>
        ///     The pipe is being closed.
        /// </summary>
        public const int ERROR_NO_DATA = 0x000000E8; // 232

        /// <summary>
        ///     No process is on the other end of the pipe.
        /// </summary>
        public const int ERROR_PIPE_NOT_CONNECTED = 0x000000E9; // 233

        /// <summary>
        ///     More data is available.
        /// </summary>
        public const int ERROR_MORE_DATA = 0x000000EA; // 234

        /// <summary>
        ///     The session was canceled.
        /// </summary>
        public const int ERROR_VC_DISCONNECTED = 0x000000F0; // 240

        /// <summary>
        ///     The specified extended attribute name was invalid.
        /// </summary>
        public const int ERROR_INVALID_EA_NAME = 0x000000FE; // 254

        /// <summary>
        ///     The extended attributes are inconsistent.
        /// </summary>
        public const int ERROR_EA_LIST_INCONSISTENT = 0x000000FF; // 255

        /// <summary>
        ///     The wait operation timed out.
        /// </summary>
        public const int WAIT_TIMEOUT = 0x00000102; // 258

        /// <summary>
        ///     No more data is available.
        /// </summary>
        public const int ERROR_NO_MORE_ITEMS = 0x00000103; // 259

        /// <summary>
        ///     The copy functions cannot be used.
        /// </summary>
        public const int ERROR_CANNOT_COPY = 0x0000010A; // 266

        /// <summary>
        ///     The directory name is invalid.
        /// </summary>
        public const int ERROR_DIRECTORY = 0x0000010B; // 267

        /// <summary>
        ///     The extended attributes did not fit in the buffer.
        /// </summary>
        public const int ERROR_EAS_DIDNT_FIT = 0x00000113; // 275

        /// <summary>
        ///     The extended attribute file on the mounted file system is corrupt.
        /// </summary>
        public const int ERROR_EA_FILE_CORRUPT = 0x00000114; // 276

        /// <summary>
        ///     The extended attribute table file is full.
        /// </summary>
        public const int ERROR_EA_TABLE_FULL = 0x00000115; // 277

        /// <summary>
        ///     The specified extended attribute handle is invalid.
        /// </summary>
        public const int ERROR_INVALID_EA_HANDLE = 0x00000116; // 278

        /// <summary>
        ///     The mounted file system does not support extended attributes.
        /// </summary>
        public const int ERROR_EAS_NOT_SUPPORTED = 0x0000011A; // 282

        /// <summary>
        ///     Attempt to release mutex not owned by caller.
        /// </summary>
        public const int ERROR_NOT_OWNER = 0x00000120; // 288

        /// <summary>
        ///     Too many posts were made to a semaphore.
        /// </summary>
        public const int ERROR_TOO_MANY_POSTS = 0x0000012A; // 298

        /// <summary>
        ///     Only part of a ReadProcessMemory or WriteProcessMemory request was completed.
        /// </summary>
        public const int ERROR_PARTIAL_COPY = 0x0000012B; // 299

        /// <summary>
        ///     The oplock request is denied.
        /// </summary>
        public const int ERROR_OPLOCK_NOT_GRANTED = 0x0000012C; // 300

        /// <summary>
        ///     An invalid oplock acknowledgment was received by the system.
        /// </summary>
        public const int ERROR_INVALID_OPLOCK_PROTOCOL = 0x0000012D; // 301

        /// <summary>
        ///     The volume is too fragmented to complete this operation.
        /// </summary>
        public const int ERROR_DISK_TOO_FRAGMENTED = 0x0000012E; // 302

        /// <summary>
        ///     The file cannot be opened because it is in the process of being deleted.
        /// </summary>
        public const int ERROR_DELETE_PENDING = 0x0000012F; // 303

        /// <summary>
        ///     Short name settings may not be changed on this volume due to the global registry setting.
        /// </summary>
        public const int ERROR_INCOMPATIBLE_WITH_GLOBAL_SHORT_NAME_REGISTRY_SETTING = 0x00000130; // 304

        /// <summary>
        ///     Short names are not enabled on this volume.
        /// </summary>
        public const int ERROR_SHORT_NAMES_NOT_ENABLED_ON_VOLUME = 0x00000131; // 305

        /// <summary>
        ///     The security stream for the given volume is in an inconsistent state. Please run CHKDSK on the volume.
        /// </summary>
        public const int ERROR_SECURITY_STREAM_IS_INCONSISTENT = 0x00000132; // 306

        /// <summary>
        ///     A requested file lock operation cannot be processed due to an invalid byte range.
        /// </summary>
        public const int ERROR_INVALID_LOCK_RANGE = 0x00000133; // 307

        /// <summary>
        ///     The subsystem needed to support the image type is not present.
        /// </summary>
        public const int ERROR_IMAGE_SUBSYSTEM_NOT_PRESENT = 0x00000134; // 308

        /// <summary>
        ///     The specified file already has a notification GUID associated with it.
        /// </summary>
        public const int ERROR_NOTIFICATION_GUID_ALREADY_DEFINED = 0x00000135; // 309

        /// <summary>
        ///     An invalid exception handler routine has been detected.
        /// </summary>
        public const int ERROR_INVALID_EXCEPTION_HANDLER = 0x00000136; // 310

        /// <summary>
        ///     Duplicate privileges were specified for the token.
        /// </summary>
        public const int ERROR_DUPLICATE_PRIVILEGES = 0x00000137; // 311

        /// <summary>
        ///     No ranges for the specified operation were able to be processed.
        /// </summary>
        public const int ERROR_NO_RANGES_PROCESSED = 0x00000138; // 312

        /// <summary>
        ///     Operation is not allowed on a file system internal file.
        /// </summary>
        public const int ERROR_NOT_ALLOWED_ON_SYSTEM_FILE = 0x00000139; // 313

        /// <summary>
        ///     The physical resources of this disk have been exhausted.
        /// </summary>
        public const int ERROR_DISK_RESOURCES_EXHAUSTED = 0x0000013A; // 314

        /// <summary>
        ///     The token representing the data is invalid.
        /// </summary>
        public const int ERROR_INVALID_TOKEN = 0x0000013B; // 315

        /// <summary>
        ///     The device does not support the command feature.
        /// </summary>
        public const int ERROR_DEVICE_FEATURE_NOT_SUPPORTED = 0x0000013C; // 316

        /// <summary>
        ///     The system cannot find message text for message number 0x%1 in the message file for %2.
        /// </summary>
        public const int ERROR_MR_MID_NOT_FOUND = 0x0000013D; // 317

        /// <summary>
        ///     The scope specified was not found.
        /// </summary>
        public const int ERROR_SCOPE_NOT_FOUND = 0x0000013E; // 318

        /// <summary>
        ///     The Central Access Policy specified is not defined on the target machine.
        /// </summary>
        public const int ERROR_UNDEFINED_SCOPE = 0x0000013F; // 319

        /// <summary>
        ///     The Central Access Policy obtained from Active Directory is invalid.
        /// </summary>
        public const int ERROR_INVALID_CAP = 0x00000140; // 320

        /// <summary>
        ///     The device is unreachable.
        /// </summary>
        public const int ERROR_DEVICE_UNREACHABLE = 0x00000141; // 321

        /// <summary>
        ///     The target device has insufficient resources to complete the operation.
        /// </summary>
        public const int ERROR_DEVICE_NO_RESOURCES = 0x00000142; // 322

        /// <summary>
        ///     A data integrity checksum error occurred. Data in the file stream is corrupt.
        /// </summary>
        public const int ERROR_DATA_CHECKSUM_ERROR = 0x00000143; // 323

        /// <summary>
        ///     An attempt was made to modify both a KERNEL and normal Extended Attribute (EA) in the same operation.
        /// </summary>
        public const int ERROR_INTERMIXED_KERNEL_EA_OPERATION = 0x00000144; // 324

        /// <summary>
        ///     Device does not support file-level TRIM.
        /// </summary>
        public const int ERROR_FILE_LEVEL_TRIM_NOT_SUPPORTED = 0x00000146; // 326

        /// <summary>
        ///     The command specified a data offset that does not align to the device's granularity/alignment.
        /// </summary>
        public const int ERROR_OFFSET_ALIGNMENT_VIOLATION = 0x00000147; // 327

        /// <summary>
        ///     The command specified an invalid field in its parameter list.
        /// </summary>
        public const int ERROR_INVALID_FIELD_IN_PARAMETER_LIST = 0x00000148; // 328

        /// <summary>
        ///     An operation is currently in progress with the device.
        /// </summary>
        public const int ERROR_OPERATION_IN_PROGRESS = 0x00000149; // 329

        /// <summary>
        ///     An attempt was made to send down the command via an invalid path to the target device.
        /// </summary>
        public const int ERROR_BAD_DEVICE_PATH = 0x0000014A; // 330

        /// <summary>
        ///     The command specified a number of descriptors that exceeded the maximum supported by the device.
        /// </summary>
        public const int ERROR_TOO_MANY_DESCRIPTORS = 0x0000014B; // 331

        /// <summary>
        ///     Scrub is disabled on the specified file.
        /// </summary>
        public const int ERROR_SCRUB_DATA_DISABLED = 0x0000014C; // 332

        /// <summary>
        ///     The storage device does not provide redundancy.
        /// </summary>
        public const int ERROR_NOT_REDUNDANT_STORAGE = 0x0000014D; // 333

        /// <summary>
        ///     An operation is not supported on a resident file.
        /// </summary>
        public const int ERROR_RESIDENT_FILE_NOT_SUPPORTED = 0x0000014E; // 334

        /// <summary>
        ///     An operation is not supported on a compressed file.
        /// </summary>
        public const int ERROR_COMPRESSED_FILE_NOT_SUPPORTED = 0x0000014F; // 335

        /// <summary>
        ///     An operation is not supported on a directory.
        /// </summary>
        public const int ERROR_DIRECTORY_NOT_SUPPORTED = 0x00000150; // 336

        /// <summary>
        ///     The specified copy of the requested data could not be read.
        /// </summary>
        public const int ERROR_NOT_READ_FROM_COPY = 0x00000151; // 337

        /// <summary>
        ///     No action was taken as a system reboot is required.
        /// </summary>
        public const int ERROR_FAIL_NOACTION_REBOOT = 0x0000015E; // 350

        /// <summary>
        ///     The shutdown operation failed.
        /// </summary>
        public const int ERROR_FAIL_SHUTDOWN = 0x0000015F; // 351

        /// <summary>
        ///     The restart operation failed.
        /// </summary>
        public const int ERROR_FAIL_RESTART = 0x00000160; // 352

        /// <summary>
        ///     The maximum number of sessions has been reached.
        /// </summary>
        public const int ERROR_MAX_SESSIONS_REACHED = 0x00000161; // 353

        /// <summary>
        ///     The thread is already in background processing mode.
        /// </summary>
        public const int ERROR_THREAD_MODE_ALREADY_BACKGROUND = 0x00000190; // 400

        /// <summary>
        ///     The thread is not in background processing mode.
        /// </summary>
        public const int ERROR_THREAD_MODE_NOT_BACKGROUND = 0x00000191; // 401

        /// <summary>
        ///     The process is already in background processing mode.
        /// </summary>
        public const int ERROR_PROCESS_MODE_ALREADY_BACKGROUND = 0x00000192; // 402

        /// <summary>
        ///     The process is not in background processing mode.
        /// </summary>
        public const int ERROR_PROCESS_MODE_NOT_BACKGROUND = 0x00000193; // 403

        /// <summary>
        ///     Attempt to access invalid address.
        /// </summary>
        public const int ERROR_INVALID_ADDRESS = 0x000001E7; // 487

        #endregion

        #region 500 - 999

        /// <summary>
        ///     User profile cannot be loaded.
        /// </summary>
        public const int ERROR_USER_PROFILE_LOAD = 0x000001F4; // 500

        /// <summary>
        ///     Arithmetic result exceeded 32 bits.
        /// </summary>
        public const int ERROR_ARITHMETIC_OVERFLOW = 0x00000216; // 534

        /// <summary>
        ///     There is a process on other end of the pipe.
        /// </summary>
        public const int ERROR_PIPE_CONNECTED = 0x00000217; // 535

        /// <summary>
        ///     Waiting for a process to open the other end of the pipe.
        /// </summary>
        public const int ERROR_PIPE_LISTENING = 0x00000218; // 536

        /// <summary>
        ///     Application verifier has found an error in the current process.
        /// </summary>
        public const int ERROR_VERIFIER_STOP = 0x00000219; // 537

        /// <summary>
        ///     An error occurred in the ABIOS subsystem.
        /// </summary>
        public const int ERROR_ABIOS_ERROR = 0x0000021A; // 538

        /// <summary>
        ///     A warning occurred in the WX86 subsystem.
        /// </summary>
        public const int ERROR_WX86_WARNING = 0x0000021B; // 539

        /// <summary>
        ///     An error occurred in the WX86 subsystem.
        /// </summary>
        public const int ERROR_WX86_ERROR = 0x0000021C; // 540

        /// <summary>
        ///     An attempt was made to cancel or set a timer that has an associated APC and the subject thread is not the thread
        ///     that originally set the timer with an associated APC routine.
        /// </summary>
        public const int ERROR_TIMER_NOT_CANCELED = 0x0000021D; // 541

        /// <summary>
        ///     Unwind exception code.
        /// </summary>
        public const int ERROR_UNWIND = 0x0000021E; // 542

        /// <summary>
        ///     An invalid or unaligned stack was encountered during an unwind operation.
        /// </summary>
        public const int ERROR_BAD_STACK = 0x0000021F; // 543

        /// <summary>
        ///     An invalid unwind target was encountered during an unwind operation.
        /// </summary>
        public const int ERROR_INVALID_UNWIND_TARGET = 0x00000220; // 544

        /// <summary>
        ///     Invalid Object Attributes specified to NtCreatePort or invalid Port Attributes specified to NtConnectPort
        /// </summary>
        public const int ERROR_INVALID_PORT_ATTRIBUTES = 0x00000221; // 545

        /// <summary>
        ///     Length of message passed to NtRequestPort or NtRequestWaitReplyPort was longer than the maximum message allowed by
        ///     the port.
        /// </summary>
        public const int ERROR_PORT_MESSAGE_TOO_LONG = 0x00000222; // 546

        /// <summary>
        ///     An attempt was made to lower a quota limit below the current usage.
        /// </summary>
        public const int ERROR_INVALID_QUOTA_LOWER = 0x00000223; // 547

        /// <summary>
        ///     An attempt was made to attach to a device that was already attached to another device.
        /// </summary>
        public const int ERROR_DEVICE_ALREADY_ATTACHED = 0x00000224; // 548

        /// <summary>
        ///     An attempt was made to execute an instruction at an unaligned address and the host system does not support
        ///     unaligned instruction references.
        /// </summary>
        public const int ERROR_INSTRUCTION_MISALIGNMENT = 0x00000225; // 549

        /// <summary>
        ///     Profiling not started.
        /// </summary>
        public const int ERROR_PROFILING_NOT_STARTED = 0x00000226; // 550

        /// <summary>
        ///     Profiling not stopped.
        /// </summary>
        public const int ERROR_PROFILING_NOT_STOPPED = 0x00000227; // 551

        /// <summary>
        ///     The passed ACL did not contain the minimum required information.
        /// </summary>
        public const int ERROR_COULD_NOT_INTERPRET = 0x00000228; // 552

        /// <summary>
        ///     The number of active profiling objects is at the maximum and no more may be started.
        /// </summary>
        public const int ERROR_PROFILING_AT_LIMIT = 0x00000229; // 553

        /// <summary>
        ///     Used to indicate that an operation cannot continue without blocking for I/O.
        /// </summary>
        public const int ERROR_CANT_WAIT = 0x0000022A; // 554

        /// <summary>
        ///     Indicates that a thread attempted to terminate itself by default (called NtTerminateThread with NULL) and it was
        ///     the last thread in the current process.
        /// </summary>
        public const int ERROR_CANT_TERMINATE_SELF = 0x0000022B; // 555

        /// <summary>
        ///     If an MM error is returned which is not defined in the standard FsRtl filter, it is converted to one of the
        ///     following errors which is guaranteed to be in the filter. In this case information is lost, however, the filter
        ///     correctly handles the exception.
        /// </summary>
        public const int ERROR_UNEXPECTED_MM_CREATE_ERR = 0x0000022C; // 556

        /// <summary>
        ///     If an MM error is returned which is not defined in the standard FsRtl filter, it is converted to one of the
        ///     following errors which is guaranteed to be in the filter. In this case information is lost, however, the filter
        ///     correctly handles the exception.
        /// </summary>
        public const int ERROR_UNEXPECTED_MM_MAP_ERROR = 0x0000022D; // 557

        /// <summary>
        ///     If an MM error is returned which is not defined in the standard FsRtl filter, it is converted to one of the
        ///     following errors which is guaranteed to be in the filter. In this case information is lost, however, the filter
        ///     correctly handles the exception.
        /// </summary>
        public const int ERROR_UNEXPECTED_MM_EXTEND_ERR = 0x0000022E; // 558

        /// <summary>
        ///     A malformed function table was encountered during an unwind operation.
        /// </summary>
        public const int ERROR_BAD_FUNCTION_TABLE = 0x0000022F; // 559

        /// <summary>
        ///     Indicates that an attempt was made to assign protection to a file system file or directory and one of the SIDs in
        ///     the security descriptor could not be translated into a GUID that could be stored by the file system. This causes
        ///     the protection attempt to fail, which may cause a file creation attempt to fail.
        /// </summary>
        public const int ERROR_NO_GUID_TRANSLATION = 0x00000230; // 560

        /// <summary>
        ///     Indicates that an attempt was made to grow an LDT by setting its size, or that the size was not an even number of
        ///     selectors.
        /// </summary>
        public const int ERROR_INVALID_LDT_SIZE = 0x00000231; // 561

        /// <summary>
        ///     Indicates that the starting value for the LDT information was not an integral multiple of the selector size.
        /// </summary>
        public const int ERROR_INVALID_LDT_OFFSET = 0x00000233; // 563

        /// <summary>
        ///     Indicates that the user supplied an invalid descriptor when trying to set up Ldt descriptors.
        /// </summary>
        public const int ERROR_INVALID_LDT_DESCRIPTOR = 0x00000234; // 564

        /// <summary>
        ///     Indicates a process has too many threads to perform the requested action. For example, assignment of a primary
        ///     token may only be performed when a process has zero or one threads.
        /// </summary>
        public const int ERROR_TOO_MANY_THREADS = 0x00000235; // 565

        /// <summary>
        ///     An attempt was made to operate on a thread within a specific process, but the thread specified is not in the
        ///     process specified.
        /// </summary>
        public const int ERROR_THREAD_NOT_IN_PROCESS = 0x00000236; // 566

        /// <summary>
        ///     Page file quota was exceeded.
        /// </summary>
        public const int ERROR_PAGEFILE_QUOTA_EXCEEDED = 0x00000237; // 567

        /// <summary>
        ///     The Netlogon service cannot start because another Netlogon service running in the domain conflicts with the
        ///     specified role.
        /// </summary>
        public const int ERROR_LOGON_SERVER_CONFLICT = 0x00000238; // 568

        /// <summary>
        ///     The SAM database on a Windows Server is significantly out of synchronization with the copy on the Domain
        ///     Controller. A complete synchronization is required.
        /// </summary>
        public const int ERROR_SYNCHRONIZATION_REQUIRED = 0x00000239; // 569

        /// <summary>
        ///     The NtCreateFile API failed. This error should never be returned to an application, it is a place holder for the
        ///     Windows LAN Manager Redirector to use in its internal error mapping routines.
        /// </summary>
        public const int ERROR_NET_OPEN_FAILED = 0x0000023A; // 570

        /// <summary>
        ///     {Privilege Failed} The I/O permissions for the process could not be changed.
        /// </summary>
        public const int ERROR_IO_PRIVILEGE_FAILED = 0x0000023B; // 571

        /// <summary>
        ///     {Application Exit by CTRL+C} The application terminated as a result of a CTRL+C.
        /// </summary>
        public const int ERROR_CONTROL_C_EXIT = 0x0000023C; // 572

        /// <summary>
        ///     {Missing System File} The required system file %hs is bad or missing.
        /// </summary>
        public const int ERROR_MISSING_SYSTEMFILE = 0x0000023D; // 573

        /// <summary>
        ///     {Application Error} The exception %s (0x%08lx) occurred in the application at location 0x%08lx.
        /// </summary>
        public const int ERROR_UNHANDLED_EXCEPTION = 0x0000023E; // 574

        /// <summary>
        ///     {Application Error} The application was unable to start correctly (0x%lx). Click OK to close the application.
        /// </summary>
        public const int ERROR_APP_INIT_FAILURE = 0x0000023F; // 575

        /// <summary>
        ///     {Unable to Create Paging File} The creation of the paging file %hs failed (%lx). The requested size was %ld.
        /// </summary>
        public const int ERROR_PAGEFILE_CREATE_FAILED = 0x00000240; // 576

        /// <summary>
        ///     Windows cannot verify the digital signature for this file. A recent hardware or software change might have
        ///     installed a file that is signed incorrectly or damaged, or that might be malicious software from an unknown source.
        /// </summary>
        public const int ERROR_INVALID_IMAGE_HASH = 0x00000241; // 577

        /// <summary>
        ///     {No Paging File Specified} No paging file was specified in the system configuration.
        /// </summary>
        public const int ERROR_NO_PAGEFILE = 0x00000242; // 578

        /// <summary>
        ///     {EXCEPTION} A real-mode application issued a floating-point instruction and floating-point hardware is not present.
        /// </summary>
        public const int ERROR_ILLEGAL_FLOAT_CONTEXT = 0x00000243; // 579

        /// <summary>
        ///     An event pair synchronization operation was performed using the thread specific client/server event pair object,
        ///     but no event pair object was associated with the thread.
        /// </summary>
        public const int ERROR_NO_EVENT_PAIR = 0x00000244; // 580

        /// <summary>
        ///     A Windows Server has an incorrect configuration.
        /// </summary>
        public const int ERROR_DOMAIN_CTRLR_CONFIG_ERROR = 0x00000245; // 581

        /// <summary>
        ///     An illegal character was encountered. For a multi-byte character set this includes a lead byte without a succeeding
        ///     trail byte. For the Unicode character set this includes the characters 0xFFFF and 0xFFFE.
        /// </summary>
        public const int ERROR_ILLEGAL_CHARACTER = 0x00000246; // 582

        /// <summary>
        ///     The Unicode character is not defined in the Unicode character set installed on the system.
        /// </summary>
        public const int ERROR_UNDEFINED_CHARACTER = 0x00000247; // 583

        /// <summary>
        ///     The paging file cannot be created on a floppy diskette.
        /// </summary>
        public const int ERROR_FLOPPY_VOLUME = 0x00000248; // 584

        /// <summary>
        ///     The system BIOS failed to connect a system interrupt to the device or bus for which the device is connected.
        /// </summary>
        public const int ERROR_BIOS_FAILED_TO_CONNECT_INTERRUPT = 0x00000249; // 585

        /// <summary>
        ///     This operation is only allowed for the Primary Domain Controller of the domain.
        /// </summary>
        public const int ERROR_BACKUP_CONTROLLER = 0x0000024A; // 586

        /// <summary>
        ///     An attempt was made to acquire a mutant such that its maximum count would have been exceeded.
        /// </summary>
        public const int ERROR_MUTANT_LIMIT_EXCEEDED = 0x0000024B; // 587

        /// <summary>
        ///     A volume has been accessed for which a file system driver is required that has not yet been loaded.
        /// </summary>
        public const int ERROR_FS_DRIVER_REQUIRED = 0x0000024C; // 588

        /// <summary>
        ///     {Registry File Failure} The registry cannot load the hive (file): %hs or its log or alternate. It is corrupt,
        ///     absent, or not writable.
        /// </summary>
        public const int ERROR_CANNOT_LOAD_REGISTRY_FILE = 0x0000024D; // 589

        /// <summary>
        ///     {Unexpected Failure in DebugActiveProcess} An unexpected failure occurred while processing a DebugActiveProcess API
        ///     request. You may choose OK to terminate the process, or Cancel to ignore the error.
        /// </summary>
        public const int ERROR_DEBUG_ATTACH_FAILED = 0x0000024E; // 590

        /// <summary>
        ///     {Fatal System Error} The %hs system process terminated unexpectedly with a status of 0x%08x (0x%08x 0x%08x). The
        ///     system has been shut down.
        /// </summary>
        public const int ERROR_SYSTEM_PROCESS_TERMINATED = 0x0000024F; // 591

        /// <summary>
        ///     {Data Not Accepted} The TDI client could not handle the data received during an indication.
        /// </summary>
        public const int ERROR_DATA_NOT_ACCEPTED = 0x00000250; // 592

        /// <summary>
        ///     NTVDM encountered a hard error.
        /// </summary>
        public const int ERROR_VDM_HARD_ERROR = 0x00000251; // 593

        /// <summary>
        ///     {Cancel Timeout} The driver %hs failed to complete a canceled I/O request in the allotted time.
        /// </summary>
        public const int ERROR_DRIVER_CANCEL_TIMEOUT = 0x00000252; // 594

        /// <summary>
        ///     {Reply Message Mismatch} An attempt was made to reply to an LPC message, but the thread specified by the client ID
        ///     in the message was not waiting on that message.
        /// </summary>
        public const int ERROR_REPLY_MESSAGE_MISMATCH = 0x00000253; // 595

        /// <summary>
        ///     {Delayed Write Failed} Windows was unable to save all the data for the file %hs. The data has been lost. This error
        ///     may be caused by a failure of your computer hardware or network connection. Please try to save this file elsewhere.
        /// </summary>
        public const int ERROR_LOST_WRITEBEHIND_DATA = 0x00000254; // 596

        /// <summary>
        ///     The parameter(s) passed to the server in the client/server shared memory window were invalid. Too much data may
        ///     have been put in the shared memory window.
        /// </summary>
        public const int ERROR_CLIENT_SERVER_PARAMETERS_INVALID = 0x00000255; // 597

        /// <summary>
        ///     The stream is not a tiny stream.
        /// </summary>
        public const int ERROR_NOT_TINY_STREAM = 0x00000256; // 598

        /// <summary>
        ///     The request must be handled by the stack overflow code.
        /// </summary>
        public const int ERROR_STACK_OVERFLOW_READ = 0x00000257; // 599

        /// <summary>
        ///     Internal OFS status codes indicating how an allocation operation is handled. Either it is retried after the
        ///     containing node is moved or the extent stream is converted to a large stream.
        /// </summary>
        public const int ERROR_CONVERT_TO_LARGE = 0x00000258; // 600

        /// <summary>
        ///     The attempt to find the object found an object matching by ID on the volume but it is out of the scope of the
        ///     handle used for the operation.
        /// </summary>
        public const int ERROR_FOUND_OUT_OF_SCOPE = 0x00000259; // 601

        /// <summary>
        ///     The bucket array must be grown. Retry transaction after doing so.
        /// </summary>
        public const int ERROR_ALLOCATE_BUCKET = 0x0000025A; // 602

        /// <summary>
        ///     The user/kernel marshaling buffer has overflowed.
        /// </summary>
        public const int ERROR_MARSHALL_OVERFLOW = 0x0000025B; // 603

        /// <summary>
        ///     The supplied variant structure contains invalid data.
        /// </summary>
        public const int ERROR_INVALID_VARIANT = 0x0000025C; // 604

        /// <summary>
        ///     The specified buffer contains ill-formed data.
        /// </summary>
        public const int ERROR_BAD_COMPRESSION_BUFFER = 0x0000025D; // 605

        /// <summary>
        ///     {Audit Failed} An attempt to generate a security audit failed.
        /// </summary>
        public const int ERROR_AUDIT_FAILED = 0x0000025E; // 606

        /// <summary>
        ///     The timer resolution was not previously set by the current process.
        /// </summary>
        public const int ERROR_TIMER_RESOLUTION_NOT_SET = 0x0000025F; // 607

        /// <summary>
        ///     There is insufficient account information to log you on.
        /// </summary>
        public const int ERROR_INSUFFICIENT_LOGON_INFO = 0x00000260; // 608

        /// <summary>
        ///     {Invalid DLL Entrypoint} The dynamic link library %hs is not written correctly. The stack pointer has been left in
        ///     an inconsistent state. The entrypoint should be declared as WINAPI or STDCALL. Select YES to fail the DLL load.
        ///     Select NO to continue execution. Selecting NO may cause the application to operate incorrectly.
        /// </summary>
        public const int ERROR_BAD_DLL_ENTRYPOINT = 0x00000261; // 609

        /// <summary>
        ///     {Invalid Service Callback Entrypoint} The %hs service is not written correctly. The stack pointer has been left in
        ///     an inconsistent state. The callback entrypoint should be declared as WINAPI or STDCALL. Selecting OK will cause the
        ///     service to continue operation. However, the service process may operate incorrectly.
        /// </summary>
        public const int ERROR_BAD_SERVICE_ENTRYPOINT = 0x00000262; // 610

        /// <summary>
        ///     There is an IP address conflict with another system on the network.
        /// </summary>
        public const int ERROR_IP_ADDRESS_CONFLICT1 = 0x00000263; // 611

        /// <summary>
        ///     There is an IP address conflict with another system on the network.
        /// </summary>
        public const int ERROR_IP_ADDRESS_CONFLICT2 = 0x00000264; // 612

        /// <summary>
        ///     {Low On Registry Space} The system has reached the maximum size allowed for the system part of the registry.
        ///     Additional storage requests will be ignored.
        /// </summary>
        public const int ERROR_REGISTRY_QUOTA_LIMIT = 0x00000265; // 613

        /// <summary>
        ///     A callback return system service cannot be executed when no callback is active.
        /// </summary>
        public const int ERROR_NO_CALLBACK_ACTIVE = 0x00000266; // 614

        /// <summary>
        ///     The password provided is too short to meet the policy of your user account. Please choose a longer password.
        /// </summary>
        public const int ERROR_PWD_TOO_SHORT = 0x00000267; // 615

        /// <summary>
        ///     The policy of your user account does not allow you to change passwords too frequently. This is done to prevent
        ///     users from changing back to a familiar, but potentially discovered, password. If you feel your password has been
        ///     compromised then please contact your administrator immediately to have a new one assigned.
        /// </summary>
        public const int ERROR_PWD_TOO_RECENT = 0x00000268; // 616

        /// <summary>
        ///     You have attempted to change your password to one that you have used in the past. The policy of your user account
        ///     does not allow this. Please select a password that you have not previously used.
        /// </summary>
        public const int ERROR_PWD_HISTORY_CONFLICT = 0x00000269; // 617

        /// <summary>
        ///     The specified compression format is unsupported.
        /// </summary>
        public const int ERROR_UNSUPPORTED_COMPRESSION = 0x0000026A; // 618

        /// <summary>
        ///     The specified hardware profile configuration is invalid.
        /// </summary>
        public const int ERROR_INVALID_HW_PROFILE = 0x0000026B; // 619

        /// <summary>
        ///     The specified Plug and Play registry device path is invalid.
        /// </summary>
        public const int ERROR_INVALID_PLUGPLAY_DEVICE_PATH = 0x0000026C; // 620

        /// <summary>
        ///     The specified quota list is internally inconsistent with its descriptor.
        /// </summary>
        public const int ERROR_QUOTA_LIST_INCONSISTENT = 0x0000026D; // 621

        /// <summary>
        ///     {Windows Evaluation Notification} The evaluation period for this installation of Windows has expired. This system
        ///     will shutdown in 1 hour. To restore access to this installation of Windows, please upgrade this installation using
        ///     a licensed distribution of this product.
        /// </summary>
        public const int ERROR_EVALUATION_EXPIRATION = 0x0000026E; // 622

        /// <summary>
        ///     {Illegal System DLL Relocation} The system DLL %hs was relocated in memory. The application will not run properly.
        ///     The relocation occurred because the DLL %hs occupied an address range reserved for Windows system DLLs. The vendor
        ///     supplying the DLL should be contacted for a new DLL.
        /// </summary>
        public const int ERROR_ILLEGAL_DLL_RELOCATION = 0x0000026F; // 623

        /// <summary>
        ///     {DLL Initialization Failed} The application failed to initialize because the window station is shutting down.
        /// </summary>
        public const int ERROR_DLL_INIT_FAILED_LOGOFF = 0x00000270; // 624

        /// <summary>
        ///     The validation process needs to continue on to the next step.
        /// </summary>
        public const int ERROR_VALIDATE_CONTINUE = 0x00000271; // 625

        /// <summary>
        ///     There are no more matches for the current index enumeration.
        /// </summary>
        public const int ERROR_NO_MORE_MATCHES = 0x00000272; // 626

        /// <summary>
        ///     The range could not be added to the range list because of a conflict.
        /// </summary>
        public const int ERROR_RANGE_LIST_CONFLICT = 0x00000273; // 627

        /// <summary>
        ///     The server process is running under a SID different than that required by client.
        /// </summary>
        public const int ERROR_SERVER_SID_MISMATCH = 0x00000274; // 628

        /// <summary>
        ///     A group marked use for deny only cannot be enabled.
        /// </summary>
        public const int ERROR_CANT_ENABLE_DENY_ONLY = 0x00000275; // 629

        /// <summary>
        ///     {EXCEPTION} Multiple floating point faults.
        /// </summary>
        public const int ERROR_FLOAT_MULTIPLE_FAULTS = 0x00000276; // 630

        /// <summary>
        ///     {EXCEPTION} Multiple floating point traps.
        /// </summary>
        public const int ERROR_FLOAT_MULTIPLE_TRAPS = 0x00000277; // 631

        /// <summary>
        ///     The requested interface is not supported.
        /// </summary>
        public const int ERROR_NOINTERFACE = 0x00000278; // 632

        /// <summary>
        ///     {System Standby Failed} The driver %hs does not support standby mode. Updating this driver may allow the system to
        ///     go to standby mode.
        /// </summary>
        public const int ERROR_DRIVER_FAILED_SLEEP = 0x00000279; // 633

        /// <summary>
        ///     The system file %1 has become corrupt and has been replaced.
        /// </summary>
        public const int ERROR_CORRUPT_SYSTEM_FILE = 0x0000027A; // 634

        /// <summary>
        ///     {Virtual Memory Minimum Too Low} Your system is low on virtual memory. Windows is increasing the size of your
        ///     virtual memory paging file. During this process, memory requests for some applications may be denied. For more
        ///     information, see Help.
        /// </summary>
        public const int ERROR_COMMITMENT_MINIMUM = 0x0000027B; // 635

        /// <summary>
        ///     A device was removed so enumeration must be restarted.
        /// </summary>
        public const int ERROR_PNP_RESTART_ENUMERATION = 0x0000027C; // 636

        /// <summary>
        ///     {Fatal System Error} The system image %s is not properly signed. The file has been replaced with the signed file.
        ///     The system has been shut down.
        /// </summary>
        public const int ERROR_SYSTEM_IMAGE_BAD_SIGNATURE = 0x0000027D; // 637

        /// <summary>
        ///     Device will not start without a reboot.
        /// </summary>
        public const int ERROR_PNP_REBOOT_REQUIRED = 0x0000027E; // 638

        /// <summary>
        ///     There is not enough power to complete the requested operation.
        /// </summary>
        public const int ERROR_INSUFFICIENT_POWER = 0x0000027F; // 639

        /// <summary>
        ///     ERROR_MULTIPLE_FAULT_VIOLATION
        /// </summary>
        public const int ERROR_MULTIPLE_FAULT_VIOLATION = 0x00000280; // 640

        /// <summary>
        ///     The system is in the process of shutting down.
        /// </summary>
        public const int ERROR_SYSTEM_SHUTDOWN = 0x00000281; // 641

        /// <summary>
        ///     An attempt to remove a processes DebugPort was made, but a port was not already associated with the process.
        /// </summary>
        public const int ERROR_PORT_NOT_SET = 0x00000282; // 642

        /// <summary>
        ///     This version of Windows is not compatible with the behavior version of directory forest, domain or domain
        ///     controller.
        /// </summary>
        public const int ERROR_DS_VERSION_CHECK_FAILURE = 0x00000283; // 643

        /// <summary>
        ///     The specified range could not be found in the range list.
        /// </summary>
        public const int ERROR_RANGE_NOT_FOUND = 0x00000284; // 644

        /// <summary>
        ///     The driver was not loaded because the system is booting into safe mode.
        /// </summary>
        public const int ERROR_NOT_SAFE_MODE_DRIVER = 0x00000286; // 646

        /// <summary>
        ///     The driver was not loaded because it failed its initialization call.
        /// </summary>
        public const int ERROR_FAILED_DRIVER_ENTRY = 0x00000287; // 647

        /// <summary>
        ///     The "%hs" encountered an error while applying power or reading the device configuration. This may be caused by a
        ///     failure of your hardware or by a poor connection.
        /// </summary>
        public const int ERROR_DEVICE_ENUMERATION_ERROR = 0x00000288; // 648

        /// <summary>
        ///     The create operation failed because the name contained at least one mount point which resolves to a volume to which
        ///     the specified device object is not attached.
        /// </summary>
        public const int ERROR_MOUNT_POINT_NOT_RESOLVED = 0x00000289; // 649

        /// <summary>
        ///     The device object parameter is either not a valid device object or is not attached to the volume specified by the
        ///     file name.
        /// </summary>
        public const int ERROR_INVALID_DEVICE_OBJECT_PARAMETER = 0x0000028A; // 650

        /// <summary>
        ///     A Machine Check Error has occurred. Please check the system event log for additional information.
        /// </summary>
        public const int ERROR_MCA_OCCURED = 0x0000028B; // 651

        /// <summary>
        ///     There was error [%2] processing the driver database.
        /// </summary>
        public const int ERROR_DRIVER_DATABASE_ERROR = 0x0000028C; // 652

        /// <summary>
        ///     System hive size has exceeded its limit.
        /// </summary>
        public const int ERROR_SYSTEM_HIVE_TOO_LARGE = 0x0000028D; // 653

        /// <summary>
        ///     The driver could not be loaded because a previous version of the driver is still in memory.
        /// </summary>
        public const int ERROR_DRIVER_FAILED_PRIOR_UNLOAD = 0x0000028E; // 654

        /// <summary>
        ///     {Volume Shadow Copy Service} Please wait while the Volume Shadow Copy Service prepares volume %hs for hibernation.
        /// </summary>
        public const int ERROR_VOLSNAP_PREPARE_HIBERNATE = 0x0000028F; // 655

        /// <summary>
        ///     The system has failed to hibernate (The error code is %hs). Hibernation will be disabled until the system is
        ///     restarted.
        /// </summary>
        public const int ERROR_HIBERNATION_FAILURE = 0x00000290; // 656

        /// <summary>
        ///     The password provided is too long to meet the policy of your user account. Please choose a shorter password.
        /// </summary>
        public const int ERROR_PWD_TOO_LONG = 0x00000291; // 657

        /// <summary>
        ///     The requested operation could not be completed due to a file system limitation.
        /// </summary>
        public const int ERROR_FILE_SYSTEM_LIMITATION = 0x00000299; // 665

        /// <summary>
        ///     An assertion failure has occurred.
        /// </summary>
        public const int ERROR_ASSERTION_FAILURE = 0x0000029C; // 668

        /// <summary>
        ///     An error occurred in the ACPI subsystem.
        /// </summary>
        public const int ERROR_ACPI_ERROR = 0x0000029D; // 669

        /// <summary>
        ///     WOW Assertion Error.
        /// </summary>
        public const int ERROR_WOW_ASSERTION = 0x0000029E; // 670

        /// <summary>
        ///     A device is missing in the system BIOS MPS table. This device will not be used. Please contact your system vendor
        ///     for system BIOS update.
        /// </summary>
        public const int ERROR_PNP_BAD_MPS_TABLE = 0x0000029F; // 671

        /// <summary>
        ///     A translator failed to translate resources.
        /// </summary>
        public const int ERROR_PNP_TRANSLATION_FAILED = 0x000002A0; // 672

        /// <summary>
        ///     A IRQ translator failed to translate resources.
        /// </summary>
        public const int ERROR_PNP_IRQ_TRANSLATION_FAILED = 0x000002A1; // 673

        /// <summary>
        ///     Driver %2 returned invalid ID for a child device (%3).
        /// </summary>
        public const int ERROR_PNP_INVALID_ID = 0x000002A2; // 674

        /// <summary>
        ///     {Kernel Debugger Awakened} the system debugger was awakened by an interrupt.
        /// </summary>
        public const int ERROR_WAKE_SYSTEM_DEBUGGER = 0x000002A3; // 675

        /// <summary>
        ///     {Handles Closed} Handles to objects have been automatically closed as a result of the requested operation.
        /// </summary>
        public const int ERROR_HANDLES_CLOSED = 0x000002A4; // 676

        /// <summary>
        ///     {Too Much Information} The specified access control list (ACL) contained more information than was expected.
        /// </summary>
        public const int ERROR_EXTRANEOUS_INFORMATION = 0x000002A5; // 677

        /// <summary>
        ///     This warning level status indicates that the transaction state already exists for the registry sub-tree, but that a
        ///     transaction commit was previously aborted. The commit has NOT been completed, but has not been rolled back either
        ///     (so it may still be committed if desired).
        /// </summary>
        public const int ERROR_RXACT_COMMIT_NECESSARY = 0x000002A6; // 678

        /// <summary>
        ///     {Media Changed} The media may have changed.
        /// </summary>
        public const int ERROR_MEDIA_CHECK = 0x000002A7; // 679

        /// <summary>
        ///     {GUID Substitution} During the translation of a global identifier (GUID) to a Windows security ID (SID), no
        ///     administratively-defined GUID prefix was found. A substitute prefix was used, which will not compromise system
        ///     security. However, this may provide a more restrictive access than intended.
        /// </summary>
        public const int ERROR_GUID_SUBSTITUTION_MADE = 0x000002A8; // 680

        /// <summary>
        ///     The create operation stopped after reaching a symbolic link.
        /// </summary>
        public const int ERROR_STOPPED_ON_SYMLINK = 0x000002A9; // 681

        /// <summary>
        ///     A long jump has been executed.
        /// </summary>
        public const int ERROR_LONGJUMP = 0x000002AA; // 682

        /// <summary>
        ///     The Plug and Play query operation was not successful.
        /// </summary>
        public const int ERROR_PLUGPLAY_QUERY_VETOED = 0x000002AB; // 683

        /// <summary>
        ///     A frame consolidation has been executed.
        /// </summary>
        public const int ERROR_UNWIND_CONSOLIDATE = 0x000002AC; // 684

        /// <summary>
        ///     {Registry Hive Recovered} Registry hive (file): %hs was corrupted and it has been recovered. Some data might have
        ///     been lost.
        /// </summary>
        public const int ERROR_REGISTRY_HIVE_RECOVERED = 0x000002AD; // 685

        /// <summary>
        ///     The application is attempting to run executable code from the module %hs. This may be insecure. An alternative,
        ///     %hs, is available. Should the application use the secure module %hs?
        /// </summary>
        public const int ERROR_DLL_MIGHT_BE_INSECURE = 0x000002AE; // 686

        /// <summary>
        ///     The application is loading executable code from the module %hs. This is secure, but may be incompatible with
        ///     previous releases of the operating system. An alternative, %hs, is available. Should the application use the secure
        ///     module %hs?
        /// </summary>
        public const int ERROR_DLL_MIGHT_BE_INCOMPATIBLE = 0x000002AF; // 687

        /// <summary>
        ///     Debugger did not handle the exception.
        /// </summary>
        public const int ERROR_DBG_EXCEPTION_NOT_HANDLED = 0x000002B0; // 688

        /// <summary>
        ///     Debugger will reply later.
        /// </summary>
        public const int ERROR_DBG_REPLY_LATER = 0x000002B1; // 689

        /// <summary>
        ///     Debugger cannot provide handle.
        /// </summary>
        public const int ERROR_DBG_UNABLE_TO_PROVIDE_HANDLE = 0x000002B2; // 690

        /// <summary>
        ///     Debugger terminated thread.
        /// </summary>
        public const int ERROR_DBG_TERMINATE_THREAD = 0x000002B3; // 691

        /// <summary>
        ///     Debugger terminated process.
        /// </summary>
        public const int ERROR_DBG_TERMINATE_PROCESS = 0x000002B4; // 692

        /// <summary>
        ///     Debugger got control C.
        /// </summary>
        public const int ERROR_DBG_CONTROL_C = 0x000002B5; // 693

        /// <summary>
        ///     Debugger printed exception on control C.
        /// </summary>
        public const int ERROR_DBG_PRINTEXCEPTION_C = 0x000002B6; // 694

        /// <summary>
        ///     Debugger received RIP exception.
        /// </summary>
        public const int ERROR_DBG_RIPEXCEPTION = 0x000002B7; // 695

        /// <summary>
        ///     Debugger received control break.
        /// </summary>
        public const int ERROR_DBG_CONTROL_BREAK = 0x000002B8; // 696

        /// <summary>
        ///     Debugger command communication exception.
        /// </summary>
        public const int ERROR_DBG_COMMAND_EXCEPTION = 0x000002B9; // 697

        /// <summary>
        ///     {Object Exists} An attempt was made to create an object and the object name already existed.
        /// </summary>
        public const int ERROR_OBJECT_NAME_EXISTS = 0x000002BA; // 698

        /// <summary>
        ///     {Thread Suspended} A thread termination occurred while the thread was suspended. The thread was resumed, and
        ///     termination proceeded.
        /// </summary>
        public const int ERROR_THREAD_WAS_SUSPENDED = 0x000002BB; // 699

        /// <summary>
        ///     {Image Relocated} An image file could not be mapped at the address specified in the image file. Local fixups must
        ///     be performed on this image.
        /// </summary>
        public const int ERROR_IMAGE_NOT_AT_BASE = 0x000002BC; // 700

        /// <summary>
        ///     This informational level status indicates that a specified registry sub-tree transaction state did not yet exist
        ///     and had to be created.
        /// </summary>
        public const int ERROR_RXACT_STATE_CREATED = 0x000002BD; // 701

        /// <summary>
        ///     {Segment Load} A virtual DOS machine (VDM) is loading, unloading, or moving an MS-DOS or Win16 program segment
        ///     image. An exception is raised so a debugger can load, unload or track symbols and breakpoints within these 16-bit
        ///     segments.
        /// </summary>
        public const int ERROR_SEGMENT_NOTIFICATION = 0x000002BE; // 702

        /// <summary>
        ///     {Invalid Current Directory} The process cannot switch to the startup current directory %hs. Select OK to set
        ///     current directory to %hs, or select CANCEL to exit.
        /// </summary>
        public const int ERROR_BAD_CURRENT_DIRECTORY = 0x000002BF; // 703

        /// <summary>
        ///     {Redundant Read} To satisfy a read request, the NT fault-tolerant file system successfully read the requested data
        ///     from a redundant copy. This was done because the file system encountered a failure on a member of the
        ///     fault-tolerant volume, but was unable to reassign the failing area of the device.
        /// </summary>
        public const int ERROR_FT_READ_RECOVERY_FROM_BACKUP = 0x000002C0; // 704

        /// <summary>
        ///     {Redundant Write} To satisfy a write request, the NT fault-tolerant file system successfully wrote a redundant copy
        ///     of the information. This was done because the file system encountered a failure on a member of the fault-tolerant
        ///     volume, but was not able to reassign the failing area of the device.
        /// </summary>
        public const int ERROR_FT_WRITE_RECOVERY = 0x000002C1; // 705

        /// <summary>
        ///     {Machine Type Mismatch} The image file %hs is valid, but is for a machine type other than the current machine.
        ///     Select OK to continue, or CANCEL to fail the DLL load.
        /// </summary>
        public const int ERROR_IMAGE_MACHINE_TYPE_MISMATCH = 0x000002C2; // 706

        /// <summary>
        ///     {Partial Data Received} The network transport returned partial data to its client. The remaining data will be sent
        ///     later.
        /// </summary>
        public const int ERROR_RECEIVE_PARTIAL = 0x000002C3; // 707

        /// <summary>
        ///     {Expedited Data Received} The network transport returned data to its client that was marked as expedited by the
        ///     remote system.
        /// </summary>
        public const int ERROR_RECEIVE_EXPEDITED = 0x000002C4; // 708

        /// <summary>
        ///     {Partial Expedited Data Received} The network transport returned partial data to its client and this data was
        ///     marked as expedited by the remote system. The remaining data will be sent later.
        /// </summary>
        public const int ERROR_RECEIVE_PARTIAL_EXPEDITED = 0x000002C5; // 709

        /// <summary>
        ///     {TDI Event Done} The TDI indication has completed successfully.
        /// </summary>
        public const int ERROR_EVENT_DONE = 0x000002C6; // 710

        /// <summary>
        ///     {TDI Event Pending} The TDI indication has entered the pending state.
        /// </summary>
        public const int ERROR_EVENT_PENDING = 0x000002C7; // 711

        /// <summary>
        ///     Checking file system on %wZ.
        /// </summary>
        public const int ERROR_CHECKING_FILE_SYSTEM = 0x000002C8; // 712

        /// <summary>
        ///     {Fatal Application Exit} %hs.
        /// </summary>
        public const int ERROR_FATAL_APP_EXIT = 0x000002C9; // 713

        /// <summary>
        ///     The specified registry key is referenced by a predefined handle.
        /// </summary>
        public const int ERROR_PREDEFINED_HANDLE = 0x000002CA; // 714

        /// <summary>
        ///     {Page Unlocked} The page protection of a locked page was changed to 'No Access' and the page was unlocked from
        ///     memory and from the process.
        /// </summary>
        public const int ERROR_WAS_UNLOCKED = 0x000002CB; // 715

        /// <summary>
        ///     %hs
        /// </summary>
        public const int ERROR_SERVICE_NOTIFICATION = 0x000002CC; // 716

        /// <summary>
        ///     {Page Locked} One of the pages to lock was already locked.
        /// </summary>
        public const int ERROR_WAS_LOCKED = 0x000002CD; // 717

        /// <summary>
        ///     Application popup: %1 : %2
        /// </summary>
        public const int ERROR_LOG_HARD_ERROR = 0x000002CE; // 718

        /// <summary>
        ///     ERROR_ALREADY_WIN32
        /// </summary>
        public const int ERROR_ALREADY_WIN32 = 0x000002CF; // 719

        /// <summary>
        ///     {Machine Type Mismatch} The image file %hs is valid, but is for a machine type other than the current machine.
        /// </summary>
        public const int ERROR_IMAGE_MACHINE_TYPE_MISMATCH_EXE = 0x000002D0; // 720

        /// <summary>
        ///     A yield execution was performed and no thread was available to run.
        /// </summary>
        public const int ERROR_NO_YIELD_PERFORMED = 0x000002D1; // 721

        /// <summary>
        ///     The resumable flag to a timer API was ignored.
        /// </summary>
        public const int ERROR_TIMER_RESUME_IGNORED = 0x000002D2; // 722

        /// <summary>
        ///     The arbiter has deferred arbitration of these resources to its parent.
        /// </summary>
        public const int ERROR_ARBITRATION_UNHANDLED = 0x000002D3; // 723

        /// <summary>
        ///     The inserted CardBus device cannot be started because of a configuration error on "%hs".
        /// </summary>
        public const int ERROR_CARDBUS_NOT_SUPPORTED = 0x000002D4; // 724

        /// <summary>
        ///     The CPUs in this multiprocessor system are not all the same revision level. To use all processors the operating
        ///     system restricts itself to the features of the least capable processor in the system. Should problems occur with
        ///     this system, contact the CPU manufacturer to see if this mix of processors is supported.
        /// </summary>
        public const int ERROR_MP_PROCESSOR_MISMATCH = 0x000002D5; // 725

        /// <summary>
        ///     The system was put into hibernation.
        /// </summary>
        public const int ERROR_HIBERNATED = 0x000002D6; // 726

        /// <summary>
        ///     The system was resumed from hibernation.
        /// </summary>
        public const int ERROR_RESUME_HIBERNATION = 0x000002D7; // 727

        /// <summary>
        ///     Windows has detected that the system firmware (BIOS) was updated [previous firmware date = %2, current firmware
        ///     date %3].
        /// </summary>
        public const int ERROR_FIRMWARE_UPDATED = 0x000002D8; // 728

        /// <summary>
        ///     A device driver is leaking locked I/O pages causing system degradation. The system has automatically enabled
        ///     tracking code in order to try and catch the culprit.
        /// </summary>
        public const int ERROR_DRIVERS_LEAKING_LOCKED_PAGES = 0x000002D9; // 729

        /// <summary>
        ///     The system has awoken.
        /// </summary>
        public const int ERROR_WAKE_SYSTEM = 0x000002DA; // 730

        /// <summary>
        ///     ERROR_WAIT_1
        /// </summary>
        public const int ERROR_WAIT_1 = 0x000002DB; // 731

        /// <summary>
        ///     ERROR_WAIT_2
        /// </summary>
        public const int ERROR_WAIT_2 = 0x000002DC; // 732

        /// <summary>
        ///     ERROR_WAIT_3
        /// </summary>
        public const int ERROR_WAIT_3 = 0x000002DD; // 733

        /// <summary>
        ///     ERROR_WAIT_63
        /// </summary>
        public const int ERROR_WAIT_63 = 0x000002DE; // 734

        /// <summary>
        ///     ERROR_ABANDONED_WAIT_0
        /// </summary>
        public const int ERROR_ABANDONED_WAIT_0 = 0x000002DF; // 735

        /// <summary>
        ///     ERROR_ABANDONED_WAIT_63
        /// </summary>
        public const int ERROR_ABANDONED_WAIT_63 = 0x000002E0; // 736

        /// <summary>
        ///     ERROR_USER_APC
        /// </summary>
        public const int ERROR_USER_APC = 0x000002E1; // 737

        /// <summary>
        ///     ERROR_KERNEL_APC
        /// </summary>
        public const int ERROR_KERNEL_APC = 0x000002E2; // 738

        /// <summary>
        ///     ERROR_ALERTED
        /// </summary>
        public const int ERROR_ALERTED = 0x000002E3; // 739

        /// <summary>
        ///     The requested operation requires elevation.
        /// </summary>
        public const int ERROR_ELEVATION_REQUIRED = 0x000002E4; // 740

        /// <summary>
        ///     A re parse should be performed by the Object Manager since the name of the file resulted in a symbolic link.
        /// </summary>
        public const int ERROR_REPARSE = 0x000002E5; // 741

        /// <summary>
        ///     An open/create operation completed while an oplock break is underway.
        /// </summary>
        public const int ERROR_OPLOCK_BREAK_IN_PROGRESS = 0x000002E6; // 742

        /// <summary>
        ///     A new volume has been mounted by a file system.
        /// </summary>
        public const int ERROR_VOLUME_MOUNTED = 0x000002E7; // 743

        /// <summary>
        ///     This success level status indicates that the transaction state already exists for the registry sub-tree, but that a
        ///     transaction commit was previously aborted. The commit has now been completed.
        /// </summary>
        public const int ERROR_RXACT_COMMITTED = 0x000002E8; // 744

        /// <summary>
        ///     This indicates that a notify change request has been completed due to closing the handle which made the notify
        ///     change request.
        /// </summary>
        public const int ERROR_NOTIFY_CLEANUP = 0x000002E9; // 745

        /// <summary>
        ///     {Connect Failure on Primary Transport} An attempt was made to connect to the remote server %hs on the primary
        ///     transport, but the connection failed. The computer WAS able to connect on a secondary transport.
        /// </summary>
        public const int ERROR_PRIMARY_TRANSPORT_CONNECT_FAILED = 0x000002EA; // 746

        /// <summary>
        ///     Page fault was a transition fault.
        /// </summary>
        public const int ERROR_PAGE_FAULT_TRANSITION = 0x000002EB; // 747

        /// <summary>
        ///     Page fault was a demand zero fault.
        /// </summary>
        public const int ERROR_PAGE_FAULT_DEMAND_ZERO = 0x000002EC; // 748

        /// <summary>
        ///     Page fault was a demand zero fault.
        /// </summary>
        public const int ERROR_PAGE_FAULT_COPY_ON_WRITE = 0x000002ED; // 749

        /// <summary>
        ///     Page fault was a demand zero fault.
        /// </summary>
        public const int ERROR_PAGE_FAULT_GUARD_PAGE = 0x000002EE; // 750

        /// <summary>
        ///     Page fault was satisfied by reading from a secondary storage device.
        /// </summary>
        public const int ERROR_PAGE_FAULT_PAGING_FILE = 0x000002EF; // 751

        /// <summary>
        ///     Cached page was locked during operation.
        /// </summary>
        public const int ERROR_CACHE_PAGE_LOCKED = 0x000002F0; // 752

        /// <summary>
        ///     Crash dump exists in paging file.
        /// </summary>
        public const int ERROR_CRASH_DUMP = 0x000002F1; // 753

        /// <summary>
        ///     Specified buffer contains all zeros.
        /// </summary>
        public const int ERROR_BUFFER_ALL_ZEROS = 0x000002F2; // 754

        /// <summary>
        ///     A re parse should be performed by the Object Manager since the name of the file resulted in a symbolic link.
        /// </summary>
        public const int ERROR_REPARSE_OBJECT = 0x000002F3; // 755

        /// <summary>
        ///     The device has succeeded a query-stop and its resource requirements have changed.
        /// </summary>
        public const int ERROR_RESOURCE_REQUIREMENTS_CHANGED = 0x000002F4; // 756

        /// <summary>
        ///     The translator has translated these resources into the global space and no further translations should be
        ///     performed.
        /// </summary>
        public const int ERROR_TRANSLATION_COMPLETE = 0x000002F5; // 757

        /// <summary>
        ///     A process being terminated has no threads to terminate.
        /// </summary>
        public const int ERROR_NOTHING_TO_TERMINATE = 0x000002F6; // 758

        /// <summary>
        ///     The specified process is not part of a job.
        /// </summary>
        public const int ERROR_PROCESS_NOT_IN_JOB = 0x000002F7; // 759

        /// <summary>
        ///     The specified process is part of a job.
        /// </summary>
        public const int ERROR_PROCESS_IN_JOB = 0x000002F8; // 760

        /// <summary>
        ///     {Volume Shadow Copy Service} The system is now ready for hibernation.
        /// </summary>
        public const int ERROR_VOLSNAP_HIBERNATE_READY = 0x000002F9; // 761

        /// <summary>
        ///     A file system or file system filter driver has successfully completed an FsFilter operation.
        /// </summary>
        public const int ERROR_FSFILTER_OP_COMPLETED_SUCCESSFULLY = 0x000002FA; // 762

        /// <summary>
        ///     The specified interrupt vector was already connected.
        /// </summary>
        public const int ERROR_INTERRUPT_VECTOR_ALREADY_CONNECTED = 0x000002FB; // 763

        /// <summary>
        ///     The specified interrupt vector is still connected.
        /// </summary>
        public const int ERROR_INTERRUPT_STILL_CONNECTED = 0x000002FC; // 764

        /// <summary>
        ///     An operation is blocked waiting for an oplock.
        /// </summary>
        public const int ERROR_WAIT_FOR_OPLOCK = 0x000002FD; // 765

        /// <summary>
        ///     Debugger handled exception.
        /// </summary>
        public const int ERROR_DBG_EXCEPTION_HANDLED = 0x000002FE; // 766

        /// <summary>
        ///     Debugger continued.
        /// </summary>
        public const int ERROR_DBG_CONTINUE = 0x000002FF; // 767

        /// <summary>
        ///     An exception occurred in a user mode callback and the kernel callback frame should be removed.
        /// </summary>
        public const int ERROR_CALLBACK_POP_STACK = 0x00000300; // 768

        /// <summary>
        ///     Compression is disabled for this volume.
        /// </summary>
        public const int ERROR_COMPRESSION_DISABLED = 0x00000301; // 769

        /// <summary>
        ///     The data provider cannot fetch backwards through a result set.
        /// </summary>
        public const int ERROR_CANTFETCHBACKWARDS = 0x00000302; // 770

        /// <summary>
        ///     The data provider cannot scroll backwards through a result set.
        /// </summary>
        public const int ERROR_CANTSCROLLBACKWARDS = 0x00000303; // 771

        /// <summary>
        ///     The data provider requires that previously fetched data is released before asking for more data.
        /// </summary>
        public const int ERROR_ROWSNOTRELEASED = 0x00000304; // 772

        /// <summary>
        ///     The data provider was not able to interpret the flags set for a column binding in an accessor.
        /// </summary>
        public const int ERROR_BAD_ACCESSOR_FLAGS = 0x00000305; // 773

        /// <summary>
        ///     One or more errors occurred while processing the request.
        /// </summary>
        public const int ERROR_ERRORS_ENCOUNTERED = 0x00000306; // 774

        /// <summary>
        ///     The implementation is not capable of performing the request.
        /// </summary>
        public const int ERROR_NOT_CAPABLE = 0x00000307; // 775

        /// <summary>
        ///     The client of a component requested an operation which is not valid given the state of the component instance.
        /// </summary>
        public const int ERROR_REQUEST_OUT_OF_SEQUENCE = 0x00000308; // 776

        /// <summary>
        ///     A version number could not be parsed.
        /// </summary>
        public const int ERROR_VERSION_PARSE_ERROR = 0x00000309; // 777

        /// <summary>
        ///     The iterator's start position is invalid.
        /// </summary>
        public const int ERROR_BADSTARTPOSITION = 0x0000030A; // 778

        /// <summary>
        ///     The hardware has reported an uncorrectable memory error.
        /// </summary>
        public const int ERROR_MEMORY_HARDWARE = 0x0000030B; // 779

        /// <summary>
        ///     The attempted operation required self healing to be enabled.
        /// </summary>
        public const int ERROR_DISK_REPAIR_DISABLED = 0x0000030C; // 780

        /// <summary>
        ///     The Desktop heap encountered an error while allocating session memory. There is more information in the system
        ///     event log.
        /// </summary>
        public const int ERROR_INSUFFICIENT_RESOURCE_FOR_SPECIFIED_SHARED_SECTION_SIZE = 0x0000030D; // 781

        /// <summary>
        ///     The system power state is transitioning from %2 to %3.
        /// </summary>
        public const int ERROR_SYSTEM_POWERSTATE_TRANSITION = 0x0000030E; // 782

        /// <summary>
        ///     The system power state is transitioning from %2 to %3 but could enter %4.
        /// </summary>
        public const int ERROR_SYSTEM_POWERSTATE_COMPLEX_TRANSITION = 0x0000030F; // 783

        /// <summary>
        ///     A thread is getting dispatched with MCA EXCEPTION because of MCA.
        /// </summary>
        public const int ERROR_MCA_EXCEPTION = 0x00000310; // 784

        /// <summary>
        ///     Access to %1 is monitored by policy rule %2.
        /// </summary>
        public const int ERROR_ACCESS_AUDIT_BY_POLICY = 0x00000311; // 785

        /// <summary>
        ///     Access to %1 has been restricted by your Administrator by policy rule %2.
        /// </summary>
        public const int ERROR_ACCESS_DISABLED_NO_SAFER_UI_BY_POLICY = 0x00000312; // 786

        /// <summary>
        ///     A valid hibernation file has been invalidated and should be abandoned.
        /// </summary>
        public const int ERROR_ABANDON_HIBERFILE = 0x00000313; // 787

        /// <summary>
        ///     {Delayed Write Failed} Windows was unable to save all the data for the file %hs; the data has been lost. This error
        ///     may be caused by network connectivity issues. Please try to save this file elsewhere.
        /// </summary>
        public const int ERROR_LOST_WRITEBEHIND_DATA_NETWORK_DISCONNECTED = 0x00000314; // 788

        /// <summary>
        ///     {Delayed Write Failed} Windows was unable to save all the data for the file %hs; the data has been lost. This error
        ///     was returned by the server on which the file exists. Please try to save this file elsewhere.
        /// </summary>
        public const int ERROR_LOST_WRITEBEHIND_DATA_NETWORK_SERVER_ERROR = 0x00000315; // 789

        /// <summary>
        ///     {Delayed Write Failed} Windows was unable to save all the data for the file %hs; the data has been lost. This error
        ///     may be caused if the device has been removed or the media is write-protected.
        /// </summary>
        public const int ERROR_LOST_WRITEBEHIND_DATA_LOCAL_DISK_ERROR = 0x00000316; // 790

        /// <summary>
        ///     The resources required for this device conflict with the MCFG table.
        /// </summary>
        public const int ERROR_BAD_MCFG_TABLE = 0x00000317; // 791

        /// <summary>
        ///     The volume repair could not be performed while it is online. Please schedule to take the volume offline so that it
        ///     can be repaired.
        /// </summary>
        public const int ERROR_DISK_REPAIR_REDIRECTED = 0x00000318; // 792

        /// <summary>
        ///     The volume repair was not successful.
        /// </summary>
        public const int ERROR_DISK_REPAIR_UNSUCCESSFUL = 0x00000319; // 793

        /// <summary>
        ///     One of the volume corruption logs is full. Further corruptions that may be detected won't be logged.
        /// </summary>
        public const int ERROR_CORRUPT_LOG_OVERFULL = 0x0000031A; // 794

        /// <summary>
        ///     One of the volume corruption logs is internally corrupted and needs to be recreated. The volume may contain
        ///     undetected corruptions and must be scanned.
        /// </summary>
        public const int ERROR_CORRUPT_LOG_CORRUPTED = 0x0000031B; // 795

        /// <summary>
        ///     One of the volume corruption logs is unavailable for being operated on.
        /// </summary>
        public const int ERROR_CORRUPT_LOG_UNAVAILABLE = 0x0000031C; // 796

        /// <summary>
        ///     One of the volume corruption logs was deleted while still having corruption records in them. The volume contains
        ///     detected corruptions and must be scanned.
        /// </summary>
        public const int ERROR_CORRUPT_LOG_DELETED_FULL = 0x0000031D; // 797

        /// <summary>
        ///     One of the volume corruption logs was cleared by chkdsk and no longer contains real corruptions.
        /// </summary>
        public const int ERROR_CORRUPT_LOG_CLEARED = 0x0000031E; // 798

        /// <summary>
        ///     Orphaned files exist on the volume but could not be recovered because no more new names could be created in the
        ///     recovery directory. Files must be moved from the recovery directory.
        /// </summary>
        public const int ERROR_ORPHAN_NAME_EXHAUSTED = 0x0000031F; // 799

        /// <summary>
        ///     The oplock that was associated with this handle is now associated with a different handle.
        /// </summary>
        public const int ERROR_OPLOCK_SWITCHED_TO_NEW_HANDLE = 0x00000320; // 800

        /// <summary>
        ///     An oplock of the requested level cannot be granted. An oplock of a lower level may be available.
        /// </summary>
        public const int ERROR_CANNOT_GRANT_REQUESTED_OPLOCK = 0x00000321; // 801

        /// <summary>
        ///     The operation did not complete successfully because it would cause an oplock to be broken. The caller has requested
        ///     that existing oplocks not be broken.
        /// </summary>
        public const int ERROR_CANNOT_BREAK_OPLOCK = 0x00000322; // 802

        /// <summary>
        ///     The handle with which this oplock was associated has been closed. The oplock is now broken.
        /// </summary>
        public const int ERROR_OPLOCK_HANDLE_CLOSED = 0x00000323; // 803

        /// <summary>
        ///     The specified access control entry (ACE) does not contain a condition.
        /// </summary>
        public const int ERROR_NO_ACE_CONDITION = 0x00000324; // 804

        /// <summary>
        ///     The specified access control entry (ACE) contains an invalid condition.
        /// </summary>
        public const int ERROR_INVALID_ACE_CONDITION = 0x00000325; // 805

        /// <summary>
        ///     Access to the specified file handle has been revoked.
        /// </summary>
        public const int ERROR_FILE_HANDLE_REVOKED = 0x00000326; // 806

        /// <summary>
        ///     An image file was mapped at a different address from the one specified in the image file but fixups will still be
        ///     automatically performed on the image.
        /// </summary>
        public const int ERROR_IMAGE_AT_DIFFERENT_BASE = 0x00000327; // 807

        /// <summary>
        ///     Access to the extended attribute was denied.
        /// </summary>
        public const int ERROR_EA_ACCESS_DENIED = 0x000003E2; // 994

        /// <summary>
        ///     The I/O operation has been aborted because of either a thread exit or an application request.
        /// </summary>
        public const int ERROR_OPERATION_ABORTED = 0x000003E3; // 995

        /// <summary>
        ///     Overlapped I/O event is not in a signaled state.
        /// </summary>
        public const int ERROR_IO_INCOMPLETE = 0x000003E4; // 996

        /// <summary>
        ///     Overlapped I/O operation is in progress.
        /// </summary>
        public const int ERROR_IO_PENDING = 0x000003E5; // 997

        /// <summary>
        ///     Invalid access to memory location.
        /// </summary>
        public const int ERROR_NOACCESS = 0x000003E6; // 998

        /// <summary>
        ///     Error performing in page operation.
        /// </summary>
        public const int ERROR_SWAPERROR = 0x000003E7; // 999

        #endregion

        #region 1000 - 1299

        /// <summary>
        ///     Recursion too deep; the stack overflowed.
        /// </summary>
        public const int ERROR_STACK_OVERFLOW = 0x000003E9; // 1001

        /// <summary>
        ///     The window cannot act on the sent message.
        /// </summary>
        public const int ERROR_INVALID_MESSAGE = 0x000003EA; // 1002

        /// <summary>
        ///     Cannot complete this function.
        /// </summary>
        public const int ERROR_CAN_NOT_COMPLETE = 0x000003EB; // 1003

        /// <summary>
        ///     Invalid flags.
        /// </summary>
        public const int ERROR_INVALID_FLAGS = 0x000003EC; // 1004

        /// <summary>
        ///     The volume does not contain a recognized file system. Please make sure that all required file system drivers are
        ///     loaded and that the volume is not corrupted.
        /// </summary>
        public const int ERROR_UNRECOGNIZED_VOLUME = 0x000003ED; // 1005

        /// <summary>
        ///     The volume for a file has been externally altered so that the opened file is no longer valid.
        /// </summary>
        public const int ERROR_FILE_INVALID = 0x000003EE; // 1006

        /// <summary>
        ///     The requested operation cannot be performed in full-screen mode.
        /// </summary>
        public const int ERROR_FULLSCREEN_MODE = 0x000003EF; // 1007

        /// <summary>
        ///     An attempt was made to reference a token that does not exist.
        /// </summary>
        public const int ERROR_NO_TOKEN = 0x000003F0; // 1008

        /// <summary>
        ///     The configuration registry database is corrupt.
        /// </summary>
        public const int ERROR_BADDB = 0x000003F1; // 1009

        /// <summary>
        ///     The configuration registry key is invalid.
        /// </summary>
        public const int ERROR_BADKEY = 0x000003F2; // 1010

        /// <summary>
        ///     The configuration registry key could not be opened.
        /// </summary>
        public const int ERROR_CANTOPEN = 0x000003F3; // 1011

        /// <summary>
        ///     The configuration registry key could not be read.
        /// </summary>
        public const int ERROR_CANTREAD = 0x000003F4; // 1012

        /// <summary>
        ///     The configuration registry key could not be written.
        /// </summary>
        public const int ERROR_CANTWRITE = 0x000003F5; // 1013

        /// <summary>
        ///     One of the files in the registry database had to be recovered by use of a log or alternate copy. The recovery was
        ///     successful.
        /// </summary>
        public const int ERROR_REGISTRY_RECOVERED = 0x000003F6; // 1014

        /// <summary>
        ///     The registry is corrupted. The structure of one of the files containing registry data is corrupted, or the system's
        ///     memory image of the file is corrupted, or the file could not be recovered because the alternate copy or log was
        ///     absent or corrupted.
        /// </summary>
        public const int ERROR_REGISTRY_CORRUPT = 0x000003F7; // 1015

        /// <summary>
        ///     An I/O operation initiated by the registry failed irrecoverably. The registry could not read in, or write out, or
        ///     flush, one of the files that contain the system's image of the registry.
        /// </summary>
        public const int ERROR_REGISTRY_IO_FAILED = 0x000003F8; // 1016

        /// <summary>
        ///     The system has attempted to load or restore a file into the registry, but the specified file is not in a registry
        ///     file format.
        /// </summary>
        public const int ERROR_NOT_REGISTRY_FILE = 0x000003F9; // 1017

        /// <summary>
        ///     Illegal operation attempted on a registry key that has been marked for deletion.
        /// </summary>
        public const int ERROR_KEY_DELETED = 0x000003FA; // 1018

        /// <summary>
        ///     System could not allocate the required space in a registry log.
        /// </summary>
        public const int ERROR_NO_LOG_SPACE = 0x000003FB; // 1019

        /// <summary>
        ///     Cannot create a symbolic link in a registry key that already has subkeys or values.
        /// </summary>
        public const int ERROR_KEY_HAS_CHILDREN = 0x000003FC; // 1020

        /// <summary>
        ///     Cannot create a stable subkey under a volatile parent key.
        /// </summary>
        public const int ERROR_CHILD_MUST_BE_VOLATILE = 0x000003FD; // 1021

        /// <summary>
        ///     A notify change request is being completed and the information is not being returned in the caller's buffer. The
        ///     caller now needs to enumerate the files to find the changes.
        /// </summary>
        public const int ERROR_NOTIFY_ENUM_DIR = 0x000003FE; // 1022

        /// <summary>
        ///     A stop control has been sent to a service that other running services are dependent on.
        /// </summary>
        public const int ERROR_DEPENDENT_SERVICES_RUNNING = 0x0000041B; // 1051

        /// <summary>
        ///     The requested control is not valid for this service.
        /// </summary>
        public const int ERROR_INVALID_SERVICE_CONTROL = 0x0000041C; // 1052

        /// <summary>
        ///     The service did not respond to the start or control request in a timely fashion.
        /// </summary>
        public const int ERROR_SERVICE_REQUEST_TIMEOUT = 0x0000041D; // 1053

        /// <summary>
        ///     A thread could not be created for the service.
        /// </summary>
        public const int ERROR_SERVICE_NO_THREAD = 0x0000041E; // 1054

        /// <summary>
        ///     The service database is locked.
        /// </summary>
        public const int ERROR_SERVICE_DATABASE_LOCKED = 0x0000041F; // 1055

        /// <summary>
        ///     An instance of the service is already running.
        /// </summary>
        public const int ERROR_SERVICE_ALREADY_RUNNING = 0x00000420; // 1056

        /// <summary>
        ///     The account name is invalid or does not exist, or the password is invalid for the account name specified.
        /// </summary>
        public const int ERROR_INVALID_SERVICE_ACCOUNT = 0x00000421; // 1057

        /// <summary>
        ///     The service cannot be started, either because it is disabled or because it has no enabled devices associated with
        ///     it.
        /// </summary>
        public const int ERROR_SERVICE_DISABLED = 0x00000422; // 1058

        /// <summary>
        ///     Circular service dependency was specified.
        /// </summary>
        public const int ERROR_CIRCULAR_DEPENDENCY = 0x00000423; // 1059

        /// <summary>
        ///     The specified service does not exist as an installed service.
        /// </summary>
        public const int ERROR_SERVICE_DOES_NOT_EXIST = 0x00000424; // 1060

        /// <summary>
        ///     The service cannot accept control messages at this time.
        /// </summary>
        public const int ERROR_SERVICE_CANNOT_ACCEPT_CTRL = 0x00000425; // 1061

        /// <summary>
        ///     The service has not been started.
        /// </summary>
        public const int ERROR_SERVICE_NOT_ACTIVE = 0x00000426; // 1062

        /// <summary>
        ///     The service process could not connect to the service controller.
        /// </summary>
        public const int ERROR_FAILED_SERVICE_CONTROLLER_CONNECT = 0x00000427; // 1063

        /// <summary>
        ///     An exception occurred in the service when handling the control request.
        /// </summary>
        public const int ERROR_EXCEPTION_IN_SERVICE = 0x00000428; // 1064

        /// <summary>
        ///     The database specified does not exist.
        /// </summary>
        public const int ERROR_DATABASE_DOES_NOT_EXIST = 0x00000429; // 1065

        /// <summary>
        ///     The service has returned a service-specific error code.
        /// </summary>
        public const int ERROR_SERVICE_SPECIFIC_ERROR = 0x0000042A; // 1066

        /// <summary>
        ///     The process terminated unexpectedly.
        /// </summary>
        public const int ERROR_PROCESS_ABORTED = 0x0000042B; // 1067

        /// <summary>
        ///     The dependency service or group failed to start.
        /// </summary>
        public const int ERROR_SERVICE_DEPENDENCY_FAIL = 0x0000042C; // 1068

        /// <summary>
        ///     The service did not start due to a logon failure.
        /// </summary>
        public const int ERROR_SERVICE_LOGON_FAILED = 0x0000042D; // 1069

        /// <summary>
        ///     After starting, the service hung in a start-pending state.
        /// </summary>
        public const int ERROR_SERVICE_START_HANG = 0x0000042E; // 1070

        /// <summary>
        ///     The specified service database lock is invalid.
        /// </summary>
        public const int ERROR_INVALID_SERVICE_LOCK = 0x0000042F; // 1071

        /// <summary>
        ///     The specified service has been marked for deletion.
        /// </summary>
        public const int ERROR_SERVICE_MARKED_FOR_DELETE = 0x00000430; // 1072

        /// <summary>
        ///     The specified service already exists.
        /// </summary>
        public const int ERROR_SERVICE_EXISTS = 0x00000431; // 1073

        /// <summary>
        ///     The system is currently running with the last-known-good configuration.
        /// </summary>
        public const int ERROR_ALREADY_RUNNING_LKG = 0x00000432; // 1074

        /// <summary>
        ///     The dependency service does not exist or has been marked for deletion.
        /// </summary>
        public const int ERROR_SERVICE_DEPENDENCY_DELETED = 0x00000433; // 1075

        /// <summary>
        ///     The current boot has already been accepted for use as the last-known-good control set.
        /// </summary>
        public const int ERROR_BOOT_ALREADY_ACCEPTED = 0x00000434; // 1076

        /// <summary>
        ///     No attempts to start the service have been made since the last boot.
        /// </summary>
        public const int ERROR_SERVICE_NEVER_STARTED = 0x00000435; // 1077

        /// <summary>
        ///     The name is already in use as either a service name or a service display name.
        /// </summary>
        public const int ERROR_DUPLICATE_SERVICE_NAME = 0x00000436; // 1078

        /// <summary>
        ///     The account specified for this service is different from the account specified for other services running in the
        ///     same process.
        /// </summary>
        public const int ERROR_DIFFERENT_SERVICE_ACCOUNT = 0x00000437; // 1079

        /// <summary>
        ///     Failure actions can only be set for Win32 services, not for drivers.
        /// </summary>
        public const int ERROR_CANNOT_DETECT_DRIVER_FAILURE = 0x00000438; // 1080

        /// <summary>
        ///     This service runs in the same process as the service control manager. Therefore, the service control manager cannot
        ///     take action if this service's process terminates unexpectedly.
        /// </summary>
        public const int ERROR_CANNOT_DETECT_PROCESS_ABORT = 0x00000439; // 1081

        /// <summary>
        ///     No recovery program has been configured for this service.
        /// </summary>
        public const int ERROR_NO_RECOVERY_PROGRAM = 0x0000043A; // 1082

        /// <summary>
        ///     The executable program that this service is configured to run in does not implement the service.
        /// </summary>
        public const int ERROR_SERVICE_NOT_IN_EXE = 0x0000043B; // 1083

        /// <summary>
        ///     This service cannot be started in Safe Mode.
        /// </summary>
        public const int ERROR_NOT_SAFEBOOT_SERVICE = 0x0000043C; // 1084

        /// <summary>
        ///     The physical end of the tape has been reached.
        /// </summary>
        public const int ERROR_END_OF_MEDIA = 0x0000044C; // 1100

        /// <summary>
        ///     A tape access reached a filemark.
        /// </summary>
        public const int ERROR_FILEMARK_DETECTED = 0x0000044D; // 1101

        /// <summary>
        ///     The beginning of the tape or a partition was encountered.
        /// </summary>
        public const int ERROR_BEGINNING_OF_MEDIA = 0x0000044E; // 1102

        /// <summary>
        ///     A tape access reached the end of a set of files.
        /// </summary>
        public const int ERROR_SETMARK_DETECTED = 0x0000044F; // 1103

        /// <summary>
        ///     No more data is on the tape.
        /// </summary>
        public const int ERROR_NO_DATA_DETECTED = 0x00000450; // 1104

        /// <summary>
        ///     Tape could not be partitioned.
        /// </summary>
        public const int ERROR_PARTITION_FAILURE = 0x00000451; // 1105

        /// <summary>
        ///     When accessing a new tape of a multi-volume partition, the current block size is incorrect.
        /// </summary>
        public const int ERROR_INVALID_BLOCK_LENGTH = 0x00000452; // 1106

        /// <summary>
        ///     Tape partition information could not be found when loading a tape.
        /// </summary>
        public const int ERROR_DEVICE_NOT_PARTITIONED = 0x00000453; // 1107

        /// <summary>
        ///     Unable to lock the media eject mechanism.
        /// </summary>
        public const int ERROR_UNABLE_TO_LOCK_MEDIA = 0x00000454; // 1108

        /// <summary>
        ///     Unable to unload the media.
        /// </summary>
        public const int ERROR_UNABLE_TO_UNLOAD_MEDIA = 0x00000455; // 1109

        /// <summary>
        ///     The media in the drive may have changed.
        /// </summary>
        public const int ERROR_MEDIA_CHANGED = 0x00000456; // 1110

        /// <summary>
        ///     The I/O bus was reset.
        /// </summary>
        public const int ERROR_BUS_RESET = 0x00000457; // 1111

        /// <summary>
        ///     No media in drive.
        /// </summary>
        public const int ERROR_NO_MEDIA_IN_DRIVE = 0x00000458; // 1112

        /// <summary>
        ///     No mapping for the Unicode character exists in the target multi-byte code page.
        /// </summary>
        public const int ERROR_NO_UNICODE_TRANSLATION = 0x00000459; // 1113

        /// <summary>
        ///     A dynamic link library (DLL) initialization routine failed.
        /// </summary>
        public const int ERROR_DLL_INIT_FAILED = 0x0000045A; // 1114

        /// <summary>
        ///     A system shutdown is in progress.
        /// </summary>
        public const int ERROR_SHUTDOWN_IN_PROGRESS = 0x0000045B; // 1115

        /// <summary>
        ///     Unable to abort the system shutdown because no shutdown was in progress.
        /// </summary>
        public const int ERROR_NO_SHUTDOWN_IN_PROGRESS = 0x0000045C; // 1116

        /// <summary>
        ///     The request could not be performed because of an I/O device error.
        /// </summary>
        public const int ERROR_IO_DEVICE = 0x0000045D; // 1117

        /// <summary>
        ///     No serial device was successfully initialized. The serial driver will unload.
        /// </summary>
        public const int ERROR_SERIAL_NO_DEVICE = 0x0000045E; // 1118

        /// <summary>
        ///     Unable to open a device that was sharing an interrupt request (IRQ) with other devices. At least one other device
        ///     that uses that IRQ was already opened.
        /// </summary>
        public const int ERROR_IRQ_BUSY = 0x0000045F; // 1119

        /// <summary>
        ///     A serial I/O operation was completed by another write to the serial port. The IOCTL_SERIAL_XOFF_COUNTER reached
        ///     zero.)
        /// </summary>
        public const int ERROR_MORE_WRITES = 0x00000460; // 1120

        /// <summary>
        ///     A serial I/O operation completed because the timeout period expired. The IOCTL_SERIAL_XOFF_COUNTER did not reach
        ///     zero.)
        /// </summary>
        public const int ERROR_COUNTER_TIMEOUT = 0x00000461; // 1121

        /// <summary>
        ///     No ID address mark was found on the floppy disk.
        /// </summary>
        public const int ERROR_FLOPPY_ID_MARK_NOT_FOUND = 0x00000462; // 1122

        /// <summary>
        ///     Mismatch between the floppy disk sector ID field and the floppy disk controller track address.
        /// </summary>
        public const int ERROR_FLOPPY_WRONG_CYLINDER = 0x00000463; // 1123

        /// <summary>
        ///     The floppy disk controller reported an error that is not recognized by the floppy disk driver.
        /// </summary>
        public const int ERROR_FLOPPY_UNKNOWN_ERROR = 0x00000464; // 1124

        /// <summary>
        ///     The floppy disk controller returned inconsistent results in its registers.
        /// </summary>
        public const int ERROR_FLOPPY_BAD_REGISTERS = 0x00000465; // 1125

        /// <summary>
        ///     While accessing the hard disk, a recalibrate operation failed, even after retries.
        /// </summary>
        public const int ERROR_DISK_RECALIBRATE_FAILED = 0x00000466; // 1126

        /// <summary>
        ///     While accessing the hard disk, a disk operation failed even after retries.
        /// </summary>
        public const int ERROR_DISK_OPERATION_FAILED = 0x00000467; // 1127

        /// <summary>
        ///     While accessing the hard disk, a disk controller reset was needed, but even that failed.
        /// </summary>
        public const int ERROR_DISK_RESET_FAILED = 0x00000468; // 1128

        /// <summary>
        ///     Physical end of tape encountered.
        /// </summary>
        public const int ERROR_EOM_OVERFLOW = 0x00000469; // 1129

        /// <summary>
        ///     Not enough server storage is available to process this command.
        /// </summary>
        public const int ERROR_NOT_ENOUGH_SERVER_MEMORY = 0x0000046A; // 1130

        /// <summary>
        ///     A potential deadlock condition has been detected.
        /// </summary>
        public const int ERROR_POSSIBLE_DEADLOCK = 0x0000046B; // 1131

        /// <summary>
        ///     The base address or the file offset specified does not have the proper alignment.
        /// </summary>
        public const int ERROR_MAPPED_ALIGNMENT = 0x0000046C; // 1132

        /// <summary>
        ///     An attempt to change the system power state was vetoed by another application or driver.
        /// </summary>
        public const int ERROR_SET_POWER_STATE_VETOED = 0x00000474; // 1140

        /// <summary>
        ///     The system BIOS failed an attempt to change the system power state.
        /// </summary>
        public const int ERROR_SET_POWER_STATE_FAILED = 0x00000475; // 1141

        /// <summary>
        ///     An attempt was made to create more links on a file than the file system supports.
        /// </summary>
        public const int ERROR_TOO_MANY_LINKS = 0x00000476; // 1142

        /// <summary>
        ///     The specified program requires a newer version of Windows.
        /// </summary>
        public const int ERROR_OLD_WIN_VERSION = 0x0000047E; // 1150

        /// <summary>
        ///     The specified program is not a Windows or MS-DOS program.
        /// </summary>
        public const int ERROR_APP_WRONG_OS = 0x0000047F; // 1151

        /// <summary>
        ///     Cannot start more than one instance of the specified program.
        /// </summary>
        public const int ERROR_SINGLE_INSTANCE_APP = 0x00000480; // 1152

        /// <summary>
        ///     The specified program was written for an earlier version of Windows.
        /// </summary>
        public const int ERROR_RMODE_APP = 0x00000481; // 1153

        /// <summary>
        ///     One of the library files needed to run this application is damaged.
        /// </summary>
        public const int ERROR_INVALID_DLL = 0x00000482; // 1154

        /// <summary>
        ///     No application is associated with the specified file for this operation.
        /// </summary>
        public const int ERROR_NO_ASSOCIATION = 0x00000483; // 1155

        /// <summary>
        ///     An error occurred in sending the command to the application.
        /// </summary>
        public const int ERROR_DDE_FAIL = 0x00000484; // 1156

        /// <summary>
        ///     One of the library files needed to run this application cannot be found.
        /// </summary>
        public const int ERROR_DLL_NOT_FOUND = 0x00000485; // 1157

        /// <summary>
        ///     The current process has used all of its system allowance of handles for Window Manager objects.
        /// </summary>
        public const int ERROR_NO_MORE_USER_HANDLES = 0x00000486; // 1158

        /// <summary>
        ///     The message can be used only with synchronous operations.
        /// </summary>
        public const int ERROR_MESSAGE_SYNC_ONLY = 0x00000487; // 1159

        /// <summary>
        ///     The indicated source element has no media.
        /// </summary>
        public const int ERROR_SOURCE_ELEMENT_EMPTY = 0x00000488; // 1160

        /// <summary>
        ///     The indicated destination element already contains media.
        /// </summary>
        public const int ERROR_DESTINATION_ELEMENT_FULL = 0x00000489; // 1161

        /// <summary>
        ///     The indicated element does not exist.
        /// </summary>
        public const int ERROR_ILLEGAL_ELEMENT_ADDRESS = 0x0000048A; // 1162

        /// <summary>
        ///     The indicated element is part of a magazine that is not present.
        /// </summary>
        public const int ERROR_MAGAZINE_NOT_PRESENT = 0x0000048B; // 1163

        /// <summary>
        ///     The indicated device requires reinitialization due to hardware errors.
        /// </summary>
        public const int ERROR_DEVICE_REINITIALIZATION_NEEDED = 0x0000048C; // 1164

        /// <summary>
        ///     The device has indicated that cleaning is required before further operations are attempted.
        /// </summary>
        public const int ERROR_DEVICE_REQUIRES_CLEANING = 0x0000048D; // 1165

        /// <summary>
        ///     The device has indicated that its door is open.
        /// </summary>
        public const int ERROR_DEVICE_DOOR_OPEN = 0x0000048E; // 1166

        /// <summary>
        ///     The device is not connected.
        /// </summary>
        public const int ERROR_DEVICE_NOT_CONNECTED = 0x0000048F; // 1167

        /// <summary>
        ///     Element not found.
        /// </summary>
        public const int ERROR_NOT_FOUND = 0x00000490; // 1168

        /// <summary>
        ///     There was no match for the specified key in the index.
        /// </summary>
        public const int ERROR_NO_MATCH = 0x00000491; // 1169

        /// <summary>
        ///     The property set specified does not exist on the object.
        /// </summary>
        public const int ERROR_SET_NOT_FOUND = 0x00000492; // 1170

        /// <summary>
        ///     The point passed to GetMouseMovePoints is not in the buffer.
        /// </summary>
        public const int ERROR_POINT_NOT_FOUND = 0x00000493; // 1171

        /// <summary>
        ///     The tracking (workstation) service is not running.
        /// </summary>
        public const int ERROR_NO_TRACKING_SERVICE = 0x00000494; // 1172

        /// <summary>
        ///     The Volume ID could not be found.
        /// </summary>
        public const int ERROR_NO_VOLUME_ID = 0x00000495; // 1173

        /// <summary>
        ///     Unable to remove the file to be replaced.
        /// </summary>
        public const int ERROR_UNABLE_TO_REMOVE_REPLACED = 0x00000497; // 1175

        /// <summary>
        ///     Unable to move the replacement file to the file to be replaced. The file to be replaced has retained its original
        ///     name.
        /// </summary>
        public const int ERROR_UNABLE_TO_MOVE_REPLACEMENT = 0x00000498; // 1176

        /// <summary>
        ///     Unable to move the replacement file to the file to be replaced. The file to be replaced has been renamed using the
        ///     backup name.
        /// </summary>
        public const int ERROR_UNABLE_TO_MOVE_REPLACEMENT_2 = 0x00000499; // 1177

        /// <summary>
        ///     The volume change journal is being deleted.
        /// </summary>
        public const int ERROR_JOURNAL_DELETE_IN_PROGRESS = 0x0000049A; // 1178

        /// <summary>
        ///     The volume change journal is not active.
        /// </summary>
        public const int ERROR_JOURNAL_NOT_ACTIVE = 0x0000049B; // 1179

        /// <summary>
        ///     A file was found, but it may not be the correct file.
        /// </summary>
        public const int ERROR_POTENTIAL_FILE_FOUND = 0x0000049C; // 1180

        /// <summary>
        ///     The journal entry has been deleted from the journal.
        /// </summary>
        public const int ERROR_JOURNAL_ENTRY_DELETED = 0x0000049D; // 1181

        /// <summary>
        ///     A system shutdown has already been scheduled.
        /// </summary>
        public const int ERROR_SHUTDOWN_IS_SCHEDULED = 0x000004A6; // 1190

        /// <summary>
        ///     The system shutdown cannot be initiated because there are other users logged on to the computer.
        /// </summary>
        public const int ERROR_SHUTDOWN_USERS_LOGGED_ON = 0x000004A7; // 1191

        /// <summary>
        ///     The specified device name is invalid.
        /// </summary>
        public const int ERROR_BAD_DEVICE = 0x000004B0; // 1200

        /// <summary>
        ///     The device is not currently connected but it is a remembered connection.
        /// </summary>
        public const int ERROR_CONNECTION_UNAVAIL = 0x000004B1; // 1201

        /// <summary>
        ///     The local device name has a remembered connection to another network resource.
        /// </summary>
        public const int ERROR_DEVICE_ALREADY_REMEMBERED = 0x000004B2; // 1202

        /// <summary>
        ///     The network path was either typed incorrectly, does not exist, or the network provider is not currently available.
        ///     Please try retyping the path or contact your network administrator.
        /// </summary>
        public const int ERROR_NO_NET_OR_BAD_PATH = 0x000004B3; // 1203

        /// <summary>
        ///     The specified network provider name is invalid.
        /// </summary>
        public const int ERROR_BAD_PROVIDER = 0x000004B4; // 1204

        /// <summary>
        ///     Unable to open the network connection profile.
        /// </summary>
        public const int ERROR_CANNOT_OPEN_PROFILE = 0x000004B5; // 1205

        /// <summary>
        ///     The network connection profile is corrupted.
        /// </summary>
        public const int ERROR_BAD_PROFILE = 0x000004B6; // 1206

        /// <summary>
        ///     Cannot enumerate a non-container.
        /// </summary>
        public const int ERROR_NOT_CONTAINER = 0x000004B7; // 1207

        /// <summary>
        ///     An extended error has occurred.
        /// </summary>
        public const int ERROR_EXTENDED_ERROR = 0x000004B8; // 1208

        /// <summary>
        ///     The format of the specified group name is invalid.
        /// </summary>
        public const int ERROR_INVALID_GROUPNAME = 0x000004B9; // 1209

        /// <summary>
        ///     The format of the specified computer name is invalid.
        /// </summary>
        public const int ERROR_INVALID_COMPUTERNAME = 0x000004BA; // 1210

        /// <summary>
        ///     The format of the specified event name is invalid.
        /// </summary>
        public const int ERROR_INVALID_EVENTNAME = 0x000004BB; // 1211

        /// <summary>
        ///     The format of the specified domain name is invalid.
        /// </summary>
        public const int ERROR_INVALID_DOMAINNAME = 0x000004BC; // 1212

        /// <summary>
        ///     The format of the specified service name is invalid.
        /// </summary>
        public const int ERROR_INVALID_SERVICENAME = 0x000004BD; // 1213

        /// <summary>
        ///     The format of the specified network name is invalid.
        /// </summary>
        public const int ERROR_INVALID_NETNAME = 0x000004BE; // 1214

        /// <summary>
        ///     The format of the specified share name is invalid.
        /// </summary>
        public const int ERROR_INVALID_SHARENAME = 0x000004BF; // 1215

        /// <summary>
        ///     The format of the specified password is invalid.
        /// </summary>
        public const int ERROR_INVALID_PASSWORDNAME = 0x000004C0; // 1216

        /// <summary>
        ///     The format of the specified message name is invalid.
        /// </summary>
        public const int ERROR_INVALID_MESSAGENAME = 0x000004C1; // 1217

        /// <summary>
        ///     The format of the specified message destination is invalid.
        /// </summary>
        public const int ERROR_INVALID_MESSAGEDEST = 0x000004C2; // 1218

        /// <summary>
        ///     Multiple connections to a server or shared resource by the same user, using more than one user name, are not
        ///     allowed. Disconnect all previous connections to the server or shared resource and try again.
        /// </summary>
        public const int ERROR_SESSION_CREDENTIAL_CONFLICT = 0x000004C3; // 1219

        /// <summary>
        ///     An attempt was made to establish a session to a network server, but there are already too many sessions established
        ///     to that server.
        /// </summary>
        public const int ERROR_REMOTE_SESSION_LIMIT_EXCEEDED = 0x000004C4; // 1220

        /// <summary>
        ///     The workgroup or domain name is already in use by another computer on the network.
        /// </summary>
        public const int ERROR_DUP_DOMAINNAME = 0x000004C5; // 1221

        /// <summary>
        ///     The network is not present or not started.
        /// </summary>
        public const int ERROR_NO_NETWORK = 0x000004C6; // 1222

        /// <summary>
        ///     The operation was canceled by the user.
        /// </summary>
        public const int ERROR_CANCELLED = 0x000004C7; // 1223

        /// <summary>
        ///     The requested operation cannot be performed on a file with a user-mapped section open.
        /// </summary>
        public const int ERROR_USER_MAPPED_FILE = 0x000004C8; // 1224

        /// <summary>
        ///     The remote computer refused the network connection.
        /// </summary>
        public const int ERROR_CONNECTION_REFUSED = 0x000004C9; // 1225

        /// <summary>
        ///     The network connection was gracefully closed.
        /// </summary>
        public const int ERROR_GRACEFUL_DISCONNECT = 0x000004CA; // 1226

        /// <summary>
        ///     The network transport endpoint already has an address associated with it.
        /// </summary>
        public const int ERROR_ADDRESS_ALREADY_ASSOCIATED = 0x000004CB; // 1227

        /// <summary>
        ///     An address has not yet been associated with the network endpoint.
        /// </summary>
        public const int ERROR_ADDRESS_NOT_ASSOCIATED = 0x000004CC; // 1228

        /// <summary>
        ///     An operation was attempted on a nonexistent network connection.
        /// </summary>
        public const int ERROR_CONNECTION_INVALID = 0x000004CD; // 1229

        /// <summary>
        ///     An invalid operation was attempted on an active network connection.
        /// </summary>
        public const int ERROR_CONNECTION_ACTIVE = 0x000004CE; // 1230

        /// <summary>
        ///     The network location cannot be reached. For information about network troubleshooting, see Windows Help.
        /// </summary>
        public const int ERROR_NETWORK_UNREACHABLE = 0x000004CF; // 1231

        /// <summary>
        ///     The network location cannot be reached. For information about network troubleshooting, see Windows Help.
        /// </summary>
        public const int ERROR_HOST_UNREACHABLE = 0x000004D0; // 1232

        /// <summary>
        ///     The network location cannot be reached. For information about network troubleshooting, see Windows Help.
        /// </summary>
        public const int ERROR_PROTOCOL_UNREACHABLE = 0x000004D1; // 1233

        /// <summary>
        ///     No service is operating at the destination network endpoint on the remote system.
        /// </summary>
        public const int ERROR_PORT_UNREACHABLE = 0x000004D2; // 1234

        /// <summary>
        ///     The request was aborted.
        /// </summary>
        public const int ERROR_REQUEST_ABORTED = 0x000004D3; // 1235

        /// <summary>
        ///     The network connection was aborted by the local system.
        /// </summary>
        public const int ERROR_CONNECTION_ABORTED = 0x000004D4; // 1236

        /// <summary>
        ///     The operation could not be completed. A retry should be performed.
        /// </summary>
        public const int ERROR_RETRY = 0x000004D5; // 1237

        /// <summary>
        ///     A connection to the server could not be made because the limit on the number of concurrent connections for this
        ///     account has been reached.
        /// </summary>
        public const int ERROR_CONNECTION_COUNT_LIMIT = 0x000004D6; // 1238

        /// <summary>
        ///     Attempting to log in during an unauthorized time of day for this account.
        /// </summary>
        public const int ERROR_LOGIN_TIME_RESTRICTION = 0x000004D7; // 1239

        /// <summary>
        ///     The account is not authorized to log in from this station.
        /// </summary>
        public const int ERROR_LOGIN_WKSTA_RESTRICTION = 0x000004D8; // 1240

        /// <summary>
        ///     The network address could not be used for the operation requested.
        /// </summary>
        public const int ERROR_INCORRECT_ADDRESS = 0x000004D9; // 1241

        /// <summary>
        ///     The service is already registered.
        /// </summary>
        public const int ERROR_ALREADY_REGISTERED = 0x000004DA; // 1242

        /// <summary>
        ///     The specified service does not exist.
        /// </summary>
        public const int ERROR_SERVICE_NOT_FOUND = 0x000004DB; // 1243

        /// <summary>
        ///     The operation being requested was not performed because the user has not been authenticated.
        /// </summary>
        public const int ERROR_NOT_AUTHENTICATED = 0x000004DC; // 1244

        /// <summary>
        ///     The operation being requested was not performed because the user has not logged on to the network. The specified
        ///     service does not exist.
        /// </summary>
        public const int ERROR_NOT_LOGGED_ON = 0x000004DD; // 1245

        /// <summary>
        ///     Continue with work in progress.
        /// </summary>
        public const int ERROR_CONTINUE = 0x000004DE; // 1246

        /// <summary>
        ///     An attempt was made to perform an initialization operation when initialization has already been completed.
        /// </summary>
        public const int ERROR_ALREADY_INITIALIZED = 0x000004DF; // 1247

        /// <summary>
        ///     No more local devices.
        /// </summary>
        public const int ERROR_NO_MORE_DEVICES = 0x000004E0; // 1248

        /// <summary>
        ///     The specified site does not exist.
        /// </summary>
        public const int ERROR_NO_SUCH_SITE = 0x000004E1; // 1249

        /// <summary>
        ///     A domain controller with the specified name already exists.
        /// </summary>
        public const int ERROR_DOMAIN_CONTROLLER_EXISTS = 0x000004E2; // 1250

        /// <summary>
        ///     This operation is supported only when you are connected to the server.
        /// </summary>
        public const int ERROR_ONLY_IF_CONNECTED = 0x000004E3; // 1251

        /// <summary>
        ///     The group policy framework should call the extension even if there are no changes.
        /// </summary>
        public const int ERROR_OVERRIDE_NOCHANGES = 0x000004E4; // 1252

        /// <summary>
        ///     The specified user does not have a valid profile.
        /// </summary>
        public const int ERROR_BAD_USER_PROFILE = 0x000004E5; // 1253

        /// <summary>
        ///     This operation is not supported on a computer running Windows Server 2003 for Small Business Server.
        /// </summary>
        public const int ERROR_NOT_SUPPORTED_ON_SBS = 0x000004E6; // 1254

        /// <summary>
        ///     The server machine is shutting down.
        /// </summary>
        public const int ERROR_SERVER_SHUTDOWN_IN_PROGRESS = 0x000004E7; // 1255

        /// <summary>
        ///     The remote system is not available. For information about network troubleshooting, see Windows Help.
        /// </summary>
        public const int ERROR_HOST_DOWN = 0x000004E8; // 1256

        /// <summary>
        ///     The security identifier provided is not from an account domain.
        /// </summary>
        public const int ERROR_NON_ACCOUNT_SID = 0x000004E9; // 1257

        /// <summary>
        ///     The security identifier provided does not have a domain component.
        /// </summary>
        public const int ERROR_NON_DOMAIN_SID = 0x000004EA; // 1258

        /// <summary>
        ///     AppHelp dialog canceled thus preventing the application from starting.
        /// </summary>
        public const int ERROR_APPHELP_BLOCK = 0x000004EB; // 1259

        /// <summary>
        ///     This program is blocked by group policy. For more information, contact your system administrator.
        /// </summary>
        public const int ERROR_ACCESS_DISABLED_BY_POLICY = 0x000004EC; // 1260

        /// <summary>
        ///     A program attempt to use an invalid register value. Normally caused by an uninitialized register. This error is
        ///     Itanium specific.
        /// </summary>
        public const int ERROR_REG_NAT_CONSUMPTION = 0x000004ED; // 1261

        /// <summary>
        ///     The share is currently offline or does not exist.
        /// </summary>
        public const int ERROR_CSCSHARE_OFFLINE = 0x000004EE; // 1262

        /// <summary>
        ///     The Kerberos protocol encountered an error while validating the KDC certificate during smart card logon. There is
        ///     more information in the system event log.
        /// </summary>
        public const int ERROR_PKINIT_FAILURE = 0x000004EF; // 1263

        /// <summary>
        ///     The Kerberos protocol encountered an error while attempting to utilize the smart card subsystem.
        /// </summary>
        public const int ERROR_SMARTCARD_SUBSYSTEM_FAILURE = 0x000004F0; // 1264

        /// <summary>
        ///     The system cannot contact a domain controller to service the authentication request. Please try again later.
        /// </summary>
        public const int ERROR_DOWNGRADE_DETECTED = 0x000004F1; // 1265

        /// <summary>
        ///     The machine is locked and cannot be shut down without the force option.
        /// </summary>
        public const int ERROR_MACHINE_LOCKED = 0x000004F7; // 1271

        /// <summary>
        ///     An application-defined callback gave invalid data when called.
        /// </summary>
        public const int ERROR_CALLBACK_SUPPLIED_INVALID_DATA = 0x000004F9; // 1273

        /// <summary>
        ///     The group policy framework should call the extension in the synchronous foreground policy refresh.
        /// </summary>
        public const int ERROR_SYNC_FOREGROUND_REFRESH_REQUIRED = 0x000004FA; // 1274

        /// <summary>
        ///     This driver has been blocked from loading.
        /// </summary>
        public const int ERROR_DRIVER_BLOCKED = 0x000004FB; // 1275

        /// <summary>
        ///     A dynamic link library (DLL) referenced a module that was neither a DLL nor the process's executable image.
        /// </summary>
        public const int ERROR_INVALID_IMPORT_OF_NON_DLL = 0x000004FC; // 1276

        /// <summary>
        ///     Windows cannot open this program since it has been disabled.
        /// </summary>
        public const int ERROR_ACCESS_DISABLED_WEBBLADE = 0x000004FD; // 1277

        /// <summary>
        ///     Windows cannot open this program because the license enforcement system has been tampered with or become corrupted.
        /// </summary>
        public const int ERROR_ACCESS_DISABLED_WEBBLADE_TAMPER = 0x000004FE; // 1278

        /// <summary>
        ///     A transaction recover failed.
        /// </summary>
        public const int ERROR_RECOVERY_FAILURE = 0x000004FF; // 1279

        /// <summary>
        ///     The current thread has already been converted to a fiber.
        /// </summary>
        public const int ERROR_ALREADY_FIBER = 0x00000500; // 1280

        /// <summary>
        ///     The current thread has already been converted from a fiber.
        /// </summary>
        public const int ERROR_ALREADY_THREAD = 0x00000501; // 1281

        /// <summary>
        ///     The system detected an overrun of a stack-based buffer in this application. This overrun could potentially allow a
        ///     malicious user to gain control of this application.
        /// </summary>
        public const int ERROR_STACK_BUFFER_OVERRUN = 0x00000502; // 1282

        /// <summary>
        ///     Data present in one of the parameters is more than the function can operate on.
        /// </summary>
        public const int ERROR_PARAMETER_QUOTA_EXCEEDED = 0x00000503; // 1283

        /// <summary>
        ///     An attempt to do an operation on a debug object failed because the object is in the process of being deleted.
        /// </summary>
        public const int ERROR_DEBUGGER_INACTIVE = 0x00000504; // 1284

        /// <summary>
        ///     An attempt to delay-load a .dll or get a function address in a delay-loaded .dll failed.
        /// </summary>
        public const int ERROR_DELAY_LOAD_FAILED = 0x00000505; // 1285

        /// <summary>
        ///     %1 is a 16-bit application. You do not have permissions to execute 16-bit applications. Check your permissions with
        ///     your system administrator.
        /// </summary>
        public const int ERROR_VDM_DISALLOWED = 0x00000506; // 1286

        /// <summary>
        ///     Insufficient information exists to identify the cause of failure.
        /// </summary>
        public const int ERROR_UNIDENTIFIED_ERROR = 0x00000507; // 1287

        /// <summary>
        ///     The parameter passed to a C runtime function is incorrect.
        /// </summary>
        public const int ERROR_INVALID_CRUNTIME_PARAMETER = 0x00000508; // 1288

        /// <summary>
        ///     The operation occurred beyond the valid data length of the file.
        /// </summary>
        public const int ERROR_BEYOND_VDL = 0x00000509; // 1289

        /// <summary>
        ///     The service start failed since one or more services in the same process have an incompatible service SID type
        ///     setting. A service with restricted service SID type can only coexist in the same process with other services with a
        ///     restricted SID type. If the service SID type for this service was just configured, the hosting process must be
        ///     restarted in order to start this service.
        /// </summary>
        public const int ERROR_INCOMPATIBLE_SERVICE_SID_TYPE = 0x0000050A; // 1290

        /// <summary>
        ///     The process hosting the driver for this device has been terminated.
        /// </summary>
        public const int ERROR_DRIVER_PROCESS_TERMINATED = 0x0000050B; // 1291

        /// <summary>
        ///     An operation attempted to exceed an implementation-defined limit.
        /// </summary>
        public const int ERROR_IMPLEMENTATION_LIMIT = 0x0000050C; // 1292

        /// <summary>
        ///     Either the target process, or the target thread's containing process, is a protected process.
        /// </summary>
        public const int ERROR_PROCESS_IS_PROTECTED = 0x0000050D; // 1293

        /// <summary>
        ///     The service notification client is lagging too far behind the current state of services in the machine.
        /// </summary>
        public const int ERROR_SERVICE_NOTIFY_CLIENT_LAGGING = 0x0000050E; // 1294

        /// <summary>
        ///     The requested file operation failed because the storage quota was exceeded. To free up disk space, move files to a
        ///     different location or delete unnecessary files. For more information, contact your system administrator.
        /// </summary>
        public const int ERROR_DISK_QUOTA_EXCEEDED = 0x0000050F; // 1295

        /// <summary>
        ///     The requested file operation failed because the storage policy blocks that type of file. For more information,
        ///     contact your system administrator.
        /// </summary>
        public const int ERROR_CONTENT_BLOCKED = 0x00000510; // 1296

        /// <summary>
        ///     A privilege that the service requires to function properly does not exist in the service account configuration. You
        ///     may use the Services Microsoft Management Console (MMC) snap-in (services.msc) and the Local Security Settings MMC
        ///     snap-in (secpol.msc) to view the service configuration and the account configuration.
        /// </summary>
        public const int ERROR_INCOMPATIBLE_SERVICE_PRIVILEGE = 0x00000511; // 1297

        /// <summary>
        ///     A thread involved in this operation appears to be unresponsive.
        /// </summary>
        public const int ERROR_APP_HANG = 0x00000512; // 1298

        /// <summary>
        ///     Indicates a particular Security ID may not be assigned as the label of an object.
        /// </summary>
        public const int ERROR_INVALID_LABEL = 0x00000513; // 1299

        #endregion

        #region 1300 - 1699

        /// <summary>
        ///     Not all privileges or groups referenced are assigned to the caller.
        /// </summary>
        public const int ERROR_NOT_ALL_ASSIGNED = 0x00000514; // 1300

        /// <summary>
        ///     Some mapping between account names and security IDs was not done.
        /// </summary>
        public const int ERROR_SOME_NOT_MAPPED = 0x00000515; // 1301

        /// <summary>
        ///     No system quota limits are specifically set for this account.
        /// </summary>
        public const int ERROR_NO_QUOTAS_FOR_ACCOUNT = 0x00000516; // 1302

        /// <summary>
        ///     No encryption key is available. A well-known encryption key was returned.
        /// </summary>
        public const int ERROR_LOCAL_USER_SESSION_KEY = 0x00000517; // 1303

        /// <summary>
        ///     The password is too complex to be converted to a LAN Manager password. The LAN Manager password returned is a NULL
        ///     string.
        /// </summary>
        public const int ERROR_NULL_LM_PASSWORD = 0x00000518; // 1304

        /// <summary>
        ///     The revision level is unknown.
        /// </summary>
        public const int ERROR_UNKNOWN_REVISION = 0x00000519; // 1305

        /// <summary>
        ///     Indicates two revision levels are incompatible.
        /// </summary>
        public const int ERROR_REVISION_MISMATCH = 0x0000051A; // 1306

        /// <summary>
        ///     This security ID may not be assigned as the owner of this object.
        /// </summary>
        public const int ERROR_INVALID_OWNER = 0x0000051B; // 1307

        /// <summary>
        ///     This security ID may not be assigned as the primary group of an object.
        /// </summary>
        public const int ERROR_INVALID_PRIMARY_GROUP = 0x0000051C; // 1308

        /// <summary>
        ///     An attempt has been made to operate on an impersonation token by a thread that is not currently impersonating a
        ///     client.
        /// </summary>
        public const int ERROR_NO_IMPERSONATION_TOKEN = 0x0000051D; // 1309

        /// <summary>
        ///     The group may not be disabled.
        /// </summary>
        public const int ERROR_CANT_DISABLE_MANDATORY = 0x0000051E; // 1310

        /// <summary>
        ///     There are currently no logon servers available to service the logon request.
        /// </summary>
        public const int ERROR_NO_LOGON_SERVERS = 0x0000051F; // 1311

        /// <summary>
        ///     A specified logon session does not exist. It may already have been terminated.
        /// </summary>
        public const int ERROR_NO_SUCH_LOGON_SESSION = 0x00000520; // 1312

        /// <summary>
        ///     A specified privilege does not exist.
        /// </summary>
        public const int ERROR_NO_SUCH_PRIVILEGE = 0x00000521; // 1313

        /// <summary>
        ///     A required privilege is not held by the client.
        /// </summary>
        public const int ERROR_PRIVILEGE_NOT_HELD = 0x00000522; // 1314

        /// <summary>
        ///     The name provided is not a properly formed account name.
        /// </summary>
        public const int ERROR_INVALID_ACCOUNT_NAME = 0x00000523; // 1315

        /// <summary>
        ///     The specified account already exists.
        /// </summary>
        public const int ERROR_USER_EXISTS = 0x00000524; // 1316

        /// <summary>
        ///     The specified account does not exist.
        /// </summary>
        public const int ERROR_NO_SUCH_USER = 0x00000525; // 1317

        /// <summary>
        ///     The specified group already exists.
        /// </summary>
        public const int ERROR_GROUP_EXISTS = 0x00000526; // 1318

        /// <summary>
        ///     The specified group does not exist.
        /// </summary>
        public const int ERROR_NO_SUCH_GROUP = 0x00000527; // 1319

        /// <summary>
        ///     Either the specified user account is already a member of the specified group, or the specified group cannot be
        ///     deleted because it contains a member.
        /// </summary>
        public const int ERROR_MEMBER_IN_GROUP = 0x00000528; // 1320

        /// <summary>
        ///     The specified user account is not a member of the specified group account.
        /// </summary>
        public const int ERROR_MEMBER_NOT_IN_GROUP = 0x00000529; // 1321

        /// <summary>
        ///     This operation is disallowed as it could result in an administration account being disabled, deleted or unable to
        ///     log on.
        /// </summary>
        public const int ERROR_LAST_ADMIN = 0x0000052A; // 1322

        /// <summary>
        ///     Unable to update the password. The value provided as the current password is incorrect.
        /// </summary>
        public const int ERROR_WRONG_PASSWORD = 0x0000052B; // 1323

        /// <summary>
        ///     Unable to update the password. The value provided for the new password contains values that are not allowed in
        ///     passwords.
        /// </summary>
        public const int ERROR_ILL_FORMED_PASSWORD = 0x0000052C; // 1324

        /// <summary>
        ///     Unable to update the password. The value provided for the new password does not meet the length, complexity, or
        ///     history requirements of the domain.
        /// </summary>
        public const int ERROR_PASSWORD_RESTRICTION = 0x0000052D; // 1325

        /// <summary>
        ///     The user name or password is incorrect.
        /// </summary>
        public const int ERROR_LOGON_FAILURE = 0x0000052E; // 1326

        /// <summary>
        ///     Account restrictions are preventing this user from signing in. For example: blank passwords aren't allowed, sign-in
        ///     times are limited, or a policy restriction has been enforced.
        /// </summary>
        public const int ERROR_ACCOUNT_RESTRICTION = 0x0000052F; // 1327

        /// <summary>
        ///     Your account has time restrictions that keep you from signing in right now.
        /// </summary>
        public const int ERROR_INVALID_LOGON_HOURS = 0x00000530; // 1328

        /// <summary>
        ///     This user isn't allowed to sign in to this computer.
        /// </summary>
        public const int ERROR_INVALID_WORKSTATION = 0x00000531; // 1329

        /// <summary>
        ///     The password for this account has expired.
        /// </summary>
        public const int ERROR_PASSWORD_EXPIRED = 0x00000532; // 1330

        /// <summary>
        ///     This user can't sign in because this account is currently disabled.
        /// </summary>
        public const int ERROR_ACCOUNT_DISABLED = 0x00000533; // 1331

        /// <summary>
        ///     No mapping between account names and security IDs was done.
        /// </summary>
        public const int ERROR_NONE_MAPPED = 0x00000534; // 1332

        /// <summary>
        ///     Too many local user identifiers (LUIDs) were requested at one time.
        /// </summary>
        public const int ERROR_TOO_MANY_LUIDS_REQUESTED = 0x00000535; // 1333

        /// <summary>
        ///     No more local user identifiers (LUIDs) are available.
        /// </summary>
        public const int ERROR_LUIDS_EXHAUSTED = 0x00000536; // 1334

        /// <summary>
        ///     The sub authority part of a security ID is invalid for this particular use.
        /// </summary>
        public const int ERROR_INVALID_SUB_AUTHORITY = 0x00000537; // 1335

        /// <summary>
        ///     The access control list (ACL) structure is invalid.
        /// </summary>
        public const int ERROR_INVALID_ACL = 0x00000538; // 1336

        /// <summary>
        ///     The security ID structure is invalid.
        /// </summary>
        public const int ERROR_INVALID_SID = 0x00000539; // 1337

        /// <summary>
        ///     The security descriptor structure is invalid.
        /// </summary>
        public const int ERROR_INVALID_SECURITY_DESCR = 0x0000053A; // 1338

        /// <summary>
        ///     The inherited access control list (ACL) or access control entry (ACE) could not be built.
        /// </summary>
        public const int ERROR_BAD_INHERITANCE_ACL = 0x0000053C; // 1340

        /// <summary>
        ///     The server is currently disabled.
        /// </summary>
        public const int ERROR_SERVER_DISABLED = 0x0000053D; // 1341

        /// <summary>
        ///     The server is currently enabled.
        /// </summary>
        public const int ERROR_SERVER_NOT_DISABLED = 0x0000053E; // 1342

        /// <summary>
        ///     The value provided was an invalid value for an identifier authority.
        /// </summary>
        public const int ERROR_INVALID_ID_AUTHORITY = 0x0000053F; // 1343

        /// <summary>
        ///     No more memory is available for security information updates.
        /// </summary>
        public const int ERROR_ALLOTTED_SPACE_EXCEEDED = 0x00000540; // 1344

        /// <summary>
        ///     The specified attributes are invalid, or incompatible with the attributes for the group as a whole.
        /// </summary>
        public const int ERROR_INVALID_GROUP_ATTRIBUTES = 0x00000541; // 1345

        /// <summary>
        ///     Either a required impersonation level was not provided, or the provided impersonation level is invalid.
        /// </summary>
        public const int ERROR_BAD_IMPERSONATION_LEVEL = 0x00000542; // 1346

        /// <summary>
        ///     Cannot open an anonymous level security token.
        /// </summary>
        public const int ERROR_CANT_OPEN_ANONYMOUS = 0x00000543; // 1347

        /// <summary>
        ///     The validation information class requested was invalid.
        /// </summary>
        public const int ERROR_BAD_VALIDATION_CLASS = 0x00000544; // 1348

        /// <summary>
        ///     The type of the token is inappropriate for its attempted use.
        /// </summary>
        public const int ERROR_BAD_TOKEN_TYPE = 0x00000545; // 1349

        /// <summary>
        ///     Unable to perform a security operation on an object that has no associated security.
        /// </summary>
        public const int ERROR_NO_SECURITY_ON_OBJECT = 0x00000546; // 1350

        /// <summary>
        ///     Configuration information could not be read from the domain controller, either because the machine is unavailable,
        ///     or access has been denied.
        /// </summary>
        public const int ERROR_CANT_ACCESS_DOMAIN_INFO = 0x00000547; // 1351

        /// <summary>
        ///     The security account manager (SAM) or local security authority (LSA) server was in the wrong state to perform the
        ///     security operation.
        /// </summary>
        public const int ERROR_INVALID_SERVER_STATE = 0x00000548; // 1352

        /// <summary>
        ///     The domain was in the wrong state to perform the security operation.
        /// </summary>
        public const int ERROR_INVALID_DOMAIN_STATE = 0x00000549; // 1353

        /// <summary>
        ///     This operation is only allowed for the Primary Domain Controller of the domain.
        /// </summary>
        public const int ERROR_INVALID_DOMAIN_ROLE = 0x0000054A; // 1354

        /// <summary>
        ///     The specified domain either does not exist or could not be contacted.
        /// </summary>
        public const int ERROR_NO_SUCH_DOMAIN = 0x0000054B; // 1355

        /// <summary>
        ///     The specified domain already exists.
        /// </summary>
        public const int ERROR_DOMAIN_EXISTS = 0x0000054C; // 1356

        /// <summary>
        ///     An attempt was made to exceed the limit on the number of domains per server.
        /// </summary>
        public const int ERROR_DOMAIN_LIMIT_EXCEEDED = 0x0000054D; // 1357

        /// <summary>
        ///     Unable to complete the requested operation because of either a catastrophic media failure or a data structure
        ///     corruption on the disk.
        /// </summary>
        public const int ERROR_INTERNAL_DB_CORRUPTION = 0x0000054E; // 1358

        /// <summary>
        ///     An internal error occurred.
        /// </summary>
        public const int ERROR_INTERNAL_ERROR = 0x0000054F; // 1359

        /// <summary>
        ///     Generic access types were contained in an access mask which should already be mapped to non-generic types.
        /// </summary>
        public const int ERROR_GENERIC_NOT_MAPPED = 0x00000550; // 1360

        /// <summary>
        ///     A security descriptor is not in the right format (absolute or self-relative).
        /// </summary>
        public const int ERROR_BAD_DESCRIPTOR_FORMAT = 0x00000551; // 1361

        /// <summary>
        ///     The requested action is restricted for use by logon processes only. The calling process has not registered as a
        ///     logon process.
        /// </summary>
        public const int ERROR_NOT_LOGON_PROCESS = 0x00000552; // 1362

        /// <summary>
        ///     Cannot start a new logon session with an ID that is already in use.
        /// </summary>
        public const int ERROR_LOGON_SESSION_EXISTS = 0x00000553; // 1363

        /// <summary>
        ///     A specified authentication package is unknown.
        /// </summary>
        public const int ERROR_NO_SUCH_PACKAGE = 0x00000554; // 1364

        /// <summary>
        ///     The logon session is not in a state that is consistent with the requested operation.
        /// </summary>
        public const int ERROR_BAD_LOGON_SESSION_STATE = 0x00000555; // 1365

        /// <summary>
        ///     The logon session ID is already in use.
        /// </summary>
        public const int ERROR_LOGON_SESSION_COLLISION = 0x00000556; // 1366

        /// <summary>
        ///     A logon request contained an invalid logon type value.
        /// </summary>
        public const int ERROR_INVALID_LOGON_TYPE = 0x00000557; // 1367

        /// <summary>
        ///     Unable to impersonate using a named pipe until data has been read from that pipe.
        /// </summary>
        public const int ERROR_CANNOT_IMPERSONATE = 0x00000558; // 1368

        /// <summary>
        ///     The transaction state of a registry subtree is incompatible with the requested operation.
        /// </summary>
        public const int ERROR_RXACT_INVALID_STATE = 0x00000559; // 1369

        /// <summary>
        ///     An internal security database corruption has been encountered.
        /// </summary>
        public const int ERROR_RXACT_COMMIT_FAILURE = 0x0000055A; // 1370

        /// <summary>
        ///     Cannot perform this operation on built-in accounts.
        /// </summary>
        public const int ERROR_SPECIAL_ACCOUNT = 0x0000055B; // 1371

        /// <summary>
        ///     Cannot perform this operation on this built-in special group.
        /// </summary>
        public const int ERROR_SPECIAL_GROUP = 0x0000055C; // 1372

        /// <summary>
        ///     Cannot perform this operation on this built-in special user.
        /// </summary>
        public const int ERROR_SPECIAL_USER = 0x0000055D; // 1373

        /// <summary>
        ///     The user cannot be removed from a group because the group is currently the user's primary group.
        /// </summary>
        public const int ERROR_MEMBERS_PRIMARY_GROUP = 0x0000055E; // 1374

        /// <summary>
        ///     The token is already in use as a primary token.
        /// </summary>
        public const int ERROR_TOKEN_ALREADY_IN_USE = 0x0000055F; // 1375

        /// <summary>
        ///     The specified local group does not exist.
        /// </summary>
        public const int ERROR_NO_SUCH_ALIAS = 0x00000560; // 1376

        /// <summary>
        ///     The specified account name is not a member of the group.
        /// </summary>
        public const int ERROR_MEMBER_NOT_IN_ALIAS = 0x00000561; // 1377

        /// <summary>
        ///     The specified account name is already a member of the group.
        /// </summary>
        public const int ERROR_MEMBER_IN_ALIAS = 0x00000562; // 1378

        /// <summary>
        ///     The specified local group already exists.
        /// </summary>
        public const int ERROR_ALIAS_EXISTS = 0x00000563; // 1379

        /// <summary>
        ///     Logon failure: the user has not been granted the requested logon type at this computer.
        /// </summary>
        public const int ERROR_LOGON_NOT_GRANTED = 0x00000564; // 1380

        /// <summary>
        ///     The maximum number of secrets that may be stored in a single system has been exceeded.
        /// </summary>
        public const int ERROR_TOO_MANY_SECRETS = 0x00000565; // 1381

        /// <summary>
        ///     The length of a secret exceeds the maximum length allowed.
        /// </summary>
        public const int ERROR_SECRET_TOO_LONG = 0x00000566; // 1382

        /// <summary>
        ///     The local security authority database contains an internal inconsistency.
        /// </summary>
        public const int ERROR_INTERNAL_DB_ERROR = 0x00000567; // 1383

        /// <summary>
        ///     During a logon attempt, the user's security context accumulated too many security IDs.
        /// </summary>
        public const int ERROR_TOO_MANY_CONTEXT_IDS = 0x00000568; // 1384

        /// <summary>
        ///     Logon failure: the user has not been granted the requested logon type at this computer.
        /// </summary>
        public const int ERROR_LOGON_TYPE_NOT_GRANTED = 0x00000569; // 1385

        /// <summary>
        ///     A cross-encrypted password is necessary to change a user password.
        /// </summary>
        public const int ERROR_NT_CROSS_ENCRYPTION_REQUIRED = 0x0000056A; // 1386

        /// <summary>
        ///     A member could not be added to or removed from the local group because the member does not exist.
        /// </summary>
        public const int ERROR_NO_SUCH_MEMBER = 0x0000056B; // 1387

        /// <summary>
        ///     A new member could not be added to a local group because the member has the wrong account type.
        /// </summary>
        public const int ERROR_INVALID_MEMBER = 0x0000056C; // 1388

        /// <summary>
        ///     Too many security IDs have been specified.
        /// </summary>
        public const int ERROR_TOO_MANY_SIDS = 0x0000056D; // 1389

        /// <summary>
        ///     A cross-encrypted password is necessary to change this user password.
        /// </summary>
        public const int ERROR_LM_CROSS_ENCRYPTION_REQUIRED = 0x0000056E; // 1390

        /// <summary>
        ///     Indicates an ACL contains no inheritable components.
        /// </summary>
        public const int ERROR_NO_INHERITANCE = 0x0000056F; // 1391

        /// <summary>
        ///     The file or directory is corrupted and unreadable.
        /// </summary>
        public const int ERROR_FILE_CORRUPT = 0x00000570; // 1392

        /// <summary>
        ///     The disk structure is corrupted and unreadable.
        /// </summary>
        public const int ERROR_DISK_CORRUPT = 0x00000571; // 1393

        /// <summary>
        ///     There is no user session key for the specified logon session.
        /// </summary>
        public const int ERROR_NO_USER_SESSION_KEY = 0x00000572; // 1394

        /// <summary>
        ///     The service being accessed is licensed for a particular number of connections. No more connections can be made to
        ///     the service at this time because there are already as many connections as the service can accept.
        /// </summary>
        public const int ERROR_LICENSE_QUOTA_EXCEEDED = 0x00000573; // 1395

        /// <summary>
        ///     The target account name is incorrect.
        /// </summary>
        public const int ERROR_WRONG_TARGET_NAME = 0x00000574; // 1396

        /// <summary>
        ///     Mutual Authentication failed. The server's password is out of date at the domain controller.
        /// </summary>
        public const int ERROR_MUTUAL_AUTH_FAILED = 0x00000575; // 1397

        /// <summary>
        ///     There is a time and/or date difference between the client and server.
        /// </summary>
        public const int ERROR_TIME_SKEW = 0x00000576; // 1398

        /// <summary>
        ///     This operation cannot be performed on the current domain.
        /// </summary>
        public const int ERROR_CURRENT_DOMAIN_NOT_ALLOWED = 0x00000577; // 1399

        /// <summary>
        ///     Invalid window handle.
        /// </summary>
        public const int ERROR_INVALID_WINDOW_HANDLE = 0x00000578; // 1400

        /// <summary>
        ///     Invalid menu handle.
        /// </summary>
        public const int ERROR_INVALID_MENU_HANDLE = 0x00000579; // 1401

        /// <summary>
        ///     Invalid cursor handle.
        /// </summary>
        public const int ERROR_INVALID_CURSOR_HANDLE = 0x0000057A; // 1402

        /// <summary>
        ///     Invalid accelerator table handle.
        /// </summary>
        public const int ERROR_INVALID_ACCEL_HANDLE = 0x0000057B; // 1403

        /// <summary>
        ///     Invalid hook handle.
        /// </summary>
        public const int ERROR_INVALID_HOOK_HANDLE = 0x0000057C; // 1404

        /// <summary>
        ///     Invalid handle to a multiple-window position structure.
        /// </summary>
        public const int ERROR_INVALID_DWP_HANDLE = 0x0000057D; // 1405

        /// <summary>
        ///     Cannot create a top-level child window.
        /// </summary>
        public const int ERROR_TLW_WITH_WSCHILD = 0x0000057E; // 1406

        /// <summary>
        ///     Cannot find window class.
        /// </summary>
        public const int ERROR_CANNOT_FIND_WND_CLASS = 0x0000057F; // 1407

        /// <summary>
        ///     Invalid window; it belongs to other thread.
        /// </summary>
        public const int ERROR_WINDOW_OF_OTHER_THREAD = 0x00000580; // 1408

        /// <summary>
        ///     Hot key is already registered.
        /// </summary>
        public const int ERROR_HOTKEY_ALREADY_REGISTERED = 0x00000581; // 1409

        /// <summary>
        ///     Class already exists.
        /// </summary>
        public const int ERROR_CLASS_ALREADY_EXISTS = 0x00000582; // 1410

        /// <summary>
        ///     Class does not exist.
        /// </summary>
        public const int ERROR_CLASS_DOES_NOT_EXIST = 0x00000583; // 1411

        /// <summary>
        ///     Class still has open windows.
        /// </summary>
        public const int ERROR_CLASS_HAS_WINDOWS = 0x00000584; // 1412

        /// <summary>
        ///     Invalid index.
        /// </summary>
        public const int ERROR_INVALID_INDEX = 0x00000585; // 1413

        /// <summary>
        ///     Invalid icon handle.
        /// </summary>
        public const int ERROR_INVALID_ICON_HANDLE = 0x00000586; // 1414

        /// <summary>
        ///     Using private DIALOG window words.
        /// </summary>
        public const int ERROR_PRIVATE_DIALOG_INDEX = 0x00000587; // 1415

        /// <summary>
        ///     The list box identifier was not found.
        /// </summary>
        public const int ERROR_LISTBOX_ID_NOT_FOUND = 0x00000588; // 1416

        /// <summary>
        ///     No wild cards were found.
        /// </summary>
        public const int ERROR_NO_WILDCARD_CHARACTERS = 0x00000589; // 1417

        /// <summary>
        ///     Thread does not have a clipboard open.
        /// </summary>
        public const int ERROR_CLIPBOARD_NOT_OPEN = 0x0000058A; // 1418

        /// <summary>
        ///     Hot key is not registered.
        /// </summary>
        public const int ERROR_HOTKEY_NOT_REGISTERED = 0x0000058B; // 1419

        /// <summary>
        ///     The window is not a valid dialog window.
        /// </summary>
        public const int ERROR_WINDOW_NOT_DIALOG = 0x0000058C; // 1420

        /// <summary>
        ///     Control ID not found.
        /// </summary>
        public const int ERROR_CONTROL_ID_NOT_FOUND = 0x0000058D; // 1421

        /// <summary>
        ///     Invalid message for a combo box because it does not have an edit control.
        /// </summary>
        public const int ERROR_INVALID_COMBOBOX_MESSAGE = 0x0000058E; // 1422

        /// <summary>
        ///     The window is not a combo box.
        /// </summary>
        public const int ERROR_WINDOW_NOT_COMBOBOX = 0x0000058F; // 1423

        /// <summary>
        ///     Height must be less than 256.
        /// </summary>
        public const int ERROR_INVALID_EDIT_HEIGHT = 0x00000590; // 1424

        /// <summary>
        ///     Invalid device context (DC) handle.
        /// </summary>
        public const int ERROR_DC_NOT_FOUND = 0x00000591; // 1425

        /// <summary>
        ///     Invalid hook procedure type.
        /// </summary>
        public const int ERROR_INVALID_HOOK_FILTER = 0x00000592; // 1426

        /// <summary>
        ///     Invalid hook procedure.
        /// </summary>
        public const int ERROR_INVALID_FILTER_PROC = 0x00000593; // 1427

        /// <summary>
        ///     Cannot set nonlocal hook without a module handle.
        /// </summary>
        public const int ERROR_HOOK_NEEDS_HMOD = 0x00000594; // 1428

        /// <summary>
        ///     This hook procedure can only be set globally.
        /// </summary>
        public const int ERROR_GLOBAL_ONLY_HOOK = 0x00000595; // 1429

        /// <summary>
        ///     The journal hook procedure is already installed.
        /// </summary>
        public const int ERROR_JOURNAL_HOOK_SET = 0x00000596; // 1430

        /// <summary>
        ///     The hook procedure is not installed.
        /// </summary>
        public const int ERROR_HOOK_NOT_INSTALLED = 0x00000597; // 1431

        /// <summary>
        ///     Invalid message for single-selection list box.
        /// </summary>
        public const int ERROR_INVALID_LB_MESSAGE = 0x00000598; // 1432

        /// <summary>
        ///     LB_SETCOUNT sent to non-lazy list box.
        /// </summary>
        public const int ERROR_SETCOUNT_ON_BAD_LB = 0x00000599; // 1433

        /// <summary>
        ///     This list box does not support tab stops.
        /// </summary>
        public const int ERROR_LB_WITHOUT_TABSTOPS = 0x0000059A; // 1434

        /// <summary>
        ///     Cannot destroy object created by another thread.
        /// </summary>
        public const int ERROR_DESTROY_OBJECT_OF_OTHER_THREAD = 0x0000059B; // 1435

        /// <summary>
        ///     Child windows cannot have menus.
        /// </summary>
        public const int ERROR_CHILD_WINDOW_MENU = 0x0000059C; // 1436

        /// <summary>
        ///     The window does not have a system menu.
        /// </summary>
        public const int ERROR_NO_SYSTEM_MENU = 0x0000059D; // 1437

        /// <summary>
        ///     Invalid message box style.
        /// </summary>
        public const int ERROR_INVALID_MSGBOX_STYLE = 0x0000059E; // 1438

        /// <summary>
        ///     Invalid system-wide (SPI_*) parameter.
        /// </summary>
        public const int ERROR_INVALID_SPI_VALUE = 0x0000059F; // 1439

        /// <summary>
        ///     Screen already locked.
        /// </summary>
        public const int ERROR_SCREEN_ALREADY_LOCKED = 0x000005A0; // 1440

        /// <summary>
        ///     All handles to windows in a multiple-window position structure must have the same parent.
        /// </summary>
        public const int ERROR_HWNDS_HAVE_DIFF_PARENT = 0x000005A1; // 1441

        /// <summary>
        ///     The window is not a child window.
        /// </summary>
        public const int ERROR_NOT_CHILD_WINDOW = 0x000005A2; // 1442

        /// <summary>
        ///     Invalid GW_* command.
        /// </summary>
        public const int ERROR_INVALID_GW_COMMAND = 0x000005A3; // 1443

        /// <summary>
        ///     Invalid thread identifier.
        /// </summary>
        public const int ERROR_INVALID_THREAD_ID = 0x000005A4; // 1444

        /// <summary>
        ///     Cannot process a message from a window that is not a multiple document interface (MDI) window.
        /// </summary>
        public const int ERROR_NON_MDICHILD_WINDOW = 0x000005A5; // 1445

        /// <summary>
        ///     Popup menu already active.
        /// </summary>
        public const int ERROR_POPUP_ALREADY_ACTIVE = 0x000005A6; // 1446

        /// <summary>
        ///     The window does not have scroll bars.
        /// </summary>
        public const int ERROR_NO_SCROLLBARS = 0x000005A7; // 1447

        /// <summary>
        ///     Scroll bar range cannot be greater than MAXLONG.
        /// </summary>
        public const int ERROR_INVALID_SCROLLBAR_RANGE = 0x000005A8; // 1448

        /// <summary>
        ///     Cannot show or remove the window in the way specified.
        /// </summary>
        public const int ERROR_INVALID_SHOWWIN_COMMAND = 0x000005A9; // 1449

        /// <summary>
        ///     Insufficient system resources exist to complete the requested service.
        /// </summary>
        public const int ERROR_NO_SYSTEM_RESOURCES = 0x000005AA; // 1450

        /// <summary>
        ///     Insufficient system resources exist to complete the requested service.
        /// </summary>
        public const int ERROR_NONPAGED_SYSTEM_RESOURCES = 0x000005AB; // 1451

        /// <summary>
        ///     Insufficient system resources exist to complete the requested service.
        /// </summary>
        public const int ERROR_PAGED_SYSTEM_RESOURCES = 0x000005AC; // 1452

        /// <summary>
        ///     Insufficient quota to complete the requested service.
        /// </summary>
        public const int ERROR_WORKING_SET_QUOTA = 0x000005AD; // 1453

        /// <summary>
        ///     Insufficient quota to complete the requested service.
        /// </summary>
        public const int ERROR_PAGEFILE_QUOTA = 0x000005AE; // 1454

        /// <summary>
        ///     The paging file is too small for this operation to complete.
        /// </summary>
        public const int ERROR_COMMITMENT_LIMIT = 0x000005AF; // 1455

        /// <summary>
        ///     A menu item was not found.
        /// </summary>
        public const int ERROR_MENU_ITEM_NOT_FOUND = 0x000005B0; // 1456

        /// <summary>
        ///     Invalid keyboard layout handle.
        /// </summary>
        public const int ERROR_INVALID_KEYBOARD_HANDLE = 0x000005B1; // 1457

        /// <summary>
        ///     Hook type not allowed.
        /// </summary>
        public const int ERROR_HOOK_TYPE_NOT_ALLOWED = 0x000005B2; // 1458

        /// <summary>
        ///     This operation requires an interactive window station.
        /// </summary>
        public const int ERROR_REQUIRES_INTERACTIVE_WINDOWSTATION = 0x000005B3; // 1459

        /// <summary>
        ///     This operation returned because the timeout period expired.
        /// </summary>
        public const int ERROR_TIMEOUT = 0x000005B4; // 1460

        /// <summary>
        ///     Invalid monitor handle.
        /// </summary>
        public const int ERROR_INVALID_MONITOR_HANDLE = 0x000005B5; // 1461

        /// <summary>
        ///     Incorrect size argument.
        /// </summary>
        public const int ERROR_INCORRECT_SIZE = 0x000005B6; // 1462

        /// <summary>
        ///     The symbolic link cannot be followed because its type is disabled.
        /// </summary>
        public const int ERROR_SYMLINK_CLASS_DISABLED = 0x000005B7; // 1463

        /// <summary>
        ///     This application does not support the current operation on symbolic links.
        /// </summary>
        public const int ERROR_SYMLINK_NOT_SUPPORTED = 0x000005B8; // 1464

        /// <summary>
        ///     Windows was unable to parse the requested XML data.
        /// </summary>
        public const int ERROR_XML_PARSE_ERROR = 0x000005B9; // 1465

        /// <summary>
        ///     An error was encountered while processing an XML digital signature.
        /// </summary>
        public const int ERROR_XMLDSIG_ERROR = 0x000005BA; // 1466

        /// <summary>
        ///     This application must be restarted.
        /// </summary>
        public const int ERROR_RESTART_APPLICATION = 0x000005BB; // 1467

        /// <summary>
        ///     The caller made the connection request in the wrong routing compartment.
        /// </summary>
        public const int ERROR_WRONG_COMPARTMENT = 0x000005BC; // 1468

        /// <summary>
        ///     There was an AuthIP failure when attempting to connect to the remote host.
        /// </summary>
        public const int ERROR_AUTHIP_FAILURE = 0x000005BD; // 1469

        /// <summary>
        ///     Insufficient NVRAM resources exist to complete the requested service. A reboot might be required.
        /// </summary>
        public const int ERROR_NO_NVRAM_RESOURCES = 0x000005BE; // 1470

        /// <summary>
        ///     Unable to finish the requested operation because the specified process is not a GUI process.
        /// </summary>
        public const int ERROR_NOT_GUI_PROCESS = 0x000005BF; // 1471

        /// <summary>
        ///     The event log file is corrupted.
        /// </summary>
        public const int ERROR_EVENTLOG_FILE_CORRUPT = 0x000005DC; // 1500

        /// <summary>
        ///     No event log file could be opened, so the event logging service did not start.
        /// </summary>
        public const int ERROR_EVENTLOG_CANT_START = 0x000005DD; // 1501

        /// <summary>
        ///     The event log file is full.
        /// </summary>
        public const int ERROR_LOG_FILE_FULL = 0x000005DE; // 1502

        /// <summary>
        ///     The event log file has changed between read operations.
        /// </summary>
        public const int ERROR_EVENTLOG_FILE_CHANGED = 0x000005DF; // 1503

        /// <summary>
        ///     The specified task name is invalid.
        /// </summary>
        public const int ERROR_INVALID_TASK_NAME = 0x0000060E; // 1550

        /// <summary>
        ///     The specified task index is invalid.
        /// </summary>
        public const int ERROR_INVALID_TASK_INDEX = 0x0000060F; // 1551

        /// <summary>
        ///     The specified thread is already joining a task.
        /// </summary>
        public const int ERROR_THREAD_ALREADY_IN_TASK = 0x00000610; // 1552

        /// <summary>
        ///     The Windows Installer Service could not be accessed. This can occur if the Windows Installer is not correctly
        ///     installed. Contact your support personnel for assistance.
        /// </summary>
        public const int ERROR_INSTALL_SERVICE_FAILURE = 0x00000641; // 1601

        /// <summary>
        ///     User canceled installation.
        /// </summary>
        public const int ERROR_INSTALL_USEREXIT = 0x00000642; // 1602

        /// <summary>
        ///     Fatal error during installation.
        /// </summary>
        public const int ERROR_INSTALL_FAILURE = 0x00000643; // 1603

        /// <summary>
        ///     Installation suspended, incomplete.
        /// </summary>
        public const int ERROR_INSTALL_SUSPEND = 0x00000644; // 1604

        /// <summary>
        ///     This action is only valid for products that are currently installed.
        /// </summary>
        public const int ERROR_UNKNOWN_PRODUCT = 0x00000645; // 1605

        /// <summary>
        ///     Feature ID not registered.
        /// </summary>
        public const int ERROR_UNKNOWN_FEATURE = 0x00000646; // 1606

        /// <summary>
        ///     Component ID not registered.
        /// </summary>
        public const int ERROR_UNKNOWN_COMPONENT = 0x00000647; // 1607

        /// <summary>
        ///     Unknown property.
        /// </summary>
        public const int ERROR_UNKNOWN_PROPERTY = 0x00000648; // 1608

        /// <summary>
        ///     Handle is in an invalid state.
        /// </summary>
        public const int ERROR_INVALID_HANDLE_STATE = 0x00000649; // 1609

        /// <summary>
        ///     The configuration data for this product is corrupt. Contact your support personnel.
        /// </summary>
        public const int ERROR_BAD_CONFIGURATION = 0x0000064A; // 1610

        /// <summary>
        ///     Component qualifier not present.
        /// </summary>
        public const int ERROR_INDEX_ABSENT = 0x0000064B; // 1611

        /// <summary>
        ///     The installation source for this product is not available. Verify that the source exists and that you can access
        ///     it.
        /// </summary>
        public const int ERROR_INSTALL_SOURCE_ABSENT = 0x0000064C; // 1612

        /// <summary>
        ///     This installation package cannot be installed by the Windows Installer service. You must install a Windows service
        ///     pack that contains a newer version of the Windows Installer service.
        /// </summary>
        public const int ERROR_INSTALL_PACKAGE_VERSION = 0x0000064D; // 1613

        /// <summary>
        ///     Product is uninstalled.
        /// </summary>
        public const int ERROR_PRODUCT_UNINSTALLED = 0x0000064E; // 1614

        /// <summary>
        ///     SQL query syntax invalid or unsupported.
        /// </summary>
        public const int ERROR_BAD_QUERY_SYNTAX = 0x0000064F; // 1615

        /// <summary>
        ///     Record field does not exist.
        /// </summary>
        public const int ERROR_INVALID_FIELD = 0x00000650; // 1616

        /// <summary>
        ///     The device has been removed.
        /// </summary>
        public const int ERROR_DEVICE_REMOVED = 0x00000651; // 1617

        /// <summary>
        ///     Another installation is already in progress. Complete that installation before proceeding with this install.
        /// </summary>
        public const int ERROR_INSTALL_ALREADY_RUNNING = 0x00000652; // 1618

        /// <summary>
        ///     This installation package could not be opened. Verify that the package exists and that you can access it, or
        ///     contact the application vendor to verify that this is a valid Windows Installer package.
        /// </summary>
        public const int ERROR_INSTALL_PACKAGE_OPEN_FAILED = 0x00000653; // 1619

        /// <summary>
        ///     This installation package could not be opened. Contact the application vendor to verify that this is a valid
        ///     Windows Installer package.
        /// </summary>
        public const int ERROR_INSTALL_PACKAGE_INVALID = 0x00000654; // 1620

        /// <summary>
        ///     There was an error starting the Windows Installer service user interface. Contact your support personnel.
        /// </summary>
        public const int ERROR_INSTALL_UI_FAILURE = 0x00000655; // 1621

        /// <summary>
        ///     Error opening installation log file. Verify that the specified log file location exists and that you can write to
        ///     it.
        /// </summary>
        public const int ERROR_INSTALL_LOG_FAILURE = 0x00000656; // 1622

        /// <summary>
        ///     The language of this installation package is not supported by your system.
        /// </summary>
        public const int ERROR_INSTALL_LANGUAGE_UNSUPPORTED = 0x00000657; // 1623

        /// <summary>
        ///     Error applying transforms. Verify that the specified transform paths are valid.
        /// </summary>
        public const int ERROR_INSTALL_TRANSFORM_FAILURE = 0x00000658; // 1624

        /// <summary>
        ///     This installation is forbidden by system policy. Contact your system administrator.
        /// </summary>
        public const int ERROR_INSTALL_PACKAGE_REJECTED = 0x00000659; // 1625

        /// <summary>
        ///     Function could not be executed.
        /// </summary>
        public const int ERROR_FUNCTION_NOT_CALLED = 0x0000065A; // 1626

        /// <summary>
        ///     Function failed during execution.
        /// </summary>
        public const int ERROR_FUNCTION_FAILED = 0x0000065B; // 1627

        /// <summary>
        ///     Invalid or unknown table specified.
        /// </summary>
        public const int ERROR_INVALID_TABLE = 0x0000065C; // 1628

        /// <summary>
        ///     Data supplied is of wrong type.
        /// </summary>
        public const int ERROR_DATATYPE_MISMATCH = 0x0000065D; // 1629

        /// <summary>
        ///     Data of this type is not supported.
        /// </summary>
        public const int ERROR_UNSUPPORTED_TYPE = 0x0000065E; // 1630

        /// <summary>
        ///     The Windows Installer service failed to start. Contact your support personnel.
        /// </summary>
        public const int ERROR_CREATE_FAILED = 0x0000065F; // 1631

        /// <summary>
        ///     The Temp folder is on a drive that is full or is inaccessible. Free up space on the drive or verify that you have
        ///     write permission on the Temp folder.
        /// </summary>
        public const int ERROR_INSTALL_TEMP_UNWRITABLE = 0x00000660; // 1632

        /// <summary>
        ///     This installation package is not supported by this processor type. Contact your product vendor.
        /// </summary>
        public const int ERROR_INSTALL_PLATFORM_UNSUPPORTED = 0x00000661; // 1633

        /// <summary>
        ///     Component not used on this computer.
        /// </summary>
        public const int ERROR_INSTALL_NOTUSED = 0x00000662; // 1634

        /// <summary>
        ///     This update package could not be opened. Verify that the update package exists and that you can access it, or
        ///     contact the application vendor to verify that this is a valid Windows Installer update package.
        /// </summary>
        public const int ERROR_PATCH_PACKAGE_OPEN_FAILED = 0x00000663; // 1635

        /// <summary>
        ///     This update package could not be opened. Contact the application vendor to verify that this is a valid Windows
        ///     Installer update package.
        /// </summary>
        public const int ERROR_PATCH_PACKAGE_INVALID = 0x00000664; // 1636

        /// <summary>
        ///     This update package cannot be processed by the Windows Installer service. You must install a Windows service pack
        ///     that contains a newer version of the Windows Installer service.
        /// </summary>
        public const int ERROR_PATCH_PACKAGE_UNSUPPORTED = 0x00000665; // 1637

        /// <summary>
        ///     Another version of this product is already installed. Installation of this version cannot continue. To configure or
        ///     remove the existing version of this product, use Add/Remove Programs on the Control Panel.
        /// </summary>
        public const int ERROR_PRODUCT_VERSION = 0x00000666; // 1638

        /// <summary>
        ///     Invalid command line argument. Consult the Windows Installer SDK for detailed command line help.
        /// </summary>
        public const int ERROR_INVALID_COMMAND_LINE = 0x00000667; // 1639

        /// <summary>
        ///     Only administrators have permission to add, remove, or configure server software during a Terminal services remote
        ///     session. If you want to install or configure software on the server, contact your network administrator.
        /// </summary>
        public const int ERROR_INSTALL_REMOTE_DISALLOWED = 0x00000668; // 1640

        /// <summary>
        ///     The requested operation completed successfully. The system will be restarted so the changes can take effect.
        /// </summary>
        public const int ERROR_SUCCESS_REBOOT_INITIATED = 0x00000669; // 1641

        /// <summary>
        ///     The upgrade cannot be installed by the Windows Installer service because the program to be upgraded may be missing,
        ///     or the upgrade may update a different version of the program. Verify that the program to be upgraded exists on your
        ///     computer and that you have the correct upgrade.
        /// </summary>
        public const int ERROR_PATCH_TARGET_NOT_FOUND = 0x0000066A; // 1642

        /// <summary>
        ///     The update package is not permitted by software restriction policy.
        /// </summary>
        public const int ERROR_PATCH_PACKAGE_REJECTED = 0x0000066B; // 1643

        /// <summary>
        ///     One or more customizations are not permitted by software restriction policy.
        /// </summary>
        public const int ERROR_INSTALL_TRANSFORM_REJECTED = 0x0000066C; // 1644

        /// <summary>
        ///     The Windows Installer does not permit installation from a Remote Desktop Connection.
        /// </summary>
        public const int ERROR_INSTALL_REMOTE_PROHIBITED = 0x0000066D; // 1645

        /// <summary>
        ///     Uninstallation of the update package is not supported.
        /// </summary>
        public const int ERROR_PATCH_REMOVAL_UNSUPPORTED = 0x0000066E; // 1646

        /// <summary>
        ///     The update is not applied to this product.
        /// </summary>
        public const int ERROR_UNKNOWN_PATCH = 0x0000066F; // 1647

        /// <summary>
        ///     No valid sequence could be found for the set of updates.
        /// </summary>
        public const int ERROR_PATCH_NO_SEQUENCE = 0x00000670; // 1648

        /// <summary>
        ///     Update removal was disallowed by policy.
        /// </summary>
        public const int ERROR_PATCH_REMOVAL_DISALLOWED = 0x00000671; // 1649

        /// <summary>
        ///     The XML update data is invalid.
        /// </summary>
        public const int ERROR_INVALID_PATCH_XML = 0x00000672; // 1650

        /// <summary>
        ///     Windows Installer does not permit updating of managed advertised products. At least one feature of the product must
        ///     be installed before applying the update.
        /// </summary>
        public const int ERROR_PATCH_MANAGED_ADVERTISED_PRODUCT = 0x00000673; // 1651

        /// <summary>
        ///     The Windows Installer service is not accessible in Safe Mode. Please try again when your computer is not in Safe
        ///     Mode or you can use System Restore to return your machine to a previous good state.
        /// </summary>
        public const int ERROR_INSTALL_SERVICE_SAFEBOOT = 0x00000674; // 1652

        /// <summary>
        ///     A fail fast exception occurred. Exception handlers will not be invoked and the process will be terminated
        ///     immediately.
        /// </summary>
        public const int ERROR_FAIL_FAST_EXCEPTION = 0x00000675; // 1653

        /// <summary>
        ///     The app that you are trying to run is not supported on this version of Windows.
        /// </summary>
        public const int ERROR_INSTALL_REJECTED = 0x00000676; // 1654

        #endregion

        #region 1700 - 3999

        /// <summary>
        ///     The string binding is invalid.
        /// </summary>
        public const int RPC_S_INVALID_STRING_BINDING = 0x000006A4; // 1700

        /// <summary>
        ///     The binding handle is not the correct type.
        /// </summary>
        public const int RPC_S_WRONG_KIND_OF_BINDING = 0x000006A5; // 1701

        /// <summary>
        ///     The binding handle is invalid.
        /// </summary>
        public const int RPC_S_INVALID_BINDING = 0x000006A6; // 1702

        /// <summary>
        ///     The RPC protocol sequence is not supported.
        /// </summary>
        public const int RPC_S_PROTSEQ_NOT_SUPPORTED = 0x000006A7; // 1703

        /// <summary>
        ///     The RPC protocol sequence is invalid.
        /// </summary>
        public const int RPC_S_INVALID_RPC_PROTSEQ = 0x000006A8; // 1704

        /// <summary>
        ///     The string universal unique identifier (UUID) is invalid.
        /// </summary>
        public const int RPC_S_INVALID_STRING_UUID = 0x000006A9; // 1705

        /// <summary>
        ///     The endpoint format is invalid.
        /// </summary>
        public const int RPC_S_INVALID_ENDPOINT_FORMAT = 0x000006AA; // 1706

        /// <summary>
        ///     The network address is invalid.
        /// </summary>
        public const int RPC_S_INVALID_NET_ADDR = 0x000006AB; // 1707

        /// <summary>
        ///     No endpoint was found.
        /// </summary>
        public const int RPC_S_NO_ENDPOINT_FOUND = 0x000006AC; // 1708

        /// <summary>
        ///     The timeout value is invalid.
        /// </summary>
        public const int RPC_S_INVALID_TIMEOUT = 0x000006AD; // 1709

        /// <summary>
        ///     The object universal unique identifier (UUID) was not found.
        /// </summary>
        public const int RPC_S_OBJECT_NOT_FOUND = 0x000006AE; // 1710

        /// <summary>
        ///     The object universal unique identifier (UUID) has already been registered.
        /// </summary>
        public const int RPC_S_ALREADY_REGISTERED = 0x000006AF; // 1711

        /// <summary>
        ///     The type universal unique identifier (UUID) has already been registered.
        /// </summary>
        public const int RPC_S_TYPE_ALREADY_REGISTERED = 0x000006B0; // 1712

        /// <summary>
        ///     The RPC server is already listening.
        /// </summary>
        public const int RPC_S_ALREADY_LISTENING = 0x000006B1; // 1713

        /// <summary>
        ///     No protocol sequences have been registered.
        /// </summary>
        public const int RPC_S_NO_PROTSEQS_REGISTERED = 0x000006B2; // 1714

        /// <summary>
        ///     The RPC server is not listening.
        /// </summary>
        public const int RPC_S_NOT_LISTENING = 0x000006B3; // 1715

        /// <summary>
        ///     The manager type is unknown.
        /// </summary>
        public const int RPC_S_UNKNOWN_MGR_TYPE = 0x000006B4; // 1716

        /// <summary>
        ///     The interface is unknown.
        /// </summary>
        public const int RPC_S_UNKNOWN_IF = 0x000006B5; // 1717

        /// <summary>
        ///     There are no bindings.
        /// </summary>
        public const int RPC_S_NO_BINDINGS = 0x000006B6; // 1718

        /// <summary>
        ///     There are no protocol sequences.
        /// </summary>
        public const int RPC_S_NO_PROTSEQS = 0x000006B7; // 1719

        /// <summary>
        ///     The endpoint cannot be created.
        /// </summary>
        public const int RPC_S_CANT_CREATE_ENDPOINT = 0x000006B8; // 1720

        /// <summary>
        ///     Not enough resources are available to complete this operation.
        /// </summary>
        public const int RPC_S_OUT_OF_RESOURCES = 0x000006B9; // 1721

        /// <summary>
        ///     The RPC server is unavailable.
        /// </summary>
        public const int RPC_S_SERVER_UNAVAILABLE = 0x000006BA; // 1722

        /// <summary>
        ///     The RPC server is too busy to complete this operation.
        /// </summary>
        public const int RPC_S_SERVER_TOO_BUSY = 0x000006BB; // 1723

        /// <summary>
        ///     The network options are invalid.
        /// </summary>
        public const int RPC_S_INVALID_NETWORK_OPTIONS = 0x000006BC; // 1724

        /// <summary>
        ///     There are no remote procedure calls active on this thread.
        /// </summary>
        public const int RPC_S_NO_CALL_ACTIVE = 0x000006BD; // 1725

        /// <summary>
        ///     The remote procedure call failed.
        /// </summary>
        public const int RPC_S_CALL_FAILED = 0x000006BE; // 1726

        /// <summary>
        ///     The remote procedure call failed and did not execute.
        /// </summary>
        public const int RPC_S_CALL_FAILED_DNE = 0x000006BF; // 1727

        /// <summary>
        ///     A remote procedure call (RPC) protocol error occurred.
        /// </summary>
        public const int RPC_S_PROTOCOL_ERROR = 0x000006C0; // 1728

        /// <summary>
        ///     Access to the HTTP proxy is denied.
        /// </summary>
        public const int RPC_S_PROXY_ACCESS_DENIED = 0x000006C1; // 1729

        /// <summary>
        ///     The transfer syntax is not supported by the RPC server.
        /// </summary>
        public const int RPC_S_UNSUPPORTED_TRANS_SYN = 0x000006C2; // 1730

        /// <summary>
        ///     The universal unique identifier (UUID) type is not supported.
        /// </summary>
        public const int RPC_S_UNSUPPORTED_TYPE = 0x000006C4; // 1732

        /// <summary>
        ///     The tag is invalid.
        /// </summary>
        public const int RPC_S_INVALID_TAG = 0x000006C5; // 1733

        /// <summary>
        ///     The array bounds are invalid.
        /// </summary>
        public const int RPC_S_INVALID_BOUND = 0x000006C6; // 1734

        /// <summary>
        ///     The binding does not contain an entry name.
        /// </summary>
        public const int RPC_S_NO_ENTRY_NAME = 0x000006C7; // 1735

        /// <summary>
        ///     The name syntax is invalid.
        /// </summary>
        public const int RPC_S_INVALID_NAME_SYNTAX = 0x000006C8; // 1736

        /// <summary>
        ///     The name syntax is not supported.
        /// </summary>
        public const int RPC_S_UNSUPPORTED_NAME_SYNTAX = 0x000006C9; // 1737

        /// <summary>
        ///     No network address is available to use to construct a universal unique identifier (UUID).
        /// </summary>
        public const int RPC_S_UUID_NO_ADDRESS = 0x000006CB; // 1739

        /// <summary>
        ///     The endpoint is a duplicate.
        /// </summary>
        public const int RPC_S_DUPLICATE_ENDPOINT = 0x000006CC; // 1740

        /// <summary>
        ///     The authentication type is unknown.
        /// </summary>
        public const int RPC_S_UNKNOWN_AUTHN_TYPE = 0x000006CD; // 1741

        /// <summary>
        ///     The maximum number of calls is too small.
        /// </summary>
        public const int RPC_S_MAX_CALLS_TOO_SMALL = 0x000006CE; // 1742

        /// <summary>
        ///     The string is too long.
        /// </summary>
        public const int RPC_S_STRING_TOO_LONG = 0x000006CF; // 1743

        /// <summary>
        ///     The RPC protocol sequence was not found.
        /// </summary>
        public const int RPC_S_PROTSEQ_NOT_FOUND = 0x000006D0; // 1744

        /// <summary>
        ///     The procedure number is out of range.
        /// </summary>
        public const int RPC_S_PROCNUM_OUT_OF_RANGE = 0x000006D1; // 1745

        /// <summary>
        ///     The binding does not contain any authentication information.
        /// </summary>
        public const int RPC_S_BINDING_HAS_NO_AUTH = 0x000006D2; // 1746

        /// <summary>
        ///     The authentication service is unknown.
        /// </summary>
        public const int RPC_S_UNKNOWN_AUTHN_SERVICE = 0x000006D3; // 1747

        /// <summary>
        ///     The authentication level is unknown.
        /// </summary>
        public const int RPC_S_UNKNOWN_AUTHN_LEVEL = 0x000006D4; // 1748

        /// <summary>
        ///     The security context is invalid.
        /// </summary>
        public const int RPC_S_INVALID_AUTH_IDENTITY = 0x000006D5; // 1749

        /// <summary>
        ///     The authorization service is unknown.
        /// </summary>
        public const int RPC_S_UNKNOWN_AUTHZ_SERVICE = 0x000006D6; // 1750

        /// <summary>
        ///     The entry is invalid.
        /// </summary>
        public const int EPT_S_INVALID_ENTRY = 0x000006D7; // 1751

        /// <summary>
        ///     The server endpoint cannot perform the operation.
        /// </summary>
        public const int EPT_S_CANT_PERFORM_OP = 0x000006D8; // 1752

        /// <summary>
        ///     There are no more endpoints available from the endpoint mapper.
        /// </summary>
        public const int EPT_S_NOT_REGISTERED = 0x000006D9; // 1753

        /// <summary>
        ///     No interfaces have been exported.
        /// </summary>
        public const int RPC_S_NOTHING_TO_EXPORT = 0x000006DA; // 1754

        /// <summary>
        ///     The entry name is incomplete.
        /// </summary>
        public const int RPC_S_INCOMPLETE_NAME = 0x000006DB; // 1755

        /// <summary>
        ///     The version option is invalid.
        /// </summary>
        public const int RPC_S_INVALID_VERS_OPTION = 0x000006DC; // 1756

        /// <summary>
        ///     There are no more members.
        /// </summary>
        public const int RPC_S_NO_MORE_MEMBERS = 0x000006DD; // 1757

        /// <summary>
        ///     There is nothing to unexport.
        /// </summary>
        public const int RPC_S_NOT_ALL_OBJS_UNEXPORTED = 0x000006DE; // 1758

        /// <summary>
        ///     The interface was not found.
        /// </summary>
        public const int RPC_S_INTERFACE_NOT_FOUND = 0x000006DF; // 1759

        /// <summary>
        ///     The entry already exists.
        /// </summary>
        public const int RPC_S_ENTRY_ALREADY_EXISTS = 0x000006E0; // 1760

        /// <summary>
        ///     The entry is not found.
        /// </summary>
        public const int RPC_S_ENTRY_NOT_FOUND = 0x000006E1; // 1761

        /// <summary>
        ///     The name service is unavailable.
        /// </summary>
        public const int RPC_S_NAME_SERVICE_UNAVAILABLE = 0x000006E2; // 1762

        /// <summary>
        ///     The network address family is invalid.
        /// </summary>
        public const int RPC_S_INVALID_NAF_ID = 0x000006E3; // 1763

        /// <summary>
        ///     The requested operation is not supported.
        /// </summary>
        public const int RPC_S_CANNOT_SUPPORT = 0x000006E4; // 1764

        /// <summary>
        ///     No security context is available to allow impersonation.
        /// </summary>
        public const int RPC_S_NO_CONTEXT_AVAILABLE = 0x000006E5; // 1765

        /// <summary>
        ///     An internal error occurred in a remote procedure call (RPC).
        /// </summary>
        public const int RPC_S_INTERNAL_ERROR = 0x000006E6; // 1766

        /// <summary>
        ///     The RPC server attempted an integer division by zero.
        /// </summary>
        public const int RPC_S_ZERO_DIVIDE = 0x000006E7; // 1767

        /// <summary>
        ///     An addressing error occurred in the RPC server.
        /// </summary>
        public const int RPC_S_ADDRESS_ERROR = 0x000006E8; // 1768

        /// <summary>
        ///     A floating-point operation at the RPC server caused a division by zero.
        /// </summary>
        public const int RPC_S_FP_DIV_ZERO = 0x000006E9; // 1769

        /// <summary>
        ///     A floating-point underflow occurred at the RPC server.
        /// </summary>
        public const int RPC_S_FP_UNDERFLOW = 0x000006EA; // 1770

        /// <summary>
        ///     A floating-point overflow occurred at the RPC server.
        /// </summary>
        public const int RPC_S_FP_OVERFLOW = 0x000006EB; // 1771

        /// <summary>
        ///     The list of RPC servers available for the binding of auto handles has been exhausted.
        /// </summary>
        public const int RPC_X_NO_MORE_ENTRIES = 0x000006EC; // 1772

        /// <summary>
        ///     Unable to open the character translation table file.
        /// </summary>
        public const int RPC_X_SS_CHAR_TRANS_OPEN_FAIL = 0x000006ED; // 1773

        /// <summary>
        ///     The file containing the character translation table has fewer than 512 bytes.
        /// </summary>
        public const int RPC_X_SS_CHAR_TRANS_SHORT_FILE = 0x000006EE; // 1774

        /// <summary>
        ///     A null context handle was passed from the client to the host during a remote procedure call.
        /// </summary>
        public const int RPC_X_SS_IN_NULL_CONTEXT = 0x000006EF; // 1775

        /// <summary>
        ///     The context handle changed during a remote procedure call.
        /// </summary>
        public const int RPC_X_SS_CONTEXT_DAMAGED = 0x000006F1; // 1777

        /// <summary>
        ///     The binding handles passed to a remote procedure call do not match.
        /// </summary>
        public const int RPC_X_SS_HANDLES_MISMATCH = 0x000006F2; // 1778

        /// <summary>
        ///     The stub is unable to get the remote procedure call handle.
        /// </summary>
        public const int RPC_X_SS_CANNOT_GET_CALL_HANDLE = 0x000006F3; // 1779

        /// <summary>
        ///     A null reference pointer was passed to the stub.
        /// </summary>
        public const int RPC_X_NULL_REF_POINTER = 0x000006F4; // 1780

        /// <summary>
        ///     The enumeration value is out of range.
        /// </summary>
        public const int RPC_X_ENUM_VALUE_OUT_OF_RANGE = 0x000006F5; // 1781

        /// <summary>
        ///     The byte count is too small.
        /// </summary>
        public const int RPC_X_BYTE_COUNT_TOO_SMALL = 0x000006F6; // 1782

        /// <summary>
        ///     The stub received bad data.
        /// </summary>
        public const int RPC_X_BAD_STUB_DATA = 0x000006F7; // 1783

        /// <summary>
        ///     The supplied user buffer is not valid for the requested operation.
        /// </summary>
        public const int ERROR_INVALID_USER_BUFFER = 0x000006F8; // 1784

        /// <summary>
        ///     The disk media is not recognized. It may not be formatted.
        /// </summary>
        public const int ERROR_UNRECOGNIZED_MEDIA = 0x000006F9; // 1785

        /// <summary>
        ///     The workstation does not have a trust secret.
        /// </summary>
        public const int ERROR_NO_TRUST_LSA_SECRET = 0x000006FA; // 1786

        /// <summary>
        ///     The security database on the server does not have a computer account for this workstation trust relationship.
        /// </summary>
        public const int ERROR_NO_TRUST_SAM_ACCOUNT = 0x000006FB; // 1787

        /// <summary>
        ///     The trust relationship between the primary domain and the trusted domain failed.
        /// </summary>
        public const int ERROR_TRUSTED_DOMAIN_FAILURE = 0x000006FC; // 1788

        /// <summary>
        ///     The trust relationship between this workstation and the primary domain failed.
        /// </summary>
        public const int ERROR_TRUSTED_RELATIONSHIP_FAILURE = 0x000006FD; // 1789

        /// <summary>
        ///     The network logon failed.
        /// </summary>
        public const int ERROR_TRUST_FAILURE = 0x000006FE; // 1790

        /// <summary>
        ///     A remote procedure call is already in progress for this thread.
        /// </summary>
        public const int RPC_S_CALL_IN_PROGRESS = 0x000006FF; // 1791

        /// <summary>
        ///     An attempt was made to logon, but the network logon service was not started.
        /// </summary>
        public const int ERROR_NETLOGON_NOT_STARTED = 0x00000700; // 1792

        /// <summary>
        ///     The user's account has expired.
        /// </summary>
        public const int ERROR_ACCOUNT_EXPIRED = 0x00000701; // 1793

        /// <summary>
        ///     The redirector is in use and cannot be unloaded.
        /// </summary>
        public const int ERROR_REDIRECTOR_HAS_OPEN_HANDLES = 0x00000702; // 1794

        /// <summary>
        ///     The specified printer driver is already installed.
        /// </summary>
        public const int ERROR_PRINTER_DRIVER_ALREADY_INSTALLED = 0x00000703; // 1795

        /// <summary>
        ///     The specified port is unknown.
        /// </summary>
        public const int ERROR_UNKNOWN_PORT = 0x00000704; // 1796

        /// <summary>
        ///     The printer driver is unknown.
        /// </summary>
        public const int ERROR_UNKNOWN_PRINTER_DRIVER = 0x00000705; // 1797

        /// <summary>
        ///     The print processor is unknown.
        /// </summary>
        public const int ERROR_UNKNOWN_PRINTPROCESSOR = 0x00000706; // 1798

        /// <summary>
        ///     The specified separator file is invalid.
        /// </summary>
        public const int ERROR_INVALID_SEPARATOR_FILE = 0x00000707; // 1799

        /// <summary>
        ///     The specified priority is invalid.
        /// </summary>
        public const int ERROR_INVALID_PRIORITY = 0x00000708; // 1800

        /// <summary>
        ///     The printer name is invalid.
        /// </summary>
        public const int ERROR_INVALID_PRINTER_NAME = 0x00000709; // 1801

        /// <summary>
        ///     The printer already exists.
        /// </summary>
        public const int ERROR_PRINTER_ALREADY_EXISTS = 0x0000070A; // 1802

        /// <summary>
        ///     The printer command is invalid.
        /// </summary>
        public const int ERROR_INVALID_PRINTER_COMMAND = 0x0000070B; // 1803

        /// <summary>
        ///     The specified datatype is invalid.
        /// </summary>
        public const int ERROR_INVALID_DATATYPE = 0x0000070C; // 1804

        /// <summary>
        ///     The environment specified is invalid.
        /// </summary>
        public const int ERROR_INVALID_ENVIRONMENT = 0x0000070D; // 1805

        /// <summary>
        ///     There are no more bindings.
        /// </summary>
        public const int RPC_S_NO_MORE_BINDINGS = 0x0000070E; // 1806

        /// <summary>
        ///     The account used is an interdomain trust account. Use your global user account or local user account to access this
        ///     server.
        /// </summary>
        public const int ERROR_NOLOGON_INTERDOMAIN_TRUST_ACCOUNT = 0x0000070F; // 1807

        /// <summary>
        ///     The account used is a computer account. Use your global user account or local user account to access this server.
        /// </summary>
        public const int ERROR_NOLOGON_WORKSTATION_TRUST_ACCOUNT = 0x00000710; // 1808

        /// <summary>
        ///     The account used is a server trust account. Use your global user account or local user account to access this
        ///     server.
        /// </summary>
        public const int ERROR_NOLOGON_SERVER_TRUST_ACCOUNT = 0x00000711; // 1809

        /// <summary>
        ///     The name or security ID (SID) of the domain specified is inconsistent with the trust information for that domain.
        /// </summary>
        public const int ERROR_DOMAIN_TRUST_INCONSISTENT = 0x00000712; // 1810

        /// <summary>
        ///     The server is in use and cannot be unloaded.
        /// </summary>
        public const int ERROR_SERVER_HAS_OPEN_HANDLES = 0x00000713; // 1811

        /// <summary>
        ///     The specified image file did not contain a resource section.
        /// </summary>
        public const int ERROR_RESOURCE_DATA_NOT_FOUND = 0x00000714; // 1812

        /// <summary>
        ///     The specified resource type cannot be found in the image file.
        /// </summary>
        public const int ERROR_RESOURCE_TYPE_NOT_FOUND = 0x00000715; // 1813

        /// <summary>
        ///     The specified resource name cannot be found in the image file.
        /// </summary>
        public const int ERROR_RESOURCE_NAME_NOT_FOUND = 0x00000716; // 1814

        /// <summary>
        ///     The specified resource language ID cannot be found in the image file.
        /// </summary>
        public const int ERROR_RESOURCE_LANG_NOT_FOUND = 0x00000717; // 1815

        /// <summary>
        ///     Not enough quota is available to process this command.
        /// </summary>
        public const int ERROR_NOT_ENOUGH_QUOTA = 0x00000718; // 1816

        /// <summary>
        ///     No interfaces have been registered.
        /// </summary>
        public const int RPC_S_NO_INTERFACES = 0x00000719; // 1817

        /// <summary>
        ///     The remote procedure call was canceled.
        /// </summary>
        public const int RPC_S_CALL_CANCELLED = 0x0000071A; // 1818

        /// <summary>
        ///     The binding handle does not contain all required information.
        /// </summary>
        public const int RPC_S_BINDING_INCOMPLETE = 0x0000071B; // 1819

        /// <summary>
        ///     A communications failure occurred during a remote procedure call.
        /// </summary>
        public const int RPC_S_COMM_FAILURE = 0x0000071C; // 1820

        /// <summary>
        ///     The requested authentication level is not supported.
        /// </summary>
        public const int RPC_S_UNSUPPORTED_AUTHN_LEVEL = 0x0000071D; // 1821

        /// <summary>
        ///     No principal name registered.
        /// </summary>
        public const int RPC_S_NO_PRINC_NAME = 0x0000071E; // 1822

        /// <summary>
        ///     The error specified is not a valid Windows RPC error code.
        /// </summary>
        public const int RPC_S_NOT_RPC_ERROR = 0x0000071F; // 1823

        /// <summary>
        ///     A UUID that is valid only on this computer has been allocated.
        /// </summary>
        public const int RPC_S_UUID_LOCAL_ONLY = 0x00000720; // 1824

        /// <summary>
        ///     A security package specific error occurred.
        /// </summary>
        public const int RPC_S_SEC_PKG_ERROR = 0x00000721; // 1825

        /// <summary>
        ///     Thread is not canceled.
        /// </summary>
        public const int RPC_S_NOT_CANCELLED = 0x00000722; // 1826

        /// <summary>
        ///     Invalid operation on the encoding/decoding handle.
        /// </summary>
        public const int RPC_X_INVALID_ES_ACTION = 0x00000723; // 1827

        /// <summary>
        ///     Incompatible version of the serializing package.
        /// </summary>
        public const int RPC_X_WRONG_ES_VERSION = 0x00000724; // 1828

        /// <summary>
        ///     Incompatible version of the RPC stub.
        /// </summary>
        public const int RPC_X_WRONG_STUB_VERSION = 0x00000725; // 1829

        /// <summary>
        ///     The RPC pipe object is invalid or corrupted.
        /// </summary>
        public const int RPC_X_INVALID_PIPE_OBJECT = 0x00000726; // 1830

        /// <summary>
        ///     An invalid operation was attempted on an RPC pipe object.
        /// </summary>
        public const int RPC_X_WRONG_PIPE_ORDER = 0x00000727; // 1831

        /// <summary>
        ///     Unsupported RPC pipe version.
        /// </summary>
        public const int RPC_X_WRONG_PIPE_VERSION = 0x00000728; // 1832

        /// <summary>
        ///     HTTP proxy server rejected the connection because the cookie authentication failed.
        /// </summary>
        public const int RPC_S_COOKIE_AUTH_FAILED = 0x00000729; // 1833

        /// <summary>
        ///     The group member was not found.
        /// </summary>
        public const int RPC_S_GROUP_MEMBER_NOT_FOUND = 0x0000076A; // 1898

        /// <summary>
        ///     The endpoint mapper database entry could not be created.
        /// </summary>
        public const int EPT_S_CANT_CREATE = 0x0000076B; // 1899

        /// <summary>
        ///     The object universal unique identifier (UUID) is the nil UUID.
        /// </summary>
        public const int RPC_S_INVALID_OBJECT = 0x0000076C; // 1900

        /// <summary>
        ///     The specified time is invalid.
        /// </summary>
        public const int ERROR_INVALID_TIME = 0x0000076D; // 1901

        /// <summary>
        ///     The specified form name is invalid.
        /// </summary>
        public const int ERROR_INVALID_FORM_NAME = 0x0000076E; // 1902

        /// <summary>
        ///     The specified form size is invalid.
        /// </summary>
        public const int ERROR_INVALID_FORM_SIZE = 0x0000076F; // 1903

        /// <summary>
        ///     The specified printer handle is already being waited on.
        /// </summary>
        public const int ERROR_ALREADY_WAITING = 0x00000770; // 1904

        /// <summary>
        ///     The specified printer has been deleted.
        /// </summary>
        public const int ERROR_PRINTER_DELETED = 0x00000771; // 1905

        /// <summary>
        ///     The state of the printer is invalid.
        /// </summary>
        public const int ERROR_INVALID_PRINTER_STATE = 0x00000772; // 1906

        /// <summary>
        ///     The user's password must be changed before signing in.
        /// </summary>
        public const int ERROR_PASSWORD_MUST_CHANGE = 0x00000773; // 1907

        /// <summary>
        ///     Could not find the domain controller for this domain.
        /// </summary>
        public const int ERROR_DOMAIN_CONTROLLER_NOT_FOUND = 0x00000774; // 1908

        /// <summary>
        ///     The referenced account is currently locked out and may not be logged on to.
        /// </summary>
        public const int ERROR_ACCOUNT_LOCKED_OUT = 0x00000775; // 1909

        /// <summary>
        ///     The object exporter specified was not found.
        /// </summary>
        public const int OR_INVALID_OXID = 0x00000776; // 1910

        /// <summary>
        ///     The object specified was not found.
        /// </summary>
        public const int OR_INVALID_OID = 0x00000777; // 1911

        /// <summary>
        ///     The object resolver set specified was not found.
        /// </summary>
        public const int OR_INVALID_SET = 0x00000778; // 1912

        /// <summary>
        ///     Some data remains to be sent in the request buffer.
        /// </summary>
        public const int RPC_S_SEND_INCOMPLETE = 0x00000779; // 1913

        /// <summary>
        ///     Invalid asynchronous remote procedure call handle.
        /// </summary>
        public const int RPC_S_INVALID_ASYNC_HANDLE = 0x0000077A; // 1914

        /// <summary>
        ///     Invalid asynchronous RPC call handle for this operation.
        /// </summary>
        public const int RPC_S_INVALID_ASYNC_CALL = 0x0000077B; // 1915

        /// <summary>
        ///     The RPC pipe object has already been closed.
        /// </summary>
        public const int RPC_X_PIPE_CLOSED = 0x0000077C; // 1916

        /// <summary>
        ///     The RPC call completed before all pipes were processed.
        /// </summary>
        public const int RPC_X_PIPE_DISCIPLINE_ERROR = 0x0000077D; // 1917

        /// <summary>
        ///     No more data is available from the RPC pipe.
        /// </summary>
        public const int RPC_X_PIPE_EMPTY = 0x0000077E; // 1918

        /// <summary>
        ///     No site name is available for this machine.
        /// </summary>
        public const int ERROR_NO_SITENAME = 0x0000077F; // 1919

        /// <summary>
        ///     The file cannot be accessed by the system.
        /// </summary>
        public const int ERROR_CANT_ACCESS_FILE = 0x00000780; // 1920

        /// <summary>
        ///     The name of the file cannot be resolved by the system.
        /// </summary>
        public const int ERROR_CANT_RESOLVE_FILENAME = 0x00000781; // 1921

        /// <summary>
        ///     The entry is not of the expected type.
        /// </summary>
        public const int RPC_S_ENTRY_TYPE_MISMATCH = 0x00000782; // 1922

        /// <summary>
        ///     Not all object UUIDs could be exported to the specified entry.
        /// </summary>
        public const int RPC_S_NOT_ALL_OBJS_EXPORTED = 0x00000783; // 1923

        /// <summary>
        ///     Interface could not be exported to the specified entry.
        /// </summary>
        public const int RPC_S_INTERFACE_NOT_EXPORTED = 0x00000784; // 1924

        /// <summary>
        ///     The specified profile entry could not be added.
        /// </summary>
        public const int RPC_S_PROFILE_NOT_ADDED = 0x00000785; // 1925

        /// <summary>
        ///     The specified profile element could not be added.
        /// </summary>
        public const int RPC_S_PRF_ELT_NOT_ADDED = 0x00000786; // 1926

        /// <summary>
        ///     The specified profile element could not be removed.
        /// </summary>
        public const int RPC_S_PRF_ELT_NOT_REMOVED = 0x00000787; // 1927

        /// <summary>
        ///     The group element could not be added.
        /// </summary>
        public const int RPC_S_GRP_ELT_NOT_ADDED = 0x00000788; // 1928

        /// <summary>
        ///     The group element could not be removed.
        /// </summary>
        public const int RPC_S_GRP_ELT_NOT_REMOVED = 0x00000789; // 1929

        /// <summary>
        ///     The printer driver is not compatible with a policy enabled on your computer that blocks NT 4.0 drivers.
        /// </summary>
        public const int ERROR_KM_DRIVER_BLOCKED = 0x0000078A; // 1930

        /// <summary>
        ///     The context has expired and can no longer be used.
        /// </summary>
        public const int ERROR_CONTEXT_EXPIRED = 0x0000078B; // 1931

        /// <summary>
        ///     The current user's delegated trust creation quota has been exceeded.
        /// </summary>
        public const int ERROR_PER_USER_TRUST_QUOTA_EXCEEDED = 0x0000078C; // 1932

        /// <summary>
        ///     The total delegated trust creation quota has been exceeded.
        /// </summary>
        public const int ERROR_ALL_USER_TRUST_QUOTA_EXCEEDED = 0x0000078D; // 1933

        /// <summary>
        ///     The current user's delegated trust deletion quota has been exceeded.
        /// </summary>
        public const int ERROR_USER_DELETE_TRUST_QUOTA_EXCEEDED = 0x0000078E; // 1934

        /// <summary>
        ///     The computer you are signing into is protected by an authentication firewall. The specified account is not allowed
        ///     to authenticate to the computer.
        /// </summary>
        public const int ERROR_AUTHENTICATION_FIREWALL_FAILED = 0x0000078F; // 1935

        /// <summary>
        ///     Remote connections to the Print Spooler are blocked by a policy set on your machine.
        /// </summary>
        public const int ERROR_REMOTE_PRINT_CONNECTIONS_BLOCKED = 0x00000790; // 1936

        /// <summary>
        ///     Authentication failed because NTLM authentication has been disabled.
        /// </summary>
        public const int ERROR_NTLM_BLOCKED = 0x00000791; // 1937

        /// <summary>
        ///     Logon Failure: EAS policy requires that the user change their password before this operation can be performed.
        /// </summary>
        public const int ERROR_PASSWORD_CHANGE_REQUIRED = 0x00000792; // 1938

        /// <summary>
        ///     The pixel format is invalid.
        /// </summary>
        public const int ERROR_INVALID_PIXEL_FORMAT = 0x000007D0; // 2000

        /// <summary>
        ///     The specified driver is invalid.
        /// </summary>
        public const int ERROR_BAD_DRIVER = 0x000007D1; // 2001

        /// <summary>
        ///     The window style or class attribute is invalid for this operation.
        /// </summary>
        public const int ERROR_INVALID_WINDOW_STYLE = 0x000007D2; // 2002

        /// <summary>
        ///     The requested metafile operation is not supported.
        /// </summary>
        public const int ERROR_METAFILE_NOT_SUPPORTED = 0x000007D3; // 2003

        /// <summary>
        ///     The requested transformation operation is not supported.
        /// </summary>
        public const int ERROR_TRANSFORM_NOT_SUPPORTED = 0x000007D4; // 2004

        /// <summary>
        ///     The requested clipping operation is not supported.
        /// </summary>
        public const int ERROR_CLIPPING_NOT_SUPPORTED = 0x000007D5; // 2005

        /// <summary>
        ///     The specified color management module is invalid.
        /// </summary>
        public const int ERROR_INVALID_CMM = 0x000007DA; // 2010

        /// <summary>
        ///     The specified color profile is invalid.
        /// </summary>
        public const int ERROR_INVALID_PROFILE = 0x000007DB; // 2011

        /// <summary>
        ///     The specified tag was not found.
        /// </summary>
        public const int ERROR_TAG_NOT_FOUND = 0x000007DC; // 2012

        /// <summary>
        ///     A required tag is not present.
        /// </summary>
        public const int ERROR_TAG_NOT_PRESENT = 0x000007DD; // 2013

        /// <summary>
        ///     The specified tag is already present.
        /// </summary>
        public const int ERROR_DUPLICATE_TAG = 0x000007DE; // 2014

        /// <summary>
        ///     The specified color profile is not associated with the specified device.
        /// </summary>
        public const int ERROR_PROFILE_NOT_ASSOCIATED_WITH_DEVICE = 0x000007DF; // 2015

        /// <summary>
        ///     The specified color profile was not found.
        /// </summary>
        public const int ERROR_PROFILE_NOT_FOUND = 0x000007E0; // 2016

        /// <summary>
        ///     The specified color space is invalid.
        /// </summary>
        public const int ERROR_INVALID_COLORSPACE = 0x000007E1; // 2017

        /// <summary>
        ///     Image Color Management is not enabled.
        /// </summary>
        public const int ERROR_ICM_NOT_ENABLED = 0x000007E2; // 2018

        /// <summary>
        ///     There was an error while deleting the color transform.
        /// </summary>
        public const int ERROR_DELETING_ICM_XFORM = 0x000007E3; // 2019

        /// <summary>
        ///     The specified color transform is invalid.
        /// </summary>
        public const int ERROR_INVALID_TRANSFORM = 0x000007E4; // 2020

        /// <summary>
        ///     The specified transform does not match the bitmap's color space.
        /// </summary>
        public const int ERROR_COLORSPACE_MISMATCH = 0x000007E5; // 2021

        /// <summary>
        ///     The specified named color index is not present in the profile.
        /// </summary>
        public const int ERROR_INVALID_COLORINDEX = 0x000007E6; // 2022

        /// <summary>
        ///     The specified profile is intended for a device of a different type than the specified device.
        /// </summary>
        public const int ERROR_PROFILE_DOES_NOT_MATCH_DEVICE = 0x000007E7; // 2023

        /// <summary>
        ///     The network connection was made successfully, but the user had to be prompted for a password other than the one
        ///     originally specified.
        /// </summary>
        public const int ERROR_CONNECTED_OTHER_PASSWORD = 0x0000083C; // 2108

        /// <summary>
        ///     The network connection was made successfully using default credentials.
        /// </summary>
        public const int ERROR_CONNECTED_OTHER_PASSWORD_DEFAULT = 0x0000083D; // 2109

        /// <summary>
        ///     The specified username is invalid.
        /// </summary>
        public const int ERROR_BAD_USERNAME = 0x0000089A; // 2202

        /// <summary>
        ///     This network connection does not exist.
        /// </summary>
        public const int ERROR_NOT_CONNECTED = 0x000008CA; // 2250

        /// <summary>
        ///     This network connection has files open or requests pending.
        /// </summary>
        public const int ERROR_OPEN_FILES = 0x00000961; // 2401

        /// <summary>
        ///     Active connections still exist.
        /// </summary>
        public const int ERROR_ACTIVE_CONNECTIONS = 0x00000962; // 2402

        /// <summary>
        ///     The device is in use by an active process and cannot be disconnected.
        /// </summary>
        public const int ERROR_DEVICE_IN_USE = 0x00000964; // 2404

        /// <summary>
        ///     The specified print monitor is unknown.
        /// </summary>
        public const int ERROR_UNKNOWN_PRINT_MONITOR = 0x00000BB8; // 3000

        /// <summary>
        ///     The specified printer driver is currently in use.
        /// </summary>
        public const int ERROR_PRINTER_DRIVER_IN_USE = 0x00000BB9; // 3001

        /// <summary>
        ///     The spool file was not found.
        /// </summary>
        public const int ERROR_SPOOL_FILE_NOT_FOUND = 0x00000BBA; // 3002

        /// <summary>
        ///     A StartDocPrinter call was not issued.
        /// </summary>
        public const int ERROR_SPL_NO_STARTDOC = 0x00000BBB; // 3003

        /// <summary>
        ///     An AddJob call was not issued.
        /// </summary>
        public const int ERROR_SPL_NO_ADDJOB = 0x00000BBC; // 3004

        /// <summary>
        ///     The specified print processor has already been installed.
        /// </summary>
        public const int ERROR_PRINT_PROCESSOR_ALREADY_INSTALLED = 0x00000BBD; // 3005

        /// <summary>
        ///     The specified print monitor has already been installed.
        /// </summary>
        public const int ERROR_PRINT_MONITOR_ALREADY_INSTALLED = 0x00000BBE; // 3006

        /// <summary>
        ///     The specified print monitor does not have the required functions.
        /// </summary>
        public const int ERROR_INVALID_PRINT_MONITOR = 0x00000BBF; // 3007

        /// <summary>
        ///     The specified print monitor is currently in use.
        /// </summary>
        public const int ERROR_PRINT_MONITOR_IN_USE = 0x00000BC0; // 3008

        /// <summary>
        ///     The requested operation is not allowed when there are jobs queued to the printer.
        /// </summary>
        public const int ERROR_PRINTER_HAS_JOBS_QUEUED = 0x00000BC1; // 3009

        /// <summary>
        ///     The requested operation is successful. Changes will not be effective until the system is rebooted.
        /// </summary>
        public const int ERROR_SUCCESS_REBOOT_REQUIRED = 0x00000BC2; // 3010

        /// <summary>
        ///     The requested operation is successful. Changes will not be effective until the service is restarted.
        /// </summary>
        public const int ERROR_SUCCESS_RESTART_REQUIRED = 0x00000BC3; // 3011

        /// <summary>
        ///     No printers were found.
        /// </summary>
        public const int ERROR_PRINTER_NOT_FOUND = 0x00000BC4; // 3012

        /// <summary>
        ///     The printer driver is known to be unreliable.
        /// </summary>
        public const int ERROR_PRINTER_DRIVER_WARNED = 0x00000BC5; // 3013

        /// <summary>
        ///     The printer driver is known to harm the system.
        /// </summary>
        public const int ERROR_PRINTER_DRIVER_BLOCKED = 0x00000BC6; // 3014

        /// <summary>
        ///     The specified printer driver package is currently in use.
        /// </summary>
        public const int ERROR_PRINTER_DRIVER_PACKAGE_IN_USE = 0x00000BC7; // 3015

        /// <summary>
        ///     Unable to find a core driver package that is required by the printer driver package.
        /// </summary>
        public const int ERROR_CORE_DRIVER_PACKAGE_NOT_FOUND = 0x00000BC8; // 3016

        /// <summary>
        ///     The requested operation failed. A system reboot is required to roll back changes made.
        /// </summary>
        public const int ERROR_FAIL_REBOOT_REQUIRED = 0x00000BC9; // 3017

        /// <summary>
        ///     The requested operation failed. A system reboot has been initiated to roll back changes made.
        /// </summary>
        public const int ERROR_FAIL_REBOOT_INITIATED = 0x00000BCA; // 3018

        /// <summary>
        ///     The specified printer driver was not found on the system and needs to be downloaded.
        /// </summary>
        public const int ERROR_PRINTER_DRIVER_DOWNLOAD_NEEDED = 0x00000BCB; // 3019

        /// <summary>
        ///     The requested print job has failed to print. A print system update requires the job to be resubmitted.
        /// </summary>
        public const int ERROR_PRINT_JOB_RESTART_REQUIRED = 0x00000BCC; // 3020

        /// <summary>
        ///     The printer driver does not contain a valid manifest, or contains too many manifests.
        /// </summary>
        public const int ERROR_INVALID_PRINTER_DRIVER_MANIFEST = 0x00000BCD; // 3021

        /// <summary>
        ///     The specified printer cannot be shared.
        /// </summary>
        public const int ERROR_PRINTER_NOT_SHAREABLE = 0x00000BCE; // 3022

        /// <summary>
        ///     The operation was paused.
        /// </summary>
        public const int ERROR_REQUEST_PAUSED = 0x00000BEA; // 3050

        /// <summary>
        ///     Reissue the given operation as a cached IO operation.
        /// </summary>
        public const int ERROR_IO_REISSUE_AS_CACHED = 0x00000F6E; // 3950

        #endregion

        #region 4000 - 5999

        /// <summary>
        ///     WINS encountered an error while processing the command.
        /// </summary>
        public const int ERROR_WINS_INTERNAL = 0x00000FA0; // 4000

        /// <summary>
        ///     The local WINS cannot be deleted.
        /// </summary>
        public const int ERROR_CAN_NOT_DEL_LOCAL_WINS = 0x00000FA1; // 4001

        /// <summary>
        ///     The importation from the file failed.
        /// </summary>
        public const int ERROR_STATIC_INIT = 0x00000FA2; // 4002

        /// <summary>
        ///     The backup failed. Was a full backup done before?
        /// </summary>
        public const int ERROR_INC_BACKUP = 0x00000FA3; // 4003

        /// <summary>
        ///     The backup failed. Check the directory to which you are backing the database.
        /// </summary>
        public const int ERROR_FULL_BACKUP = 0x00000FA4; // 4004

        /// <summary>
        ///     The name does not exist in the WINS database.
        /// </summary>
        public const int ERROR_REC_NON_EXISTENT = 0x00000FA5; // 4005

        /// <summary>
        ///     Replication with a non-configured partner is not allowed.
        /// </summary>
        public const int ERROR_RPL_NOT_ALLOWED = 0x00000FA6; // 4006

        /// <summary>
        ///     The version of the supplied content information is not supported.
        /// </summary>
        public const int PEERDIST_ERROR_CONTENTINFO_VERSION_UNSUPPORTED = 0x00000FD2; // 4050

        /// <summary>
        ///     The supplied content information is malformed.
        /// </summary>
        public const int PEERDIST_ERROR_CANNOT_PARSE_CONTENTINFO = 0x00000FD3; // 4051

        /// <summary>
        ///     The requested data cannot be found in local or peer caches.
        /// </summary>
        public const int PEERDIST_ERROR_MISSING_DATA = 0x00000FD4; // 4052

        /// <summary>
        ///     No more data is available or required.
        /// </summary>
        public const int PEERDIST_ERROR_NO_MORE = 0x00000FD5; // 4053

        /// <summary>
        ///     The supplied object has not been initialized.
        /// </summary>
        public const int PEERDIST_ERROR_NOT_INITIALIZED = 0x00000FD6; // 4054

        /// <summary>
        ///     The supplied object has already been initialized.
        /// </summary>
        public const int PEERDIST_ERROR_ALREADY_INITIALIZED = 0x00000FD7; // 4055

        /// <summary>
        ///     A shutdown operation is already in progress.
        /// </summary>
        public const int PEERDIST_ERROR_SHUTDOWN_IN_PROGRESS = 0x00000FD8; // 4056

        /// <summary>
        ///     The supplied object has already been invalidated.
        /// </summary>
        public const int PEERDIST_ERROR_INVALIDATED = 0x00000FD9; // 4057

        /// <summary>
        ///     An element already exists and was not replaced.
        /// </summary>
        public const int PEERDIST_ERROR_ALREADY_EXISTS = 0x00000FDA; // 4058

        /// <summary>
        ///     Can not cancel the requested operation as it has already been completed.
        /// </summary>
        public const int PEERDIST_ERROR_OPERATION_NOTFOUND = 0x00000FDB; // 4059

        /// <summary>
        ///     Can not perform the requested operation because it has already been carried out.
        /// </summary>
        public const int PEERDIST_ERROR_ALREADY_COMPLETED = 0x00000FDC; // 4060

        /// <summary>
        ///     An operation accessed data beyond the bounds of valid data.
        /// </summary>
        public const int PEERDIST_ERROR_OUT_OF_BOUNDS = 0x00000FDD; // 4061

        /// <summary>
        ///     The requested version is not supported.
        /// </summary>
        public const int PEERDIST_ERROR_VERSION_UNSUPPORTED = 0x00000FDE; // 4062

        /// <summary>
        ///     A configuration value is invalid.
        /// </summary>
        public const int PEERDIST_ERROR_INVALID_CONFIGURATION = 0x00000FDF; // 4063

        /// <summary>
        ///     The SKU is not licensed.
        /// </summary>
        public const int PEERDIST_ERROR_NOT_LICENSED = 0x00000FE0; // 4064

        /// <summary>
        ///     PeerDist Service is still initializing and will be available shortly.
        /// </summary>
        public const int PEERDIST_ERROR_SERVICE_UNAVAILABLE = 0x00000FE1; // 4065

        /// <summary>
        ///     Communication with one or more computers will be temporarily blocked due to recent errors.
        /// </summary>
        public const int PEERDIST_ERROR_TRUST_FAILURE = 0x00000FE2; // 4066

        /// <summary>
        ///     The DHCP client has obtained an IP address that is already in use on the network. The local interface will be
        ///     disabled until the DHCP client can obtain a new address.
        /// </summary>
        public const int ERROR_DHCP_ADDRESS_CONFLICT = 0x00001004; // 4100

        /// <summary>
        ///     The GUID passed was not recognized as valid by a WMI data provider.
        /// </summary>
        public const int ERROR_WMI_GUID_NOT_FOUND = 0x00001068; // 4200

        /// <summary>
        ///     The instance name passed was not recognized as valid by a WMI data provider.
        /// </summary>
        public const int ERROR_WMI_INSTANCE_NOT_FOUND = 0x00001069; // 4201

        /// <summary>
        ///     The data item ID passed was not recognized as valid by a WMI data provider.
        /// </summary>
        public const int ERROR_WMI_ITEMID_NOT_FOUND = 0x0000106A; // 4202

        /// <summary>
        ///     The WMI request could not be completed and should be retried.
        /// </summary>
        public const int ERROR_WMI_TRY_AGAIN = 0x0000106B; // 4203

        /// <summary>
        ///     The WMI data provider could not be located.
        /// </summary>
        public const int ERROR_WMI_DP_NOT_FOUND = 0x0000106C; // 4204

        /// <summary>
        ///     The WMI data provider references an instance set that has not been registered.
        /// </summary>
        public const int ERROR_WMI_UNRESOLVED_INSTANCE_REF = 0x0000106D; // 4205

        /// <summary>
        ///     The WMI data block or event notification has already been enabled.
        /// </summary>
        public const int ERROR_WMI_ALREADY_ENABLED = 0x0000106E; // 4206

        /// <summary>
        ///     The WMI data block is no longer available.
        /// </summary>
        public const int ERROR_WMI_GUID_DISCONNECTED = 0x0000106F; // 4207

        /// <summary>
        ///     The WMI data service is not available.
        /// </summary>
        public const int ERROR_WMI_SERVER_UNAVAILABLE = 0x00001070; // 4208

        /// <summary>
        ///     The WMI data provider failed to carry out the request.
        /// </summary>
        public const int ERROR_WMI_DP_FAILED = 0x00001071; // 4209

        /// <summary>
        ///     The WMI MOF information is not valid.
        /// </summary>
        public const int ERROR_WMI_INVALID_MOF = 0x00001072; // 4210

        /// <summary>
        ///     The WMI registration information is not valid.
        /// </summary>
        public const int ERROR_WMI_INVALID_REGINFO = 0x00001073; // 4211

        /// <summary>
        ///     The WMI data block or event notification has already been disabled.
        /// </summary>
        public const int ERROR_WMI_ALREADY_DISABLED = 0x00001074; // 4212

        /// <summary>
        ///     The WMI data item or data block is read only.
        /// </summary>
        public const int ERROR_WMI_READ_ONLY = 0x00001075; // 4213

        /// <summary>
        ///     The WMI data item or data block could not be changed.
        /// </summary>
        public const int ERROR_WMI_SET_FAILURE = 0x00001076; // 4214

        /// <summary>
        ///     This operation is only valid in the context of an app container.
        /// </summary>
        public const int ERROR_NOT_APPCONTAINER = 0x0000109A; // 4250

        /// <summary>
        ///     This application can only run in the context of an app container.
        /// </summary>
        public const int ERROR_APPCONTAINER_REQUIRED = 0x0000109B; // 4251

        /// <summary>
        ///     This functionality is not supported in the context of an app container.
        /// </summary>
        public const int ERROR_NOT_SUPPORTED_IN_APPCONTAINER = 0x0000109C; // 4252

        /// <summary>
        ///     The length of the SID supplied is not a valid length for app container SIDs.
        /// </summary>
        public const int ERROR_INVALID_PACKAGE_SID_LENGTH = 0x0000109D; // 4253

        /// <summary>
        ///     The media identifier does not represent a valid medium.
        /// </summary>
        public const int ERROR_INVALID_MEDIA = 0x000010CC; // 4300

        /// <summary>
        ///     The library identifier does not represent a valid library.
        /// </summary>
        public const int ERROR_INVALID_LIBRARY = 0x000010CD; // 4301

        /// <summary>
        ///     The media pool identifier does not represent a valid media pool.
        /// </summary>
        public const int ERROR_INVALID_MEDIA_POOL = 0x000010CE; // 4302

        /// <summary>
        ///     The drive and medium are not compatible or exist in different libraries.
        /// </summary>
        public const int ERROR_DRIVE_MEDIA_MISMATCH = 0x000010CF; // 4303

        /// <summary>
        ///     The medium currently exists in an offline library and must be online to perform this operation.
        /// </summary>
        public const int ERROR_MEDIA_OFFLINE = 0x000010D0; // 4304

        /// <summary>
        ///     The operation cannot be performed on an offline library.
        /// </summary>
        public const int ERROR_LIBRARY_OFFLINE = 0x000010D1; // 4305

        /// <summary>
        ///     The library, drive, or media pool is empty.
        /// </summary>
        public const int ERROR_EMPTY = 0x000010D2; // 4306

        /// <summary>
        ///     The library, drive, or media pool must be empty to perform this operation.
        /// </summary>
        public const int ERROR_NOT_EMPTY = 0x000010D3; // 4307

        /// <summary>
        ///     No media is currently available in this media pool or library.
        /// </summary>
        public const int ERROR_MEDIA_UNAVAILABLE = 0x000010D4; // 4308

        /// <summary>
        ///     A resource required for this operation is disabled.
        /// </summary>
        public const int ERROR_RESOURCE_DISABLED = 0x000010D5; // 4309

        /// <summary>
        ///     The media identifier does not represent a valid cleaner.
        /// </summary>
        public const int ERROR_INVALID_CLEANER = 0x000010D6; // 4310

        /// <summary>
        ///     The drive cannot be cleaned or does not support cleaning.
        /// </summary>
        public const int ERROR_UNABLE_TO_CLEAN = 0x000010D7; // 4311

        /// <summary>
        ///     The object identifier does not represent a valid object.
        /// </summary>
        public const int ERROR_OBJECT_NOT_FOUND = 0x000010D8; // 4312

        /// <summary>
        ///     Unable to read from or write to the database.
        /// </summary>
        public const int ERROR_DATABASE_FAILURE = 0x000010D9; // 4313

        /// <summary>
        ///     The database is full.
        /// </summary>
        public const int ERROR_DATABASE_FULL = 0x000010DA; // 4314

        /// <summary>
        ///     The medium is not compatible with the device or media pool.
        /// </summary>
        public const int ERROR_MEDIA_INCOMPATIBLE = 0x000010DB; // 4315

        /// <summary>
        ///     The resource required for this operation does not exist.
        /// </summary>
        public const int ERROR_RESOURCE_NOT_PRESENT = 0x000010DC; // 4316

        /// <summary>
        ///     The operation identifier is not valid.
        /// </summary>
        public const int ERROR_INVALID_OPERATION = 0x000010DD; // 4317

        /// <summary>
        ///     The media is not mounted or ready for use.
        /// </summary>
        public const int ERROR_MEDIA_NOT_AVAILABLE = 0x000010DE; // 4318

        /// <summary>
        ///     The device is not ready for use.
        /// </summary>
        public const int ERROR_DEVICE_NOT_AVAILABLE = 0x000010DF; // 4319

        /// <summary>
        ///     The operator or administrator has refused the request.
        /// </summary>
        public const int ERROR_REQUEST_REFUSED = 0x000010E0; // 4320

        /// <summary>
        ///     The drive identifier does not represent a valid drive.
        /// </summary>
        public const int ERROR_INVALID_DRIVE_OBJECT = 0x000010E1; // 4321

        /// <summary>
        ///     Library is full. No slot is available for use.
        /// </summary>
        public const int ERROR_LIBRARY_FULL = 0x000010E2; // 4322

        /// <summary>
        ///     The transport cannot access the medium.
        /// </summary>
        public const int ERROR_MEDIUM_NOT_ACCESSIBLE = 0x000010E3; // 4323

        /// <summary>
        ///     Unable to load the medium into the drive.
        /// </summary>
        public const int ERROR_UNABLE_TO_LOAD_MEDIUM = 0x000010E4; // 4324

        /// <summary>
        ///     Unable to retrieve the drive status.
        /// </summary>
        public const int ERROR_UNABLE_TO_INVENTORY_DRIVE = 0x000010E5; // 4325

        /// <summary>
        ///     Unable to retrieve the slot status.
        /// </summary>
        public const int ERROR_UNABLE_TO_INVENTORY_SLOT = 0x000010E6; // 4326

        /// <summary>
        ///     Unable to retrieve status about the transport.
        /// </summary>
        public const int ERROR_UNABLE_TO_INVENTORY_TRANSPORT = 0x000010E7; // 4327

        /// <summary>
        ///     Cannot use the transport because it is already in use.
        /// </summary>
        public const int ERROR_TRANSPORT_FULL = 0x000010E8; // 4328

        /// <summary>
        ///     Unable to open or close the inject/eject port.
        /// </summary>
        public const int ERROR_CONTROLLING_IEPORT = 0x000010E9; // 4329

        /// <summary>
        ///     Unable to eject the medium because it is in a drive.
        /// </summary>
        public const int ERROR_UNABLE_TO_EJECT_MOUNTED_MEDIA = 0x000010EA; // 4330

        /// <summary>
        ///     A cleaner slot is already reserved.
        /// </summary>
        public const int ERROR_CLEANER_SLOT_SET = 0x000010EB; // 4331

        /// <summary>
        ///     A cleaner slot is not reserved.
        /// </summary>
        public const int ERROR_CLEANER_SLOT_NOT_SET = 0x000010EC; // 4332

        /// <summary>
        ///     The cleaner cartridge has performed the maximum number of drive cleanings.
        /// </summary>
        public const int ERROR_CLEANER_CARTRIDGE_SPENT = 0x000010ED; // 4333

        /// <summary>
        ///     Unexpected on-medium identifier.
        /// </summary>
        public const int ERROR_UNEXPECTED_OMID = 0x000010EE; // 4334

        /// <summary>
        ///     The last remaining item in this group or resource cannot be deleted.
        /// </summary>
        public const int ERROR_CANT_DELETE_LAST_ITEM = 0x000010EF; // 4335

        /// <summary>
        ///     The message provided exceeds the maximum size allowed for this parameter.
        /// </summary>
        public const int ERROR_MESSAGE_EXCEEDS_MAX_SIZE = 0x000010F0; // 4336

        /// <summary>
        ///     The volume contains system or paging files.
        /// </summary>
        public const int ERROR_VOLUME_CONTAINS_SYS_FILES = 0x000010F1; // 4337

        /// <summary>
        ///     The media type cannot be removed from this library since at least one drive in the library reports it can support
        ///     this media type.
        /// </summary>
        public const int ERROR_INDIGENOUS_TYPE = 0x000010F2; // 4338

        /// <summary>
        ///     This offline media cannot be mounted on this system since no enabled drives are present which can be used.
        /// </summary>
        public const int ERROR_NO_SUPPORTING_DRIVES = 0x000010F3; // 4339

        /// <summary>
        ///     A cleaner cartridge is present in the tape library.
        /// </summary>
        public const int ERROR_CLEANER_CARTRIDGE_INSTALLED = 0x000010F4; // 4340

        /// <summary>
        ///     Cannot use the inject/eject port because it is not empty.
        /// </summary>
        public const int ERROR_IEPORT_FULL = 0x000010F5; // 4341

        /// <summary>
        ///     This file is currently not available for use on this computer.
        /// </summary>
        public const int ERROR_FILE_OFFLINE = 0x000010FE; // 4350

        /// <summary>
        ///     The remote storage service is not operational at this time.
        /// </summary>
        public const int ERROR_REMOTE_STORAGE_NOT_ACTIVE = 0x000010FF; // 4351

        /// <summary>
        ///     The remote storage service encountered a media error.
        /// </summary>
        public const int ERROR_REMOTE_STORAGE_MEDIA_ERROR = 0x00001100; // 4352

        /// <summary>
        ///     The file or directory is not a re parse point.
        /// </summary>
        public const int ERROR_NOT_A_REPARSE_POINT = 0x00001126; // 4390

        /// <summary>
        ///     The re parse point attribute cannot be set because it conflicts with an existing attribute.
        /// </summary>
        public const int ERROR_REPARSE_ATTRIBUTE_CONFLICT = 0x00001127; // 4391

        /// <summary>
        ///     The data present in the re parse point buffer is invalid.
        /// </summary>
        public const int ERROR_INVALID_REPARSE_DATA = 0x00001128; // 4392

        /// <summary>
        ///     The tag present in the re parse point buffer is invalid.
        /// </summary>
        public const int ERROR_REPARSE_TAG_INVALID = 0x00001129; // 4393

        /// <summary>
        ///     There is a mismatch between the tag specified in the request and the tag present in the re parse point.
        /// </summary>
        public const int ERROR_REPARSE_TAG_MISMATCH = 0x0000112A; // 4394

        /// <summary>
        ///     Fast Cache data not found.
        /// </summary>
        public const int ERROR_APP_DATA_NOT_FOUND = 0x00001130; // 4400

        /// <summary>
        ///     Fast Cache data expired.
        /// </summary>
        public const int ERROR_APP_DATA_EXPIRED = 0x00001131; // 4401

        /// <summary>
        ///     Fast Cache data corrupt.
        /// </summary>
        public const int ERROR_APP_DATA_CORRUPT = 0x00001132; // 4402

        /// <summary>
        ///     Fast Cache data has exceeded its max size and cannot be updated.
        /// </summary>
        public const int ERROR_APP_DATA_LIMIT_EXCEEDED = 0x00001133; // 4403

        /// <summary>
        ///     Fast Cache has been ReArmed and requires a reboot until it can be updated.
        /// </summary>
        public const int ERROR_APP_DATA_REBOOT_REQUIRED = 0x00001134; // 4404

        /// <summary>
        ///     Secure Boot detected that rollback of protected data has been attempted.
        /// </summary>
        public const int ERROR_SECUREBOOT_ROLLBACK_DETECTED = 0x00001144; // 4420

        /// <summary>
        ///     The value is protected by Secure Boot policy and cannot be modified or deleted.
        /// </summary>
        public const int ERROR_SECUREBOOT_POLICY_VIOLATION = 0x00001145; // 4421

        /// <summary>
        ///     The Secure Boot policy is invalid.
        /// </summary>
        public const int ERROR_SECUREBOOT_INVALID_POLICY = 0x00001146; // 4422

        /// <summary>
        ///     A new Secure Boot policy did not contain the current publisher on its update list.
        /// </summary>
        public const int ERROR_SECUREBOOT_POLICY_PUBLISHER_NOT_FOUND = 0x00001147; // 4423

        /// <summary>
        ///     The Secure Boot policy is either not signed or is signed by a non-trusted signer.
        /// </summary>
        public const int ERROR_SECUREBOOT_POLICY_NOT_SIGNED = 0x00001148; // 4424

        /// <summary>
        ///     Secure Boot is not enabled on this machine.
        /// </summary>
        public const int ERROR_SECUREBOOT_NOT_ENABLED = 0x00001149; // 4425

        /// <summary>
        ///     Secure Boot requires that certain files and drivers are not replaced by other files or drivers.
        /// </summary>
        public const int ERROR_SECUREBOOT_FILE_REPLACED = 0x0000114A; // 4426

        /// <summary>
        ///     The copy offload read operation is not supported by a filter.
        /// </summary>
        public const int ERROR_OFFLOAD_READ_FLT_NOT_SUPPORTED = 0x00001158; // 4440

        /// <summary>
        ///     The copy offload write operation is not supported by a filter.
        /// </summary>
        public const int ERROR_OFFLOAD_WRITE_FLT_NOT_SUPPORTED = 0x00001159; // 4441

        /// <summary>
        ///     The copy offload read operation is not supported for the file.
        /// </summary>
        public const int ERROR_OFFLOAD_READ_FILE_NOT_SUPPORTED = 0x0000115A; // 4442

        /// <summary>
        ///     The copy offload write operation is not supported for the file.
        /// </summary>
        public const int ERROR_OFFLOAD_WRITE_FILE_NOT_SUPPORTED = 0x0000115B; // 4443

        /// <summary>
        ///     Single Instance Storage is not available on this volume.
        /// </summary>
        public const int ERROR_VOLUME_NOT_SIS_ENABLED = 0x00001194; // 4500

        /// <summary>
        ///     The operation cannot be completed because other resources are dependent on this resource.
        /// </summary>
        public const int ERROR_DEPENDENT_RESOURCE_EXISTS = 0x00001389; // 5001

        /// <summary>
        ///     The cluster resource dependency cannot be found.
        /// </summary>
        public const int ERROR_DEPENDENCY_NOT_FOUND = 0x0000138A; // 5002

        /// <summary>
        ///     The cluster resource cannot be made dependent on the specified resource because it is already dependent.
        /// </summary>
        public const int ERROR_DEPENDENCY_ALREADY_EXISTS = 0x0000138B; // 5003

        /// <summary>
        ///     The cluster resource is not online.
        /// </summary>
        public const int ERROR_RESOURCE_NOT_ONLINE = 0x0000138C; // 5004

        /// <summary>
        ///     A cluster node is not available for this operation.
        /// </summary>
        public const int ERROR_HOST_NODE_NOT_AVAILABLE = 0x0000138D; // 5005

        /// <summary>
        ///     The cluster resource is not available.
        /// </summary>
        public const int ERROR_RESOURCE_NOT_AVAILABLE = 0x0000138E; // 5006

        /// <summary>
        ///     The cluster resource could not be found.
        /// </summary>
        public const int ERROR_RESOURCE_NOT_FOUND = 0x0000138F; // 5007

        /// <summary>
        ///     The cluster is being shut down.
        /// </summary>
        public const int ERROR_SHUTDOWN_CLUSTER = 0x00001390; // 5008

        /// <summary>
        ///     A cluster node cannot be evicted from the cluster unless the node is down or it is the last node.
        /// </summary>
        public const int ERROR_CANT_EVICT_ACTIVE_NODE = 0x00001391; // 5009

        /// <summary>
        ///     The object already exists.
        /// </summary>
        public const int ERROR_OBJECT_ALREADY_EXISTS = 0x00001392; // 5010

        /// <summary>
        ///     The object is already in the list.
        /// </summary>
        public const int ERROR_OBJECT_IN_LIST = 0x00001393; // 5011

        /// <summary>
        ///     The cluster group is not available for any new requests.
        /// </summary>
        public const int ERROR_GROUP_NOT_AVAILABLE = 0x00001394; // 5012

        /// <summary>
        ///     The cluster group could not be found.
        /// </summary>
        public const int ERROR_GROUP_NOT_FOUND = 0x00001395; // 5013

        /// <summary>
        ///     The operation could not be completed because the cluster group is not online.
        /// </summary>
        public const int ERROR_GROUP_NOT_ONLINE = 0x00001396; // 5014

        /// <summary>
        ///     The operation failed because either the specified cluster node is not the owner of the resource, or the node is not
        ///     a possible owner of the resource.
        /// </summary>
        public const int ERROR_HOST_NODE_NOT_RESOURCE_OWNER = 0x00001397; // 5015

        /// <summary>
        ///     The operation failed because either the specified cluster node is not the owner of the group, or the node is not a
        ///     possible owner of the group.
        /// </summary>
        public const int ERROR_HOST_NODE_NOT_GROUP_OWNER = 0x00001398; // 5016

        /// <summary>
        ///     The cluster resource could not be created in the specified resource monitor.
        /// </summary>
        public const int ERROR_RESMON_CREATE_FAILED = 0x00001399; // 5017

        /// <summary>
        ///     The cluster resource could not be brought online by the resource monitor.
        /// </summary>
        public const int ERROR_RESMON_ONLINE_FAILED = 0x0000139A; // 5018

        /// <summary>
        ///     The operation could not be completed because the cluster resource is online.
        /// </summary>
        public const int ERROR_RESOURCE_ONLINE = 0x0000139B; // 5019

        /// <summary>
        ///     The cluster resource could not be deleted or brought offline because it is the quorum resource.
        /// </summary>
        public const int ERROR_QUORUM_RESOURCE = 0x0000139C; // 5020

        /// <summary>
        ///     The cluster could not make the specified resource a quorum resource because it is not capable of being a quorum
        ///     resource.
        /// </summary>
        public const int ERROR_NOT_QUORUM_CAPABLE = 0x0000139D; // 5021

        /// <summary>
        ///     The cluster software is shutting down.
        /// </summary>
        public const int ERROR_CLUSTER_SHUTTING_DOWN = 0x0000139E; // 5022

        /// <summary>
        ///     The group or resource is not in the correct state to perform the requested operation.
        /// </summary>
        public const int ERROR_INVALID_STATE = 0x0000139F; // 5023

        /// <summary>
        ///     The properties were stored but not all changes will take effect until the next time the resource is brought online.
        /// </summary>
        public const int ERROR_RESOURCE_PROPERTIES_STORED = 0x000013A0; // 5024

        /// <summary>
        ///     The cluster could not make the specified resource a quorum resource because it does not belong to a shared storage
        ///     class.
        /// </summary>
        public const int ERROR_NOT_QUORUM_CLASS = 0x000013A1; // 5025

        /// <summary>
        ///     The cluster resource could not be deleted since it is a core resource.
        /// </summary>
        public const int ERROR_CORE_RESOURCE = 0x000013A2; // 5026

        /// <summary>
        ///     The quorum resource failed to come online.
        /// </summary>
        public const int ERROR_QUORUM_RESOURCE_ONLINE_FAILED = 0x000013A3; // 5027

        /// <summary>
        ///     The quorum log could not be created or mounted successfully.
        /// </summary>
        public const int ERROR_QUORUMLOG_OPEN_FAILED = 0x000013A4; // 5028

        /// <summary>
        ///     The cluster log is corrupt.
        /// </summary>
        public const int ERROR_CLUSTERLOG_CORRUPT = 0x000013A5; // 5029

        /// <summary>
        ///     The record could not be written to the cluster log since it exceeds the maximum size.
        /// </summary>
        public const int ERROR_CLUSTERLOG_RECORD_EXCEEDS_MAXSIZE = 0x000013A6; // 5030

        /// <summary>
        ///     The cluster log exceeds its maximum size.
        /// </summary>
        public const int ERROR_CLUSTERLOG_EXCEEDS_MAXSIZE = 0x000013A7; // 5031

        /// <summary>
        ///     No checkpoint record was found in the cluster log.
        /// </summary>
        public const int ERROR_CLUSTERLOG_CHKPOINT_NOT_FOUND = 0x000013A8; // 5032

        /// <summary>
        ///     The minimum required disk space needed for logging is not available.
        /// </summary>
        public const int ERROR_CLUSTERLOG_NOT_ENOUGH_SPACE = 0x000013A9; // 5033

        /// <summary>
        ///     The cluster node failed to take control of the quorum resource because the resource is owned by another active
        ///     node.
        /// </summary>
        public const int ERROR_QUORUM_OWNER_ALIVE = 0x000013AA; // 5034

        /// <summary>
        ///     A cluster network is not available for this operation.
        /// </summary>
        public const int ERROR_NETWORK_NOT_AVAILABLE = 0x000013AB; // 5035

        /// <summary>
        ///     A cluster node is not available for this operation.
        /// </summary>
        public const int ERROR_NODE_NOT_AVAILABLE = 0x000013AC; // 5036

        /// <summary>
        ///     All cluster nodes must be running to perform this operation.
        /// </summary>
        public const int ERROR_ALL_NODES_NOT_AVAILABLE = 0x000013AD; // 5037

        /// <summary>
        ///     A cluster resource failed.
        /// </summary>
        public const int ERROR_RESOURCE_FAILED = 0x000013AE; // 5038

        /// <summary>
        ///     The cluster node is not valid.
        /// </summary>
        public const int ERROR_CLUSTER_INVALID_NODE = 0x000013AF; // 5039

        /// <summary>
        ///     The cluster node already exists.
        /// </summary>
        public const int ERROR_CLUSTER_NODE_EXISTS = 0x000013B0; // 5040

        /// <summary>
        ///     A node is in the process of joining the cluster.
        /// </summary>
        public const int ERROR_CLUSTER_JOIN_IN_PROGRESS = 0x000013B1; // 5041

        /// <summary>
        ///     The cluster node was not found.
        /// </summary>
        public const int ERROR_CLUSTER_NODE_NOT_FOUND = 0x000013B2; // 5042

        /// <summary>
        ///     The cluster local node information was not found.
        /// </summary>
        public const int ERROR_CLUSTER_LOCAL_NODE_NOT_FOUND = 0x000013B3; // 5043

        /// <summary>
        ///     The cluster network already exists.
        /// </summary>
        public const int ERROR_CLUSTER_NETWORK_EXISTS = 0x000013B4; // 5044

        /// <summary>
        ///     The cluster network was not found.
        /// </summary>
        public const int ERROR_CLUSTER_NETWORK_NOT_FOUND = 0x000013B5; // 5045

        /// <summary>
        ///     The cluster network interface already exists.
        /// </summary>
        public const int ERROR_CLUSTER_NETINTERFACE_EXISTS = 0x000013B6; // 5046

        /// <summary>
        ///     The cluster network interface was not found.
        /// </summary>
        public const int ERROR_CLUSTER_NETINTERFACE_NOT_FOUND = 0x000013B7; // 5047

        /// <summary>
        ///     The cluster request is not valid for this object.
        /// </summary>
        public const int ERROR_CLUSTER_INVALID_REQUEST = 0x000013B8; // 5048

        /// <summary>
        ///     The cluster network provider is not valid.
        /// </summary>
        public const int ERROR_CLUSTER_INVALID_NETWORK_PROVIDER = 0x000013B9; // 5049

        /// <summary>
        ///     The cluster node is down.
        /// </summary>
        public const int ERROR_CLUSTER_NODE_DOWN = 0x000013BA; // 5050

        /// <summary>
        ///     The cluster node is not reachable.
        /// </summary>
        public const int ERROR_CLUSTER_NODE_UNREACHABLE = 0x000013BB; // 5051

        /// <summary>
        ///     The cluster node is not a member of the cluster.
        /// </summary>
        public const int ERROR_CLUSTER_NODE_NOT_MEMBER = 0x000013BC; // 5052

        /// <summary>
        ///     A cluster join operation is not in progress.
        /// </summary>
        public const int ERROR_CLUSTER_JOIN_NOT_IN_PROGRESS = 0x000013BD; // 5053

        /// <summary>
        ///     The cluster network is not valid.
        /// </summary>
        public const int ERROR_CLUSTER_INVALID_NETWORK = 0x000013BE; // 5054

        /// <summary>
        ///     The cluster node is up.
        /// </summary>
        public const int ERROR_CLUSTER_NODE_UP = 0x000013C0; // 5056

        /// <summary>
        ///     The cluster IP address is already in use.
        /// </summary>
        public const int ERROR_CLUSTER_IPADDR_IN_USE = 0x000013C1; // 5057

        /// <summary>
        ///     The cluster node is not paused.
        /// </summary>
        public const int ERROR_CLUSTER_NODE_NOT_PAUSED = 0x000013C2; // 5058

        /// <summary>
        ///     No cluster security context is available.
        /// </summary>
        public const int ERROR_CLUSTER_NO_SECURITY_CONTEXT = 0x000013C3; // 5059

        /// <summary>
        ///     The cluster network is not configured for internal cluster communication.
        /// </summary>
        public const int ERROR_CLUSTER_NETWORK_NOT_INTERNAL = 0x000013C4; // 5060

        /// <summary>
        ///     The cluster node is already up.
        /// </summary>
        public const int ERROR_CLUSTER_NODE_ALREADY_UP = 0x000013C5; // 5061

        /// <summary>
        ///     The cluster node is already down.
        /// </summary>
        public const int ERROR_CLUSTER_NODE_ALREADY_DOWN = 0x000013C6; // 5062

        /// <summary>
        ///     The cluster network is already online.
        /// </summary>
        public const int ERROR_CLUSTER_NETWORK_ALREADY_ONLINE = 0x000013C7; // 5063

        /// <summary>
        ///     The cluster network is already offline.
        /// </summary>
        public const int ERROR_CLUSTER_NETWORK_ALREADY_OFFLINE = 0x000013C8; // 5064

        /// <summary>
        ///     The cluster node is already a member of the cluster.
        /// </summary>
        public const int ERROR_CLUSTER_NODE_ALREADY_MEMBER = 0x000013C9; // 5065

        /// <summary>
        ///     The cluster network is the only one configured for internal cluster communication between two or more active
        ///     cluster nodes. The internal communication capability cannot be removed from the network.
        /// </summary>
        public const int ERROR_CLUSTER_LAST_INTERNAL_NETWORK = 0x000013CA; // 5066

        /// <summary>
        ///     One or more cluster resources depend on the network to provide service to clients. The client access capability
        ///     cannot be removed from the network.
        /// </summary>
        public const int ERROR_CLUSTER_NETWORK_HAS_DEPENDENTS = 0x000013CB; // 5067

        /// <summary>
        ///     This operation cannot be performed on the cluster resource as it the quorum resource. You may not bring the quorum
        ///     resource offline or modify its possible owners list.
        /// </summary>
        public const int ERROR_INVALID_OPERATION_ON_QUORUM = 0x000013CC; // 5068

        /// <summary>
        ///     The cluster quorum resource is not allowed to have any dependencies.
        /// </summary>
        public const int ERROR_DEPENDENCY_NOT_ALLOWED = 0x000013CD; // 5069

        /// <summary>
        ///     The cluster node is paused.
        /// </summary>
        public const int ERROR_CLUSTER_NODE_PAUSED = 0x000013CE; // 5070

        /// <summary>
        ///     The cluster resource cannot be brought online. The owner node cannot run this resource.
        /// </summary>
        public const int ERROR_NODE_CANT_HOST_RESOURCE = 0x000013CF; // 5071

        /// <summary>
        ///     The cluster node is not ready to perform the requested operation.
        /// </summary>
        public const int ERROR_CLUSTER_NODE_NOT_READY = 0x000013D0; // 5072

        /// <summary>
        ///     The cluster node is shutting down.
        /// </summary>
        public const int ERROR_CLUSTER_NODE_SHUTTING_DOWN = 0x000013D1; // 5073

        /// <summary>
        ///     The cluster join operation was aborted.
        /// </summary>
        public const int ERROR_CLUSTER_JOIN_ABORTED = 0x000013D2; // 5074

        /// <summary>
        ///     The cluster join operation failed due to incompatible software versions between the joining node and its sponsor.
        /// </summary>
        public const int ERROR_CLUSTER_INCOMPATIBLE_VERSIONS = 0x000013D3; // 5075

        /// <summary>
        ///     This resource cannot be created because the cluster has reached the limit on the number of resources it can
        ///     monitor.
        /// </summary>
        public const int ERROR_CLUSTER_MAXNUM_OF_RESOURCES_EXCEEDED = 0x000013D4; // 5076

        /// <summary>
        ///     The system configuration changed during the cluster join or form operation. The join or form operation was aborted.
        /// </summary>
        public const int ERROR_CLUSTER_SYSTEM_CONFIG_CHANGED = 0x000013D5; // 5077

        /// <summary>
        ///     The specified resource type was not found.
        /// </summary>
        public const int ERROR_CLUSTER_RESOURCE_TYPE_NOT_FOUND = 0x000013D6; // 5078

        /// <summary>
        ///     The specified node does not support a resource of this type. This may be due to version inconsistencies or due to
        ///     the absence of the resource DLL on this node.
        /// </summary>
        public const int ERROR_CLUSTER_RESTYPE_NOT_SUPPORTED = 0x000013D7; // 5079

        /// <summary>
        ///     The specified resource name is not supported by this resource DLL. This may be due to a bad (or changed) name
        ///     supplied to the resource DLL.
        /// </summary>
        public const int ERROR_CLUSTER_RESNAME_NOT_FOUND = 0x000013D8; // 5080

        /// <summary>
        ///     No authentication package could be registered with the RPC server.
        /// </summary>
        public const int ERROR_CLUSTER_NO_RPC_PACKAGES_REGISTERED = 0x000013D9; // 5081

        /// <summary>
        ///     You cannot bring the group online because the owner of the group is not in the preferred list for the group. To
        ///     change the owner node for the group, move the group.
        /// </summary>
        public const int ERROR_CLUSTER_OWNER_NOT_IN_PREFLIST = 0x000013DA; // 5082

        /// <summary>
        ///     The join operation failed because the cluster database sequence number has changed or is incompatible with the
        ///     locker node. This may happen during a join operation if the cluster database was changing during the join.
        /// </summary>
        public const int ERROR_CLUSTER_DATABASE_SEQMISMATCH = 0x000013DB; // 5083

        /// <summary>
        ///     The resource monitor will not allow the fail operation to be performed while the resource is in its current state.
        ///     This may happen if the resource is in a pending state.
        /// </summary>
        public const int ERROR_RESMON_INVALID_STATE = 0x000013DC; // 5084

        /// <summary>
        ///     A non locker code got a request to reserve the lock for making global updates.
        /// </summary>
        public const int ERROR_CLUSTER_GUM_NOT_LOCKER = 0x000013DD; // 5085

        /// <summary>
        ///     The quorum disk could not be located by the cluster service.
        /// </summary>
        public const int ERROR_QUORUM_DISK_NOT_FOUND = 0x000013DE; // 5086

        /// <summary>
        ///     The backed up cluster database is possibly corrupt.
        /// </summary>
        public const int ERROR_DATABASE_BACKUP_CORRUPT = 0x000013DF; // 5087

        /// <summary>
        ///     A DFS root already exists in this cluster node.
        /// </summary>
        public const int ERROR_CLUSTER_NODE_ALREADY_HAS_DFS_ROOT = 0x000013E0; // 5088

        /// <summary>
        ///     An attempt to modify a resource property failed because it conflicts with another existing property.
        /// </summary>
        public const int ERROR_RESOURCE_PROPERTY_UNCHANGEABLE = 0x000013E1; // 5089

        /// <summary>
        ///     An operation was attempted that is incompatible with the current membership state of the node.
        /// </summary>
        public const int ERROR_CLUSTER_MEMBERSHIP_INVALID_STATE = 0x00001702; // 5890

        /// <summary>
        ///     The quorum resource does not contain the quorum log.
        /// </summary>
        public const int ERROR_CLUSTER_QUORUMLOG_NOT_FOUND = 0x00001703; // 5891

        /// <summary>
        ///     The membership engine requested shutdown of the cluster service on this node.
        /// </summary>
        public const int ERROR_CLUSTER_MEMBERSHIP_HALT = 0x00001704; // 5892

        /// <summary>
        ///     The join operation failed because the cluster instance ID of the joining node does not match the cluster instance
        ///     ID of the sponsor node.
        /// </summary>
        public const int ERROR_CLUSTER_INSTANCE_ID_MISMATCH = 0x00001705; // 5893

        /// <summary>
        ///     A matching cluster network for the specified IP address could not be found.
        /// </summary>
        public const int ERROR_CLUSTER_NETWORK_NOT_FOUND_FOR_IP = 0x00001706; // 5894

        /// <summary>
        ///     The actual data type of the property did not match the expected data type of the property.
        /// </summary>
        public const int ERROR_CLUSTER_PROPERTY_DATA_TYPE_MISMATCH = 0x00001707; // 5895

        /// <summary>
        ///     The cluster node was evicted from the cluster successfully, but the node was not cleaned up. To determine what
        ///     cleanup steps failed and how to recover, see the Failover Clustering application event log using Event Viewer.
        /// </summary>
        public const int ERROR_CLUSTER_EVICT_WITHOUT_CLEANUP = 0x00001708; // 5896

        /// <summary>
        ///     Two or more parameter values specified for a resource's properties are in conflict.
        /// </summary>
        public const int ERROR_CLUSTER_PARAMETER_MISMATCH = 0x00001709; // 5897

        /// <summary>
        ///     This computer cannot be made a member of a cluster.
        /// </summary>
        public const int ERROR_NODE_CANNOT_BE_CLUSTERED = 0x0000170A; // 5898

        /// <summary>
        ///     This computer cannot be made a member of a cluster because it does not have the correct version of Windows
        ///     installed.
        /// </summary>
        public const int ERROR_CLUSTER_WRONG_OS_VERSION = 0x0000170B; // 5899

        /// <summary>
        ///     A cluster cannot be created with the specified cluster name because that cluster name is already in use. Specify a
        ///     different name for the cluster.
        /// </summary>
        public const int ERROR_CLUSTER_CANT_CREATE_DUP_CLUSTER_NAME = 0x0000170C; // 5900

        /// <summary>
        ///     The cluster configuration action has already been committed.
        /// </summary>
        public const int ERROR_CLUSCFG_ALREADY_COMMITTED = 0x0000170D; // 5901

        /// <summary>
        ///     The cluster configuration action could not be rolled back.
        /// </summary>
        public const int ERROR_CLUSCFG_ROLLBACK_FAILED = 0x0000170E; // 5902

        /// <summary>
        ///     The drive letter assigned to a system disk on one node conflicted with the drive letter assigned to a disk on
        ///     another node.
        /// </summary>
        public const int ERROR_CLUSCFG_SYSTEM_DISK_DRIVE_LETTER_CONFLICT = 0x0000170F; // 5903

        /// <summary>
        ///     One or more nodes in the cluster are running a version of Windows that does not support this operation.
        /// </summary>
        public const int ERROR_CLUSTER_OLD_VERSION = 0x00001710; // 5904

        /// <summary>
        ///     The name of the corresponding computer account doesn't match the Network Name for this resource.
        /// </summary>
        public const int ERROR_CLUSTER_MISMATCHED_COMPUTER_ACCT_NAME = 0x00001711; // 5905

        /// <summary>
        ///     No network adapters are available.
        /// </summary>
        public const int ERROR_CLUSTER_NO_NET_ADAPTERS = 0x00001712; // 5906

        /// <summary>
        ///     The cluster node has been poisoned.
        /// </summary>
        public const int ERROR_CLUSTER_POISONED = 0x00001713; // 5907

        /// <summary>
        ///     The group is unable to accept the request since it is moving to another node.
        /// </summary>
        public const int ERROR_CLUSTER_GROUP_MOVING = 0x00001714; // 5908

        /// <summary>
        ///     The resource type cannot accept the request since is too busy performing another operation.
        /// </summary>
        public const int ERROR_CLUSTER_RESOURCE_TYPE_BUSY = 0x00001715; // 5909

        /// <summary>
        ///     The call to the cluster resource DLL timed out.
        /// </summary>
        public const int ERROR_RESOURCE_CALL_TIMED_OUT = 0x00001716; // 5910

        /// <summary>
        ///     The address is not valid for an IPv6 Address resource. A global IPv6 address is required, and it must match a
        ///     cluster network. Compatibility addresses are not permitted.
        /// </summary>
        public const int ERROR_INVALID_CLUSTER_IPV6_ADDRESS = 0x00001717; // 5911

        /// <summary>
        ///     An internal cluster error occurred. A call to an invalid function was attempted.
        /// </summary>
        public const int ERROR_CLUSTER_INTERNAL_INVALID_FUNCTION = 0x00001718; // 5912

        /// <summary>
        ///     A parameter value is out of acceptable range.
        /// </summary>
        public const int ERROR_CLUSTER_PARAMETER_OUT_OF_BOUNDS = 0x00001719; // 5913

        /// <summary>
        ///     A network error occurred while sending data to another node in the cluster. The number of bytes transmitted was
        ///     less than required.
        /// </summary>
        public const int ERROR_CLUSTER_PARTIAL_SEND = 0x0000171A; // 5914

        /// <summary>
        ///     An invalid cluster registry operation was attempted.
        /// </summary>
        public const int ERROR_CLUSTER_REGISTRY_INVALID_FUNCTION = 0x0000171B; // 5915

        /// <summary>
        ///     An input string of characters is not properly terminated.
        /// </summary>
        public const int ERROR_CLUSTER_INVALID_STRING_TERMINATION = 0x0000171C; // 5916

        /// <summary>
        ///     An input string of characters is not in a valid format for the data it represents.
        /// </summary>
        public const int ERROR_CLUSTER_INVALID_STRING_FORMAT = 0x0000171D; // 5917

        /// <summary>
        ///     An internal cluster error occurred. A cluster database transaction was attempted while a transaction was already in
        ///     progress.
        /// </summary>
        public const int ERROR_CLUSTER_DATABASE_TRANSACTION_IN_PROGRESS = 0x0000171E; // 5918

        /// <summary>
        ///     An internal cluster error occurred. There was an attempt to commit a cluster database transaction while no
        ///     transaction was in progress.
        /// </summary>
        public const int ERROR_CLUSTER_DATABASE_TRANSACTION_NOT_IN_PROGRESS = 0x0000171F; // 5919

        /// <summary>
        ///     An internal cluster error occurred. Data was not properly initialized.
        /// </summary>
        public const int ERROR_CLUSTER_NULL_DATA = 0x00001720; // 5920

        /// <summary>
        ///     An error occurred while reading from a stream of data. An unexpected number of bytes was returned.
        /// </summary>
        public const int ERROR_CLUSTER_PARTIAL_READ = 0x00001721; // 5921

        /// <summary>
        ///     An error occurred while writing to a stream of data. The required number of bytes could not be written.
        /// </summary>
        public const int ERROR_CLUSTER_PARTIAL_WRITE = 0x00001722; // 5922

        /// <summary>
        ///     An error occurred while deserializing a stream of cluster data.
        /// </summary>
        public const int ERROR_CLUSTER_CANT_DESERIALIZE_DATA = 0x00001723; // 5923

        /// <summary>
        ///     One or more property values for this resource are in conflict with one or more property values associated with its
        ///     dependent resource(s).
        /// </summary>
        public const int ERROR_DEPENDENT_RESOURCE_PROPERTY_CONFLICT = 0x00001724; // 5924

        /// <summary>
        ///     A quorum of cluster nodes was not present to form a cluster.
        /// </summary>
        public const int ERROR_CLUSTER_NO_QUORUM = 0x00001725; // 5925

        /// <summary>
        ///     The cluster network is not valid for an IPv6 Address resource, or it does not match the configured address.
        /// </summary>
        public const int ERROR_CLUSTER_INVALID_IPV6_NETWORK = 0x00001726; // 5926

        /// <summary>
        ///     The cluster network is not valid for an IPv6 Tunnel resource. Check the configuration of the IP Address resource on
        ///     which the IPv6 Tunnel resource depends.
        /// </summary>
        public const int ERROR_CLUSTER_INVALID_IPV6_TUNNEL_NETWORK = 0x00001727; // 5927

        /// <summary>
        ///     Quorum resource cannot reside in the Available Storage group.
        /// </summary>
        public const int ERROR_QUORUM_NOT_ALLOWED_IN_THIS_GROUP = 0x00001728; // 5928

        /// <summary>
        ///     The dependencies for this resource are nested too deeply.
        /// </summary>
        public const int ERROR_DEPENDENCY_TREE_TOO_COMPLEX = 0x00001729; // 5929

        /// <summary>
        ///     The call into the resource DLL raised an unhandled exception.
        /// </summary>
        public const int ERROR_EXCEPTION_IN_RESOURCE_CALL = 0x0000172A; // 5930

        /// <summary>
        ///     The RHS process failed to initialize.
        /// </summary>
        public const int ERROR_CLUSTER_RHS_FAILED_INITIALIZATION = 0x0000172B; // 5931

        /// <summary>
        ///     The Failover Clustering feature is not installed on this node.
        /// </summary>
        public const int ERROR_CLUSTER_NOT_INSTALLED = 0x0000172C; // 5932

        /// <summary>
        ///     The resources must be online on the same node for this operation.
        /// </summary>
        public const int ERROR_CLUSTER_RESOURCES_MUST_BE_ONLINE_ON_THE_SAME_NODE = 0x0000172D; // 5933

        /// <summary>
        ///     A new node can not be added since this cluster is already at its maximum number of nodes.
        /// </summary>
        public const int ERROR_CLUSTER_MAX_NODES_IN_CLUSTER = 0x0000172E; // 5934

        /// <summary>
        ///     This cluster can not be created since the specified number of nodes exceeds the maximum allowed limit.
        /// </summary>
        public const int ERROR_CLUSTER_TOO_MANY_NODES = 0x0000172F; // 5935

        /// <summary>
        ///     An attempt to use the specified cluster name failed because an enabled computer object with the given name already
        ///     exists in the domain.
        /// </summary>
        public const int ERROR_CLUSTER_OBJECT_ALREADY_USED = 0x00001730; // 5936

        /// <summary>
        ///     This cluster cannot be destroyed. It has non-core application groups which must be deleted before the cluster can
        ///     be destroyed.
        /// </summary>
        public const int ERROR_NONCORE_GROUPS_FOUND = 0x00001731; // 5937

        /// <summary>
        ///     File share associated with file share witness resource cannot be hosted by this cluster or any of its nodes.
        /// </summary>
        public const int ERROR_FILE_SHARE_RESOURCE_CONFLICT = 0x00001732; // 5938

        /// <summary>
        ///     Eviction of this node is invalid at this time. Due to quorum requirements node eviction will result in cluster
        ///     shutdown. If it is the last node in the cluster, destroy cluster command should be used.
        /// </summary>
        public const int ERROR_CLUSTER_EVICT_INVALID_REQUEST = 0x00001733; // 5939

        /// <summary>
        ///     Only one instance of this resource type is allowed in the cluster.
        /// </summary>
        public const int ERROR_CLUSTER_SINGLETON_RESOURCE = 0x00001734; // 5940

        /// <summary>
        ///     Only one instance of this resource type is allowed per resource group.
        /// </summary>
        public const int ERROR_CLUSTER_GROUP_SINGLETON_RESOURCE = 0x00001735; // 5941

        /// <summary>
        ///     The resource failed to come online due to the failure of one or more provider resources.
        /// </summary>
        public const int ERROR_CLUSTER_RESOURCE_PROVIDER_FAILED = 0x00001736; // 5942

        /// <summary>
        ///     The resource has indicated that it cannot come online on any node.
        /// </summary>
        public const int ERROR_CLUSTER_RESOURCE_CONFIGURATION_ERROR = 0x00001737; // 5943

        /// <summary>
        ///     The current operation cannot be performed on this group at this time.
        /// </summary>
        public const int ERROR_CLUSTER_GROUP_BUSY = 0x00001738; // 5944

        /// <summary>
        ///     The directory or file is not located on a cluster shared volume.
        /// </summary>
        public const int ERROR_CLUSTER_NOT_SHARED_VOLUME = 0x00001739; // 5945

        /// <summary>
        ///     The Security Descriptor does not meet the requirements for a cluster.
        /// </summary>
        public const int ERROR_CLUSTER_INVALID_SECURITY_DESCRIPTOR = 0x0000173A; // 5946

        /// <summary>
        ///     There is one or more shared volumes resources configured in the cluster. Those resources must be moved to available
        ///     storage in order for operation to succeed.
        /// </summary>
        public const int ERROR_CLUSTER_SHARED_VOLUMES_IN_USE = 0x0000173B; // 5947

        /// <summary>
        ///     This group or resource cannot be directly manipulated. Use shared volume APIs to perform desired operation.
        /// </summary>
        public const int ERROR_CLUSTER_USE_SHARED_VOLUMES_API = 0x0000173C; // 5948

        /// <summary>
        ///     Back up is in progress. Please wait for backup completion before trying this operation again.
        /// </summary>
        public const int ERROR_CLUSTER_BACKUP_IN_PROGRESS = 0x0000173D; // 5949

        /// <summary>
        ///     The path does not belong to a cluster shared volume.
        /// </summary>
        public const int ERROR_NON_CSV_PATH = 0x0000173E; // 5950

        /// <summary>
        ///     The cluster shared volume is not locally mounted on this node.
        /// </summary>
        public const int ERROR_CSV_VOLUME_NOT_LOCAL = 0x0000173F; // 5951

        /// <summary>
        ///     The cluster watchdog is terminating.
        /// </summary>
        public const int ERROR_CLUSTER_WATCHDOG_TERMINATING = 0x00001740; // 5952

        /// <summary>
        ///     A resource vetoed a move between two nodes because they are incompatible.
        /// </summary>
        public const int ERROR_CLUSTER_RESOURCE_VETOED_MOVE_INCOMPATIBLE_NODES = 0x00001741; // 5953

        /// <summary>
        ///     The request is invalid either because node weight cannot be changed while the cluster is in disk-only quorum mode,
        ///     or because changing the node weight would violate the minimum cluster quorum requirements.
        /// </summary>
        public const int ERROR_CLUSTER_INVALID_NODE_WEIGHT = 0x00001742; // 5954

        /// <summary>
        ///     The resource vetoed the call.
        /// </summary>
        public const int ERROR_CLUSTER_RESOURCE_VETOED_CALL = 0x00001743; // 5955

        /// <summary>
        ///     Resource could not start or run because it could not reserve sufficient system resources.
        /// </summary>
        public const int ERROR_RESMON_SYSTEM_RESOURCES_LACKING = 0x00001744; // 5956

        /// <summary>
        ///     A resource vetoed a move between two nodes because the destination currently does not have enough resources to
        ///     complete the operation.
        /// </summary>
        public const int ERROR_CLUSTER_RESOURCE_VETOED_MOVE_NOT_ENOUGH_RESOURCES_ON_DESTINATION = 0x00001745; // 5957

        /// <summary>
        ///     A resource vetoed a move between two nodes because the source currently does not have enough resources to complete
        ///     the operation.
        /// </summary>
        public const int ERROR_CLUSTER_RESOURCE_VETOED_MOVE_NOT_ENOUGH_RESOURCES_ON_SOURCE = 0x00001746; // 5958

        /// <summary>
        ///     The requested operation can not be completed because the group is queued for an operation.
        /// </summary>
        public const int ERROR_CLUSTER_GROUP_QUEUED = 0x00001747; // 5959

        /// <summary>
        ///     The requested operation can not be completed because a resource has locked status.
        /// </summary>
        public const int ERROR_CLUSTER_RESOURCE_LOCKED_STATUS = 0x00001748; // 5960

        /// <summary>
        ///     The resource cannot move to another node because a cluster shared volume vetoed the operation.
        /// </summary>
        public const int ERROR_CLUSTER_SHARED_VOLUME_FAILOVER_NOT_ALLOWED = 0x00001749; // 5961

        /// <summary>
        ///     A node drain is already in progress.
        /// </summary>
        public const int ERROR_CLUSTER_NODE_DRAIN_IN_PROGRESS = 0x0000174A; // 5962

        /// <summary>
        ///     Clustered storage is not connected to the node.
        /// </summary>
        public const int ERROR_CLUSTER_DISK_NOT_CONNECTED = 0x0000174B; // 5963

        /// <summary>
        ///     The disk is not configured in a way to be used with CSV. CSV disks must have at least one partition that is
        ///     formatted with NTFS.
        /// </summary>
        public const int ERROR_DISK_NOT_CSV_CAPABLE = 0x0000174C; // 5964

        /// <summary>
        ///     The resource must be part of the Available Storage group to complete this action.
        /// </summary>
        public const int ERROR_RESOURCE_NOT_IN_AVAILABLE_STORAGE = 0x0000174D; // 5965

        /// <summary>
        ///     CSVFS failed operation as volume is in redirected mode.
        /// </summary>
        public const int ERROR_CLUSTER_SHARED_VOLUME_REDIRECTED = 0x0000174E; // 5966

        /// <summary>
        ///     CSVFS failed operation as volume is not in redirected mode.
        /// </summary>
        public const int ERROR_CLUSTER_SHARED_VOLUME_NOT_REDIRECTED = 0x0000174F; // 5967

        /// <summary>
        ///     Cluster properties cannot be returned at this time.
        /// </summary>
        public const int ERROR_CLUSTER_CANNOT_RETURN_PROPERTIES = 0x00001750; // 5968

        /// <summary>
        ///     The clustered disk resource contains software snapshot diff area that are not supported for Cluster Shared Volumes.
        /// </summary>
        public const int ERROR_CLUSTER_RESOURCE_CONTAINS_UNSUPPORTED_DIFF_AREA_FOR_SHARED_VOLUMES = 0x00001751; // 5969

        /// <summary>
        ///     The operation cannot be completed because the resource is in maintenance mode.
        /// </summary>
        public const int ERROR_CLUSTER_RESOURCE_IS_IN_MAINTENANCE_MODE = 0x00001752; // 5970

        /// <summary>
        ///     The operation cannot be completed because of cluster affinity conflicts.
        /// </summary>
        public const int ERROR_CLUSTER_AFFINITY_CONFLICT = 0x00001753; // 5971

        /// <summary>
        ///     The operation cannot be completed because the resource is a replica virtual machine.
        /// </summary>
        public const int ERROR_CLUSTER_RESOURCE_IS_REPLICA_VIRTUAL_MACHINE = 0x00001754; // 5972

        #endregion

        #region 6000 - 8199

        /// <summary>
        ///     The specified file could not be encrypted.
        /// </summary>
        public const int ERROR_ENCRYPTION_FAILED = 0x00001770; // 6000

        /// <summary>
        ///     The specified file could not be decrypted.
        /// </summary>
        public const int ERROR_DECRYPTION_FAILED = 0x00001771; // 6001

        /// <summary>
        ///     The specified file is encrypted and the user does not have the ability to decrypt it.
        /// </summary>
        public const int ERROR_FILE_ENCRYPTED = 0x00001772; // 6002

        /// <summary>
        ///     There is no valid encryption recovery policy configured for this system.
        /// </summary>
        public const int ERROR_NO_RECOVERY_POLICY = 0x00001773; // 6003

        /// <summary>
        ///     The required encryption driver is not loaded for this system.
        /// </summary>
        public const int ERROR_NO_EFS = 0x00001774; // 6004

        /// <summary>
        ///     The file was encrypted with a different encryption driver than is currently loaded.
        /// </summary>
        public const int ERROR_WRONG_EFS = 0x00001775; // 6005

        /// <summary>
        ///     There are no EFS keys defined for the user.
        /// </summary>
        public const int ERROR_NO_USER_KEYS = 0x00001776; // 6006

        /// <summary>
        ///     The specified file is not encrypted.
        /// </summary>
        public const int ERROR_FILE_NOT_ENCRYPTED = 0x00001777; // 6007

        /// <summary>
        ///     The specified file is not in the defined EFS export format.
        /// </summary>
        public const int ERROR_NOT_EXPORT_FORMAT = 0x00001778; // 6008

        /// <summary>
        ///     The specified file is read only.
        /// </summary>
        public const int ERROR_FILE_READ_ONLY = 0x00001779; // 6009

        /// <summary>
        ///     The directory has been disabled for encryption.
        /// </summary>
        public const int ERROR_DIR_EFS_DISALLOWED = 0x0000177A; // 6010

        /// <summary>
        ///     The server is not trusted for remote encryption operation.
        /// </summary>
        public const int ERROR_EFS_SERVER_NOT_TRUSTED = 0x0000177B; // 6011

        /// <summary>
        ///     Recovery policy configured for this system contains invalid recovery certificate.
        /// </summary>
        public const int ERROR_BAD_RECOVERY_POLICY = 0x0000177C; // 6012

        /// <summary>
        ///     The encryption algorithm used on the source file needs a bigger key buffer than the one on the destination file.
        /// </summary>
        public const int ERROR_EFS_ALG_BLOB_TOO_BIG = 0x0000177D; // 6013

        /// <summary>
        ///     The disk partition does not support file encryption.
        /// </summary>
        public const int ERROR_VOLUME_NOT_SUPPORT_EFS = 0x0000177E; // 6014

        /// <summary>
        ///     This machine is disabled for file encryption.
        /// </summary>
        public const int ERROR_EFS_DISABLED = 0x0000177F; // 6015

        /// <summary>
        ///     A newer system is required to decrypt this encrypted file.
        /// </summary>
        public const int ERROR_EFS_VERSION_NOT_SUPPORT = 0x00001780; // 6016

        /// <summary>
        ///     The remote server sent an invalid response for a file being opened with Client Side Encryption.
        /// </summary>
        public const int ERROR_CS_ENCRYPTION_INVALID_SERVER_RESPONSE = 0x00001781; // 6017

        /// <summary>
        ///     Client Side Encryption is not supported by the remote server even though it claims to support it.
        /// </summary>
        public const int ERROR_CS_ENCRYPTION_UNSUPPORTED_SERVER = 0x00001782; // 6018

        /// <summary>
        ///     File is encrypted and should be opened in Client Side Encryption mode.
        /// </summary>
        public const int ERROR_CS_ENCRYPTION_EXISTING_ENCRYPTED_FILE = 0x00001783; // 6019

        /// <summary>
        ///     A new encrypted file is being created and a $EFS needs to be provided.
        /// </summary>
        public const int ERROR_CS_ENCRYPTION_NEW_ENCRYPTED_FILE = 0x00001784; // 6020

        /// <summary>
        ///     The SMB client requested a CSE FSCTL on a non-CSE file.
        /// </summary>
        public const int ERROR_CS_ENCRYPTION_FILE_NOT_CSE = 0x00001785; // 6021

        /// <summary>
        ///     The requested operation was blocked by policy. For more information, contact your system administrator.
        /// </summary>
        public const int ERROR_ENCRYPTION_POLICY_DENIES_OPERATION = 0x00001786; // 6022

        /// <summary>
        ///     The list of servers for this workgroup is not currently available.
        /// </summary>
        public const int ERROR_NO_BROWSER_SERVERS_FOUND = 0x000017E6; // 6118

        /// <summary>
        ///     The Task Scheduler service must be configured to run in the System account to function properly. Individual tasks
        ///     may be configured to run in other accounts.
        /// </summary>
        public const int SCHED_E_SERVICE_NOT_LOCALSYSTEM = 0x00001838; // 6200

        /// <summary>
        ///     Log service encountered an invalid log sector.
        /// </summary>
        public const int ERROR_LOG_SECTOR_INVALID = 0x000019C8; // 6600

        /// <summary>
        ///     Log service encountered a log sector with invalid block parity.
        /// </summary>
        public const int ERROR_LOG_SECTOR_PARITY_INVALID = 0x000019C9; // 6601

        /// <summary>
        ///     Log service encountered a remapped log sector.
        /// </summary>
        public const int ERROR_LOG_SECTOR_REMAPPED = 0x000019CA; // 6602

        /// <summary>
        ///     Log service encountered a partial or incomplete log block.
        /// </summary>
        public const int ERROR_LOG_BLOCK_INCOMPLETE = 0x000019CB; // 6603

        /// <summary>
        ///     Log service encountered an attempt access data outside the active log range.
        /// </summary>
        public const int ERROR_LOG_INVALID_RANGE = 0x000019CC; // 6604

        /// <summary>
        ///     Log service user marshaling buffers are exhausted.
        /// </summary>
        public const int ERROR_LOG_BLOCKS_EXHAUSTED = 0x000019CD; // 6605

        /// <summary>
        ///     Log service encountered an attempt read from a marshalling area with an invalid read context.
        /// </summary>
        public const int ERROR_LOG_READ_CONTEXT_INVALID = 0x000019CE; // 6606

        /// <summary>
        ///     Log service encountered an invalid log restart area.
        /// </summary>
        public const int ERROR_LOG_RESTART_INVALID = 0x000019CF; // 6607

        /// <summary>
        ///     Log service encountered an invalid log block version.
        /// </summary>
        public const int ERROR_LOG_BLOCK_VERSION = 0x000019D0; // 6608

        /// <summary>
        ///     Log service encountered an invalid log block.
        /// </summary>
        public const int ERROR_LOG_BLOCK_INVALID = 0x000019D1; // 6609

        /// <summary>
        ///     Log service encountered an attempt to read the log with an invalid read mode.
        /// </summary>
        public const int ERROR_LOG_READ_MODE_INVALID = 0x000019D2; // 6610

        /// <summary>
        ///     Log service encountered a log stream with no restart area.
        /// </summary>
        public const int ERROR_LOG_NO_RESTART = 0x000019D3; // 6611

        /// <summary>
        ///     Log service encountered a corrupted metadata file.
        /// </summary>
        public const int ERROR_LOG_METADATA_CORRUPT = 0x000019D4; // 6612

        /// <summary>
        ///     Log service encountered a metadata file that could not be created by the log file system.
        /// </summary>
        public const int ERROR_LOG_METADATA_INVALID = 0x000019D5; // 6613

        /// <summary>
        ///     Log service encountered a metadata file with inconsistent data.
        /// </summary>
        public const int ERROR_LOG_METADATA_INCONSISTENT = 0x000019D6; // 6614

        /// <summary>
        ///     Log service encountered an attempt to erroneous allocate or dispose reservation space.
        /// </summary>
        public const int ERROR_LOG_RESERVATION_INVALID = 0x000019D7; // 6615

        /// <summary>
        ///     Log service cannot delete log file or file system container.
        /// </summary>
        public const int ERROR_LOG_CANT_DELETE = 0x000019D8; // 6616

        /// <summary>
        ///     Log service has reached the maximum allowable containers allocated to a log file.
        /// </summary>
        public const int ERROR_LOG_CONTAINER_LIMIT_EXCEEDED = 0x000019D9; // 6617

        /// <summary>
        ///     Log service has attempted to read or write backward past the start of the log.
        /// </summary>
        public const int ERROR_LOG_START_OF_LOG = 0x000019DA; // 6618

        /// <summary>
        ///     Log policy could not be installed because a policy of the same type is already present.
        /// </summary>
        public const int ERROR_LOG_POLICY_ALREADY_INSTALLED = 0x000019DB; // 6619

        /// <summary>
        ///     Log policy in question was not installed at the time of the request.
        /// </summary>
        public const int ERROR_LOG_POLICY_NOT_INSTALLED = 0x000019DC; // 6620

        /// <summary>
        ///     The installed set of policies on the log is invalid.
        /// </summary>
        public const int ERROR_LOG_POLICY_INVALID = 0x000019DD; // 6621

        /// <summary>
        ///     A policy on the log in question prevented the operation from completing.
        /// </summary>
        public const int ERROR_LOG_POLICY_CONFLICT = 0x000019DE; // 6622

        /// <summary>
        ///     Log space cannot be reclaimed because the log is pinned by the archive tail.
        /// </summary>
        public const int ERROR_LOG_PINNED_ARCHIVE_TAIL = 0x000019DF; // 6623

        /// <summary>
        ///     Log record is not a record in the log file.
        /// </summary>
        public const int ERROR_LOG_RECORD_NONEXISTENT = 0x000019E0; // 6624

        /// <summary>
        ///     Number of reserved log records or the adjustment of the number of reserved log records is invalid.
        /// </summary>
        public const int ERROR_LOG_RECORDS_RESERVED_INVALID = 0x000019E1; // 6625

        /// <summary>
        ///     Reserved log space or the adjustment of the log space is invalid.
        /// </summary>
        public const int ERROR_LOG_SPACE_RESERVED_INVALID = 0x000019E2; // 6626

        /// <summary>
        ///     An new or existing archive tail or base of the active log is invalid.
        /// </summary>
        public const int ERROR_LOG_TAIL_INVALID = 0x000019E3; // 6627

        /// <summary>
        ///     Log space is exhausted.
        /// </summary>
        public const int ERROR_LOG_FULL = 0x000019E4; // 6628

        /// <summary>
        ///     The log could not be set to the requested size.
        /// </summary>
        public const int ERROR_COULD_NOT_RESIZE_LOG = 0x000019E5; // 6629

        /// <summary>
        ///     Log is multiplexed, no direct writes to the physical log is allowed.
        /// </summary>
        public const int ERROR_LOG_MULTIPLEXED = 0x000019E6; // 6630

        /// <summary>
        ///     The operation failed because the log is a dedicated log.
        /// </summary>
        public const int ERROR_LOG_DEDICATED = 0x000019E7; // 6631

        /// <summary>
        ///     The operation requires an archive context.
        /// </summary>
        public const int ERROR_LOG_ARCHIVE_NOT_IN_PROGRESS = 0x000019E8; // 6632

        /// <summary>
        ///     Log archival is in progress.
        /// </summary>
        public const int ERROR_LOG_ARCHIVE_IN_PROGRESS = 0x000019E9; // 6633

        /// <summary>
        ///     The operation requires a non-ephemeral log, but the log is ephemeral.
        /// </summary>
        public const int ERROR_LOG_EPHEMERAL = 0x000019EA; // 6634

        /// <summary>
        ///     The log must have at least two containers before it can be read from or written to.
        /// </summary>
        public const int ERROR_LOG_NOT_ENOUGH_CONTAINERS = 0x000019EB; // 6635

        /// <summary>
        ///     A log client has already registered on the stream.
        /// </summary>
        public const int ERROR_LOG_CLIENT_ALREADY_REGISTERED = 0x000019EC; // 6636

        /// <summary>
        ///     A log client has not been registered on the stream.
        /// </summary>
        public const int ERROR_LOG_CLIENT_NOT_REGISTERED = 0x000019ED; // 6637

        /// <summary>
        ///     A request has already been made to handle the log full condition.
        /// </summary>
        public const int ERROR_LOG_FULL_HANDLER_IN_PROGRESS = 0x000019EE; // 6638

        /// <summary>
        ///     Log service encountered an error when attempting to read from a log container.
        /// </summary>
        public const int ERROR_LOG_CONTAINER_READ_FAILED = 0x000019EF; // 6639

        /// <summary>
        ///     Log service encountered an error when attempting to write to a log container.
        /// </summary>
        public const int ERROR_LOG_CONTAINER_WRITE_FAILED = 0x000019F0; // 6640

        /// <summary>
        ///     Log service encountered an error when attempting open a log container.
        /// </summary>
        public const int ERROR_LOG_CONTAINER_OPEN_FAILED = 0x000019F1; // 6641

        /// <summary>
        ///     Log service encountered an invalid container state when attempting a requested action.
        /// </summary>
        public const int ERROR_LOG_CONTAINER_STATE_INVALID = 0x000019F2; // 6642

        /// <summary>
        ///     Log service is not in the correct state to perform a requested action.
        /// </summary>
        public const int ERROR_LOG_STATE_INVALID = 0x000019F3; // 6643

        /// <summary>
        ///     Log space cannot be reclaimed because the log is pinned.
        /// </summary>
        public const int ERROR_LOG_PINNED = 0x000019F4; // 6644

        /// <summary>
        ///     Log metadata flush failed.
        /// </summary>
        public const int ERROR_LOG_METADATA_FLUSH_FAILED = 0x000019F5; // 6645

        /// <summary>
        ///     Security on the log and its containers is inconsistent.
        /// </summary>
        public const int ERROR_LOG_INCONSISTENT_SECURITY = 0x000019F6; // 6646

        /// <summary>
        ///     Records were appended to the log or reservation changes were made, but the log could not be flushed.
        /// </summary>
        public const int ERROR_LOG_APPENDED_FLUSH_FAILED = 0x000019F7; // 6647

        /// <summary>
        ///     The log is pinned due to reservation consuming most of the log space. Free some reserved records to make space
        ///     available.
        /// </summary>
        public const int ERROR_LOG_PINNED_RESERVATION = 0x000019F8; // 6648

        /// <summary>
        ///     The transaction handle associated with this operation is not valid.
        /// </summary>
        public const int ERROR_INVALID_TRANSACTION = 0x00001A2C; // 6700

        /// <summary>
        ///     The requested operation was made in the context of a transaction that is no longer active.
        /// </summary>
        public const int ERROR_TRANSACTION_NOT_ACTIVE = 0x00001A2D; // 6701

        /// <summary>
        ///     The requested operation is not valid on the Transaction object in its current state.
        /// </summary>
        public const int ERROR_TRANSACTION_REQUEST_NOT_VALID = 0x00001A2E; // 6702

        /// <summary>
        ///     The caller has called a response API, but the response is not expected because the TM did not issue the
        ///     corresponding request to the caller.
        /// </summary>
        public const int ERROR_TRANSACTION_NOT_REQUESTED = 0x00001A2F; // 6703

        /// <summary>
        ///     It is too late to perform the requested operation, since the Transaction has already been aborted.
        /// </summary>
        public const int ERROR_TRANSACTION_ALREADY_ABORTED = 0x00001A30; // 6704

        /// <summary>
        ///     It is too late to perform the requested operation, since the Transaction has already been committed.
        /// </summary>
        public const int ERROR_TRANSACTION_ALREADY_COMMITTED = 0x00001A31; // 6705

        /// <summary>
        ///     The Transaction Manager was unable to be successfully initialized. Transacted operations are not supported.
        /// </summary>
        public const int ERROR_TM_INITIALIZATION_FAILED = 0x00001A32; // 6706

        /// <summary>
        ///     The specified ResourceManager made no changes or updates to the resource under this transaction.
        /// </summary>
        public const int ERROR_RESOURCEMANAGER_READ_ONLY = 0x00001A33; // 6707

        /// <summary>
        ///     The resource manager has attempted to prepare a transaction that it has not successfully joined.
        /// </summary>
        public const int ERROR_TRANSACTION_NOT_JOINED = 0x00001A34; // 6708

        /// <summary>
        ///     The Transaction object already has a superior enlistment, and the caller attempted an operation that would have
        ///     created a new superior. Only a single superior enlistment is allow.
        /// </summary>
        public const int ERROR_TRANSACTION_SUPERIOR_EXISTS = 0x00001A35; // 6709

        /// <summary>
        ///     The RM tried to register a protocol that already exists.
        /// </summary>
        public const int ERROR_CRM_PROTOCOL_ALREADY_EXISTS = 0x00001A36; // 6710

        /// <summary>
        ///     The attempt to propagate the Transaction failed.
        /// </summary>
        public const int ERROR_TRANSACTION_PROPAGATION_FAILED = 0x00001A37; // 6711

        /// <summary>
        ///     The requested propagation protocol was not registered as a CRM.
        /// </summary>
        public const int ERROR_CRM_PROTOCOL_NOT_FOUND = 0x00001A38; // 6712

        /// <summary>
        ///     The buffer passed in to PushTransaction or PullTransaction is not in a valid format.
        /// </summary>
        public const int ERROR_TRANSACTION_INVALID_MARSHALL_BUFFER = 0x00001A39; // 6713

        /// <summary>
        ///     The current transaction context associated with the thread is not a valid handle to a transaction object.
        /// </summary>
        public const int ERROR_CURRENT_TRANSACTION_NOT_VALID = 0x00001A3A; // 6714

        /// <summary>
        ///     The specified Transaction object could not be opened, because it was not found.
        /// </summary>
        public const int ERROR_TRANSACTION_NOT_FOUND = 0x00001A3B; // 6715

        /// <summary>
        ///     The specified ResourceManager object could not be opened, because it was not found.
        /// </summary>
        public const int ERROR_RESOURCEMANAGER_NOT_FOUND = 0x00001A3C; // 6716

        /// <summary>
        ///     The specified Enlistment object could not be opened, because it was not found.
        /// </summary>
        public const int ERROR_ENLISTMENT_NOT_FOUND = 0x00001A3D; // 6717

        /// <summary>
        ///     The specified TransactionManager object could not be opened, because it was not found.
        /// </summary>
        public const int ERROR_TRANSACTIONMANAGER_NOT_FOUND = 0x00001A3E; // 6718

        /// <summary>
        ///     The object specified could not be created or opened, because its associated TransactionManager is not online. The
        ///     TransactionManager must be brought fully Online by calling RecoverTransactionManager to recover to the end of its
        ///     LogFile before objects in its Transaction or ResourceManager namespaces can be opened.  In addition, errors in
        ///     writing records to its LogFile can cause a TransactionManager to go offline.
        /// </summary>
        public const int ERROR_TRANSACTIONMANAGER_NOT_ONLINE = 0x00001A3F; // 6719

        /// <summary>
        ///     The specified TransactionManager was unable to create the objects contained in its logfile in the Ob namespace.
        ///     Therefore, the TransactionManager was unable to recover.
        /// </summary>
        public const int ERROR_TRANSACTIONMANAGER_RECOVERY_NAME_COLLISION = 0x00001A40; // 6720

        /// <summary>
        ///     The call to create a superior Enlistment on this Transaction object could not be completed, because the Transaction
        ///     object specified for the enlistment is a subordinate branch of the Transaction. Only the root of the Transaction
        ///     can be enlisted on as a superior.
        /// </summary>
        public const int ERROR_TRANSACTION_NOT_ROOT = 0x00001A41; // 6721

        /// <summary>
        ///     Because the associated transaction manager or resource manager has been closed, the handle is no longer valid.
        /// </summary>
        public const int ERROR_TRANSACTION_OBJECT_EXPIRED = 0x00001A42; // 6722

        /// <summary>
        ///     The specified operation could not be performed on this Superior enlistment, because the enlistment was not created
        ///     with the corresponding completion response in the NotificationMask.
        /// </summary>
        public const int ERROR_TRANSACTION_RESPONSE_NOT_ENLISTED = 0x00001A43; // 6723

        /// <summary>
        ///     The specified operation could not be performed, because the record that would be logged was too long. This can
        ///     occur because of two conditions: either there are too many Enlistments on this Transaction, or the combined
        ///     RecoveryInformation being logged on behalf of those Enlistments is too long.
        /// </summary>
        public const int ERROR_TRANSACTION_RECORD_TOO_LONG = 0x00001A44; // 6724

        /// <summary>
        ///     Implicit transaction are not supported.
        /// </summary>
        public const int ERROR_IMPLICIT_TRANSACTION_NOT_SUPPORTED = 0x00001A45; // 6725

        /// <summary>
        ///     The kernel transaction manager had to abort or forget the transaction because it blocked forward progress.
        /// </summary>
        public const int ERROR_TRANSACTION_INTEGRITY_VIOLATED = 0x00001A46; // 6726

        /// <summary>
        ///     The TransactionManager identity that was supplied did not match the one recorded in the TransactionManager's log
        ///     file.
        /// </summary>
        public const int ERROR_TRANSACTIONMANAGER_IDENTITY_MISMATCH = 0x00001A47; // 6727

        /// <summary>
        ///     This snapshot operation cannot continue because a transactional resource manager cannot be frozen in its current
        ///     state.  Please try again.
        /// </summary>
        public const int ERROR_RM_CANNOT_BE_FROZEN_FOR_SNAPSHOT = 0x00001A48; // 6728

        /// <summary>
        ///     The transaction cannot be enlisted on with the specified EnlistmentMask, because the transaction has already
        ///     completed the PrePrepare phase.  In order to ensure correctness, the ResourceManager must switch to a write-
        ///     through mode and cease caching data within this transaction.  Enlisting for only subsequent transaction phases may
        ///     still succeed.
        /// </summary>
        public const int ERROR_TRANSACTION_MUST_WRITETHROUGH = 0x00001A49; // 6729

        /// <summary>
        ///     The transaction does not have a superior enlistment.
        /// </summary>
        public const int ERROR_TRANSACTION_NO_SUPERIOR = 0x00001A4A; // 6730

        /// <summary>
        ///     The attempt to commit the Transaction completed, but it is possible that some portion of the transaction tree did
        ///     not commit successfully due to heuristics.  Therefore it is possible that some data modified in the transaction may
        ///     not have committed, resulting in transactional inconsistency.  If possible, check the consistency of the associated
        ///     data.
        /// </summary>
        public const int ERROR_HEURISTIC_DAMAGE_POSSIBLE = 0x00001A4B; // 6731

        /// <summary>
        ///     The function attempted to use a name that is reserved for use by another transaction.
        /// </summary>
        public const int ERROR_TRANSACTIONAL_CONFLICT = 0x00001A90; // 6800

        /// <summary>
        ///     Transaction support within the specified resource manager is not started or was shut down due to an error.
        /// </summary>
        public const int ERROR_RM_NOT_ACTIVE = 0x00001A91; // 6801

        /// <summary>
        ///     The metadata of the RM has been corrupted. The RM will not function.
        /// </summary>
        public const int ERROR_RM_METADATA_CORRUPT = 0x00001A92; // 6802

        /// <summary>
        ///     The specified directory does not contain a resource manager.
        /// </summary>
        public const int ERROR_DIRECTORY_NOT_RM = 0x00001A93; // 6803

        /// <summary>
        ///     The remote server or share does not support transacted file operations.
        /// </summary>
        public const int ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE = 0x00001A95; // 6805

        /// <summary>
        ///     The requested log size is invalid.
        /// </summary>
        public const int ERROR_LOG_RESIZE_INVALID_SIZE = 0x00001A96; // 6806

        /// <summary>
        ///     The object (file, stream, link) corresponding to the handle has been deleted by a Transaction Savepoint Rollback.
        /// </summary>
        public const int ERROR_OBJECT_NO_LONGER_EXISTS = 0x00001A97; // 6807

        /// <summary>
        ///     The specified file miniversion was not found for this transacted file open.
        /// </summary>
        public const int ERROR_STREAM_MINIVERSION_NOT_FOUND = 0x00001A98; // 6808

        /// <summary>
        ///     The specified file miniversion was found but has been invalidated. Most likely cause is a transaction savepoint
        ///     rollback.
        /// </summary>
        public const int ERROR_STREAM_MINIVERSION_NOT_VALID = 0x00001A99; // 6809

        /// <summary>
        ///     A miniversion may only be opened in the context of the transaction that created it.
        /// </summary>
        public const int ERROR_MINIVERSION_INACCESSIBLE_FROM_SPECIFIED_TRANSACTION = 0x00001A9A; // 6810

        /// <summary>
        ///     It is not possible to open a miniversion with modify access.
        /// </summary>
        public const int ERROR_CANT_OPEN_MINIVERSION_WITH_MODIFY_INTENT = 0x00001A9B; // 6811

        /// <summary>
        ///     It is not possible to create any more miniversions for this stream.
        /// </summary>
        public const int ERROR_CANT_CREATE_MORE_STREAM_MINIVERSIONS = 0x00001A9C; // 6812

        /// <summary>
        ///     The remote server sent mismatching version number or Fid for a file opened with transactions.
        /// </summary>
        public const int ERROR_REMOTE_FILE_VERSION_MISMATCH = 0x00001A9E; // 6814

        /// <summary>
        ///     The handle has been invalidated by a transaction. The most likely cause is the presence of memory mapping on a file
        ///     or an open handle when the transaction ended or rolled back to savepoint.
        /// </summary>
        public const int ERROR_HANDLE_NO_LONGER_VALID = 0x00001A9F; // 6815

        /// <summary>
        ///     There is no transaction metadata on the file.
        /// </summary>
        public const int ERROR_NO_TXF_METADATA = 0x00001AA0; // 6816

        /// <summary>
        ///     The log data is corrupt.
        /// </summary>
        public const int ERROR_LOG_CORRUPTION_DETECTED = 0x00001AA1; // 6817

        /// <summary>
        ///     The file can't be recovered because there is a handle still open on it.
        /// </summary>
        public const int ERROR_CANT_RECOVER_WITH_HANDLE_OPEN = 0x00001AA2; // 6818

        /// <summary>
        ///     The transaction outcome is unavailable because the resource manager responsible for it has disconnected.
        /// </summary>
        public const int ERROR_RM_DISCONNECTED = 0x00001AA3; // 6819

        /// <summary>
        ///     The request was rejected because the enlistment in question is not a superior enlistment.
        /// </summary>
        public const int ERROR_ENLISTMENT_NOT_SUPERIOR = 0x00001AA4; // 6820

        /// <summary>
        ///     The transactional resource manager is already consistent. Recovery is not needed.
        /// </summary>
        public const int ERROR_RECOVERY_NOT_NEEDED = 0x00001AA5; // 6821

        /// <summary>
        ///     The transactional resource manager has already been started.
        /// </summary>
        public const int ERROR_RM_ALREADY_STARTED = 0x00001AA6; // 6822

        /// <summary>
        ///     The file cannot be opened transactionally, because its identity depends on the outcome of an unresolved
        ///     transaction.
        /// </summary>
        public const int ERROR_FILE_IDENTITY_NOT_PERSISTENT = 0x00001AA7; // 6823

        /// <summary>
        ///     The operation cannot be performed because another transaction is depending on the fact that this property will not
        ///     change.
        /// </summary>
        public const int ERROR_CANT_BREAK_TRANSACTIONAL_DEPENDENCY = 0x00001AA8; // 6824

        /// <summary>
        ///     The operation would involve a single file with two transactional resource managers and is therefore not allowed.
        /// </summary>
        public const int ERROR_CANT_CROSS_RM_BOUNDARY = 0x00001AA9; // 6825

        /// <summary>
        ///     The $Txf directory must be empty for this operation to succeed.
        /// </summary>
        public const int ERROR_TXF_DIR_NOT_EMPTY = 0x00001AAA; // 6826

        /// <summary>
        ///     The operation would leave a transactional resource manager in an inconsistent state and is therefore not allowed.
        /// </summary>
        public const int ERROR_INDOUBT_TRANSACTIONS_EXIST = 0x00001AAB; // 6827

        /// <summary>
        ///     The operation could not be completed because the transaction manager does not have a log.
        /// </summary>
        public const int ERROR_TM_VOLATILE = 0x00001AAC; // 6828

        /// <summary>
        ///     A rollback could not be scheduled because a previously scheduled rollback has already executed or been queued for
        ///     execution.
        /// </summary>
        public const int ERROR_ROLLBACK_TIMER_EXPIRED = 0x00001AAD; // 6829

        /// <summary>
        ///     The transactional metadata attribute on the file or directory is corrupt and unreadable.
        /// </summary>
        public const int ERROR_TXF_ATTRIBUTE_CORRUPT = 0x00001AAE; // 6830

        /// <summary>
        ///     The encryption operation could not be completed because a transaction is active.
        /// </summary>
        public const int ERROR_EFS_NOT_ALLOWED_IN_TRANSACTION = 0x00001AAF; // 6831

        /// <summary>
        ///     This object is not allowed to be opened in a transaction.
        /// </summary>
        public const int ERROR_TRANSACTIONAL_OPEN_NOT_ALLOWED = 0x00001AB0; // 6832

        /// <summary>
        ///     An attempt to create space in the transactional resource manager's log failed. The failure status has been recorded
        ///     in the event log.
        /// </summary>
        public const int ERROR_LOG_GROWTH_FAILED = 0x00001AB1; // 6833

        /// <summary>
        ///     Memory mapping (creating a mapped section) a remote file under a transaction is not supported.
        /// </summary>
        public const int ERROR_TRANSACTED_MAPPING_UNSUPPORTED_REMOTE = 0x00001AB2; // 6834

        /// <summary>
        ///     Transaction metadata is already present on this file and cannot be superseded.
        /// </summary>
        public const int ERROR_TXF_METADATA_ALREADY_PRESENT = 0x00001AB3; // 6835

        /// <summary>
        ///     A transaction scope could not be entered because the scope handler has not been initialized.
        /// </summary>
        public const int ERROR_TRANSACTION_SCOPE_CALLBACKS_NOT_SET = 0x00001AB4; // 6836

        /// <summary>
        ///     Promotion was required in order to allow the resource manager to enlist, but the transaction was set to disallow
        ///     it.
        /// </summary>
        public const int ERROR_TRANSACTION_REQUIRED_PROMOTION = 0x00001AB5; // 6837

        /// <summary>
        ///     This file is open for modification in an unresolved transaction and may be opened for execute only by a transacted
        ///     reader.
        /// </summary>
        public const int ERROR_CANNOT_EXECUTE_FILE_IN_TRANSACTION = 0x00001AB6; // 6838

        /// <summary>
        ///     The request to thaw frozen transactions was ignored because transactions had not previously been frozen.
        /// </summary>
        public const int ERROR_TRANSACTIONS_NOT_FROZEN = 0x00001AB7; // 6839

        /// <summary>
        ///     Transactions cannot be frozen because a freeze is already in progress.
        /// </summary>
        public const int ERROR_TRANSACTION_FREEZE_IN_PROGRESS = 0x00001AB8; // 6840

        /// <summary>
        ///     The target volume is not a snapshot volume. This operation is only valid on a volume mounted as a snapshot.
        /// </summary>
        public const int ERROR_NOT_SNAPSHOT_VOLUME = 0x00001AB9; // 6841

        /// <summary>
        ///     The savepoint operation failed because files are open on the transaction. This is not permitted.
        /// </summary>
        public const int ERROR_NO_SAVEPOINT_WITH_OPEN_FILES = 0x00001ABA; // 6842

        /// <summary>
        ///     Windows has discovered corruption in a file, and that file has since been repaired. Data loss may have occurred.
        /// </summary>
        public const int ERROR_DATA_LOST_REPAIR = 0x00001ABB; // 6843

        /// <summary>
        ///     The sparse operation could not be completed because a transaction is active on the file.
        /// </summary>
        public const int ERROR_SPARSE_NOT_ALLOWED_IN_TRANSACTION = 0x00001ABC; // 6844

        /// <summary>
        ///     The call to create a TransactionManager object failed because the Tm Identity stored in the logfile does not match
        ///     the Tm Identity that was passed in as an argument.
        /// </summary>
        public const int ERROR_TM_IDENTITY_MISMATCH = 0x00001ABD; // 6845

        /// <summary>
        ///     I/O was attempted on a section object that has been floated as a result of a transaction ending. There is no valid
        ///     data.
        /// </summary>
        public const int ERROR_FLOATED_SECTION = 0x00001ABE; // 6846

        /// <summary>
        ///     The transactional resource manager cannot currently accept transacted work due to a transient condition such as low
        ///     resources.
        /// </summary>
        public const int ERROR_CANNOT_ACCEPT_TRANSACTED_WORK = 0x00001ABF; // 6847

        /// <summary>
        ///     The transactional resource manager had too many tranactions outstanding that could not be aborted. The
        ///     transactional resource manger has been shut down.
        /// </summary>
        public const int ERROR_CANNOT_ABORT_TRANSACTIONS = 0x00001AC0; // 6848

        /// <summary>
        ///     The operation could not be completed due to bad clusters on disk.
        /// </summary>
        public const int ERROR_BAD_CLUSTERS = 0x00001AC1; // 6849

        /// <summary>
        ///     The compression operation could not be completed because a transaction is active on the file.
        /// </summary>
        public const int ERROR_COMPRESSION_NOT_ALLOWED_IN_TRANSACTION = 0x00001AC2; // 6850

        /// <summary>
        ///     The operation could not be completed because the volume is dirty. Please run chkdsk and try again.
        /// </summary>
        public const int ERROR_VOLUME_DIRTY = 0x00001AC3; // 6851

        /// <summary>
        ///     The link tracking operation could not be completed because a transaction is active.
        /// </summary>
        public const int ERROR_NO_LINK_TRACKING_IN_TRANSACTION = 0x00001AC4; // 6852

        /// <summary>
        ///     This operation cannot be performed in a transaction.
        /// </summary>
        public const int ERROR_OPERATION_NOT_SUPPORTED_IN_TRANSACTION = 0x00001AC5; // 6853

        /// <summary>
        ///     The handle is no longer properly associated with its transaction.  It may have been opened in a transactional
        ///     resource manager that was subsequently forced to restart.  Please close the handle and open a new one.
        /// </summary>
        public const int ERROR_EXPIRED_HANDLE = 0x00001AC6; // 6854

        /// <summary>
        ///     The specified operation could not be performed because the resource manager is not enlisted in the transaction.
        /// </summary>
        public const int ERROR_TRANSACTION_NOT_ENLISTED = 0x00001AC7; // 6855

        /// <summary>
        ///     The specified session name is invalid.
        /// </summary>
        public const int ERROR_CTX_WINSTATION_NAME_INVALID = 0x00001B59; // 7001

        /// <summary>
        ///     The specified protocol driver is invalid.
        /// </summary>
        public const int ERROR_CTX_INVALID_PD = 0x00001B5A; // 7002

        /// <summary>
        ///     The specified protocol driver was not found in the system path.
        /// </summary>
        public const int ERROR_CTX_PD_NOT_FOUND = 0x00001B5B; // 7003

        /// <summary>
        ///     The specified terminal connection driver was not found in the system path.
        /// </summary>
        public const int ERROR_CTX_WD_NOT_FOUND = 0x00001B5C; // 7004

        /// <summary>
        ///     A registry key for event logging could not be created for this session.
        /// </summary>
        public const int ERROR_CTX_CANNOT_MAKE_EVENTLOG_ENTRY = 0x00001B5D; // 7005

        /// <summary>
        ///     A service with the same name already exists on the system.
        /// </summary>
        public const int ERROR_CTX_SERVICE_NAME_COLLISION = 0x00001B5E; // 7006

        /// <summary>
        ///     A close operation is pending on the session.
        /// </summary>
        public const int ERROR_CTX_CLOSE_PENDING = 0x00001B5F; // 7007

        /// <summary>
        ///     There are no free output buffers available.
        /// </summary>
        public const int ERROR_CTX_NO_OUTBUF = 0x00001B60; // 7008

        /// <summary>
        ///     The MODEM.INF file was not found.
        /// </summary>
        public const int ERROR_CTX_MODEM_INF_NOT_FOUND = 0x00001B61; // 7009

        /// <summary>
        ///     The modem name was not found in MODEM.INF.
        /// </summary>
        public const int ERROR_CTX_INVALID_MODEMNAME = 0x00001B62; // 7010

        /// <summary>
        ///     The modem did not accept the command sent to it. Verify that the configured modem name matches the attached modem.
        /// </summary>
        public const int ERROR_CTX_MODEM_RESPONSE_ERROR = 0x00001B63; // 7011

        /// <summary>
        ///     The modem did not respond to the command sent to it. Verify that the modem is properly cabled and powered on.
        /// </summary>
        public const int ERROR_CTX_MODEM_RESPONSE_TIMEOUT = 0x00001B64; // 7012

        /// <summary>
        ///     Carrier detect has failed or carrier has been dropped due to disconnect.
        /// </summary>
        public const int ERROR_CTX_MODEM_RESPONSE_NO_CARRIER = 0x00001B65; // 7013

        /// <summary>
        ///     Dial tone not detected within the required time. Verify that the phone cable is properly attached and functional.
        /// </summary>
        public const int ERROR_CTX_MODEM_RESPONSE_NO_DIALTONE = 0x00001B66; // 7014

        /// <summary>
        ///     Busy signal detected at remote site on callback.
        /// </summary>
        public const int ERROR_CTX_MODEM_RESPONSE_BUSY = 0x00001B67; // 7015

        /// <summary>
        ///     Voice detected at remote site on callback.
        /// </summary>
        public const int ERROR_CTX_MODEM_RESPONSE_VOICE = 0x00001B68; // 7016

        /// <summary>
        ///     Transport driver error.
        /// </summary>
        public const int ERROR_CTX_TD_ERROR = 0x00001B69; // 7017

        /// <summary>
        ///     The specified session cannot be found.
        /// </summary>
        public const int ERROR_CTX_WINSTATION_NOT_FOUND = 0x00001B6E; // 7022

        /// <summary>
        ///     The specified session name is already in use.
        /// </summary>
        public const int ERROR_CTX_WINSTATION_ALREADY_EXISTS = 0x00001B6F; // 7023

        /// <summary>
        ///     The task you are trying to do can't be completed because Remote Desktop Services is currently busy. Please try
        ///     again in a few minutes. Other users should still be able to log on.
        /// </summary>
        public const int ERROR_CTX_WINSTATION_BUSY = 0x00001B70; // 7024

        /// <summary>
        ///     An attempt has been made to connect to a session whose video mode is not supported by the current client.
        /// </summary>
        public const int ERROR_CTX_BAD_VIDEO_MODE = 0x00001B71; // 7025

        /// <summary>
        ///     The application attempted to enable DOS graphics mode. DOS graphics mode is not supported.
        /// </summary>
        public const int ERROR_CTX_GRAPHICS_INVALID = 0x00001B7B; // 7035

        /// <summary>
        ///     Your interactive logon privilege has been disabled. Please contact your administrator.
        /// </summary>
        public const int ERROR_CTX_LOGON_DISABLED = 0x00001B7D; // 7037

        /// <summary>
        ///     The requested operation can be performed only on the system console. This is most often the result of a driver or
        ///     system DLL requiring direct console access.
        /// </summary>
        public const int ERROR_CTX_NOT_CONSOLE = 0x00001B7E; // 7038

        /// <summary>
        ///     The client failed to respond to the server connect message.
        /// </summary>
        public const int ERROR_CTX_CLIENT_QUERY_TIMEOUT = 0x00001B80; // 7040

        /// <summary>
        ///     Disconnecting the console session is not supported.
        /// </summary>
        public const int ERROR_CTX_CONSOLE_DISCONNECT = 0x00001B81; // 7041

        /// <summary>
        ///     Reconnecting a disconnected session to the console is not supported.
        /// </summary>
        public const int ERROR_CTX_CONSOLE_CONNECT = 0x00001B82; // 7042

        /// <summary>
        ///     The request to control another session remotely was denied.
        /// </summary>
        public const int ERROR_CTX_SHADOW_DENIED = 0x00001B84; // 7044

        /// <summary>
        ///     The requested session access is denied.
        /// </summary>
        public const int ERROR_CTX_WINSTATION_ACCESS_DENIED = 0x00001B85; // 7045

        /// <summary>
        ///     The specified terminal connection driver is invalid.
        /// </summary>
        public const int ERROR_CTX_INVALID_WD = 0x00001B89; // 7049

        /// <summary>
        ///     The requested session cannot be controlled remotely. This may be because the session is disconnected or does not
        ///     currently have a user logged on.
        /// </summary>
        public const int ERROR_CTX_SHADOW_INVALID = 0x00001B8A; // 7050

        /// <summary>
        ///     The requested session is not configured to allow remote control.
        /// </summary>
        public const int ERROR_CTX_SHADOW_DISABLED = 0x00001B8B; // 7051

        /// <summary>
        ///     Your request to connect to this Terminal Server has been rejected. Your Terminal Server client license number is
        ///     currently being used by another user. Please call your system administrator to obtain a unique license number.
        /// </summary>
        public const int ERROR_CTX_CLIENT_LICENSE_IN_USE = 0x00001B8C; // 7052

        /// <summary>
        ///     Your request to connect to this Terminal Server has been rejected. Your Terminal Server client license number has
        ///     not been entered for this copy of the Terminal Server client. Please contact your system administrator.
        /// </summary>
        public const int ERROR_CTX_CLIENT_LICENSE_NOT_SET = 0x00001B8D; // 7053

        /// <summary>
        ///     The number of connections to this computer is limited and all connections are in use right now. Try connecting
        ///     later or contact your system administrator.
        /// </summary>
        public const int ERROR_CTX_LICENSE_NOT_AVAILABLE = 0x00001B8E; // 7054

        /// <summary>
        ///     The client you are using is not licensed to use this system. Your logon request is denied.
        /// </summary>
        public const int ERROR_CTX_LICENSE_CLIENT_INVALID = 0x00001B8F; // 7055

        /// <summary>
        ///     The system license has expired. Your logon request is denied.
        /// </summary>
        public const int ERROR_CTX_LICENSE_EXPIRED = 0x00001B90; // 7056

        /// <summary>
        ///     Remote control could not be terminated because the specified session is not currently being remotely controlled.
        /// </summary>
        public const int ERROR_CTX_SHADOW_NOT_RUNNING = 0x00001B91; // 7057

        /// <summary>
        ///     The remote control of the console was terminated because the display mode was changed. Changing the display mode in
        ///     a remote control session is not supported.
        /// </summary>
        public const int ERROR_CTX_SHADOW_ENDED_BY_MODE_CHANGE = 0x00001B92; // 7058

        /// <summary>
        ///     Activation has already been reset the maximum number of times for this installation. Your activation timer will not
        ///     be cleared.
        /// </summary>
        public const int ERROR_ACTIVATION_COUNT_EXCEEDED = 0x00001B93; // 7059

        /// <summary>
        ///     Remote logins are currently disabled.
        /// </summary>
        public const int ERROR_CTX_WINSTATIONS_DISABLED = 0x00001B94; // 7060

        /// <summary>
        ///     You do not have the proper encryption level to access this Session.
        /// </summary>
        public const int ERROR_CTX_ENCRYPTION_LEVEL_REQUIRED = 0x00001B95; // 7061

        /// <summary>
        ///     The user %s\\%s is currently logged on to this computer. Only the current user or an administrator can log on to
        ///     this computer.
        /// </summary>
        public const int ERROR_CTX_SESSION_IN_USE = 0x00001B96; // 7062

        /// <summary>
        ///     The user %s\\%s is already logged on to the console of this computer. You do not have permission to log in at this
        ///     time. To resolve this issue, contact %s\\%s and have them log off.
        /// </summary>
        public const int ERROR_CTX_NO_FORCE_LOGOFF = 0x00001B97; // 7063

        /// <summary>
        ///     Unable to log you on because of an account restriction.
        /// </summary>
        public const int ERROR_CTX_ACCOUNT_RESTRICTION = 0x00001B98; // 7064

        /// <summary>
        ///     The RDP protocol component %2 detected an error in the protocol stream and has disconnected the client.
        /// </summary>
        public const int ERROR_RDP_PROTOCOL_ERROR = 0x00001B99; // 7065

        /// <summary>
        ///     The Client Drive Mapping Service Has Connected on Terminal Connection.
        /// </summary>
        public const int ERROR_CTX_CDM_CONNECT = 0x00001B9A; // 7066

        /// <summary>
        ///     The Client Drive Mapping Service Has Disconnected on Terminal Connection.
        /// </summary>
        public const int ERROR_CTX_CDM_DISCONNECT = 0x00001B9B; // 7067

        /// <summary>
        ///     The Terminal Server security layer detected an error in the protocol stream and has disconnected the client.
        /// </summary>
        public const int ERROR_CTX_SECURITY_LAYER_ERROR = 0x00001B9C; // 7068

        /// <summary>
        ///     The target session is incompatible with the current session.
        /// </summary>
        public const int ERROR_TS_INCOMPATIBLE_SESSIONS = 0x00001B9D; // 7069

        /// <summary>
        ///     Windows can't connect to your session because a problem occurred in the Windows video subsystem. Try connecting
        ///     again later, or contact the server administrator for assistance.
        /// </summary>
        public const int ERROR_TS_VIDEO_SUBSYSTEM_ERROR = 0x00001B9E; // 7070

        /// <summary>
        ///     The file replication service API was called incorrectly.
        /// </summary>
        public const int FRS_ERR_INVALID_API_SEQUENCE = 0x00001F41; // 8001

        /// <summary>
        ///     The file replication service cannot be started.
        /// </summary>
        public const int FRS_ERR_STARTING_SERVICE = 0x00001F42; // 8002

        /// <summary>
        ///     The file replication service cannot be stopped.
        /// </summary>
        public const int FRS_ERR_STOPPING_SERVICE = 0x00001F43; // 8003

        /// <summary>
        ///     The file replication service API terminated the request. The event log may have more information.
        /// </summary>
        public const int FRS_ERR_INTERNAL_API = 0x00001F44; // 8004

        /// <summary>
        ///     The file replication service terminated the request. The event log may have more information.
        /// </summary>
        public const int FRS_ERR_INTERNAL = 0x00001F45; // 8005

        /// <summary>
        ///     The file replication service cannot be contacted. The event log may have more information.
        /// </summary>
        public const int FRS_ERR_SERVICE_COMM = 0x00001F46; // 8006

        /// <summary>
        ///     The file replication service cannot satisfy the request because the user has insufficient privileges. The event log
        ///     may have more information.
        /// </summary>
        public const int FRS_ERR_INSUFFICIENT_PRIV = 0x00001F47; // 8007

        /// <summary>
        ///     The file replication service cannot satisfy the request because authenticated RPC is not available. The event log
        ///     may have more information.
        /// </summary>
        public const int FRS_ERR_AUTHENTICATION = 0x00001F48; // 8008

        /// <summary>
        ///     The file replication service cannot satisfy the request because the user has insufficient privileges on the domain
        ///     controller. The event log may have more information.
        /// </summary>
        public const int FRS_ERR_PARENT_INSUFFICIENT_PRIV = 0x00001F49; // 8009

        /// <summary>
        ///     The file replication service cannot satisfy the request because authenticated RPC is not available on the domain
        ///     controller. The event log may have more information.
        /// </summary>
        public const int FRS_ERR_PARENT_AUTHENTICATION = 0x00001F4A; // 8010

        /// <summary>
        ///     The file replication service cannot communicate with the file replication service on the domain controller. The
        ///     event log may have more information.
        /// </summary>
        public const int FRS_ERR_CHILD_TO_PARENT_COMM = 0x00001F4B; // 8011

        /// <summary>
        ///     The file replication service on the domain controller cannot communicate with the file replication service on this
        ///     computer. The event log may have more information.
        /// </summary>
        public const int FRS_ERR_PARENT_TO_CHILD_COMM = 0x00001F4C; // 8012

        /// <summary>
        ///     The file replication service cannot populate the system volume because of an internal error. The event log may have
        ///     more information.
        /// </summary>
        public const int FRS_ERR_SYSVOL_POPULATE = 0x00001F4D; // 8013

        /// <summary>
        ///     The file replication service cannot populate the system volume because of an internal timeout. The event log may
        ///     have more information.
        /// </summary>
        public const int FRS_ERR_SYSVOL_POPULATE_TIMEOUT = 0x00001F4E; // 8014

        /// <summary>
        ///     The file replication service cannot process the request. The system volume is busy with a previous request.
        /// </summary>
        public const int FRS_ERR_SYSVOL_IS_BUSY = 0x00001F4F; // 8015

        /// <summary>
        ///     The file replication service cannot stop replicating the system volume because of an internal error. The event log
        ///     may have more information.
        /// </summary>
        public const int FRS_ERR_SYSVOL_DEMOTE = 0x00001F50; // 8016

        /// <summary>
        ///     The file replication service detected an invalid parameter.
        /// </summary>
        public const int FRS_ERR_INVALID_SERVICE_PARAMETER = 0x00001F51; // 8017

        #endregion

        #region 8200 - 8999

        /// <summary>
        ///     An error occurred while installing the directory service. For more information, see the event log.
        /// </summary>
        public const int ERROR_DS_NOT_INSTALLED = 0x00002008; // 8200

        /// <summary>
        ///     The directory service evaluated group memberships locally.
        /// </summary>
        public const int ERROR_DS_MEMBERSHIP_EVALUATED_LOCALLY = 0x00002009; // 8201

        /// <summary>
        ///     The specified directory service attribute or value does not exist.
        /// </summary>
        public const int ERROR_DS_NO_ATTRIBUTE_OR_VALUE = 0x0000200A; // 8202

        /// <summary>
        ///     The attribute syntax specified to the directory service is invalid.
        /// </summary>
        public const int ERROR_DS_INVALID_ATTRIBUTE_SYNTAX = 0x0000200B; // 8203

        /// <summary>
        ///     The attribute type specified to the directory service is not defined.
        /// </summary>
        public const int ERROR_DS_ATTRIBUTE_TYPE_UNDEFINED = 0x0000200C; // 8204

        /// <summary>
        ///     The specified directory service attribute or value already exists.
        /// </summary>
        public const int ERROR_DS_ATTRIBUTE_OR_VALUE_EXISTS = 0x0000200D; // 8205

        /// <summary>
        ///     The directory service is busy.
        /// </summary>
        public const int ERROR_DS_BUSY = 0x0000200E; // 8206

        /// <summary>
        ///     The directory service is unavailable.
        /// </summary>
        public const int ERROR_DS_UNAVAILABLE = 0x0000200F; // 8207

        /// <summary>
        ///     The directory service was unable to allocate a relative identifier.
        /// </summary>
        public const int ERROR_DS_NO_RIDS_ALLOCATED = 0x00002010; // 8208

        /// <summary>
        ///     The directory service has exhausted the pool of relative identifiers.
        /// </summary>
        public const int ERROR_DS_NO_MORE_RIDS = 0x00002011; // 8209

        /// <summary>
        ///     The requested operation could not be performed because the directory service is not the master for that type of
        ///     operation.
        /// </summary>
        public const int ERROR_DS_INCORRECT_ROLE_OWNER = 0x00002012; // 8210

        /// <summary>
        ///     The directory service was unable to initialize the subsystem that allocates relative identifiers.
        /// </summary>
        public const int ERROR_DS_RIDMGR_INIT_ERROR = 0x00002013; // 8211

        /// <summary>
        ///     The requested operation did not satisfy one or more constraints associated with the class of the object.
        /// </summary>
        public const int ERROR_DS_OBJ_CLASS_VIOLATION = 0x00002014; // 8212

        /// <summary>
        ///     The directory service can perform the requested operation only on a leaf object.
        /// </summary>
        public const int ERROR_DS_CANT_ON_NON_LEAF = 0x00002015; // 8213

        /// <summary>
        ///     The directory service cannot perform the requested operation on the RDN attribute of an object.
        /// </summary>
        public const int ERROR_DS_CANT_ON_RDN = 0x00002016; // 8214

        /// <summary>
        ///     The directory service detected an attempt to modify the object class of an object.
        /// </summary>
        public const int ERROR_DS_CANT_MOD_OBJ_CLASS = 0x00002017; // 8215

        /// <summary>
        ///     The requested cross-domain move operation could not be performed.
        /// </summary>
        public const int ERROR_DS_CROSS_DOM_MOVE_ERROR = 0x00002018; // 8216

        /// <summary>
        ///     Unable to contact the global catalog server.
        /// </summary>
        public const int ERROR_DS_GC_NOT_AVAILABLE = 0x00002019; // 8217

        /// <summary>
        ///     The policy object is shared and can only be modified at the root.
        /// </summary>
        public const int ERROR_SHARED_POLICY = 0x0000201A; // 8218

        /// <summary>
        ///     The policy object does not exist.
        /// </summary>
        public const int ERROR_POLICY_OBJECT_NOT_FOUND = 0x0000201B; // 8219

        /// <summary>
        ///     The requested policy information is only in the directory service.
        /// </summary>
        public const int ERROR_POLICY_ONLY_IN_DS = 0x0000201C; // 8220

        /// <summary>
        ///     A domain controller promotion is currently active.
        /// </summary>
        public const int ERROR_PROMOTION_ACTIVE = 0x0000201D; // 8221

        /// <summary>
        ///     A domain controller promotion is not currently active.
        /// </summary>
        public const int ERROR_NO_PROMOTION_ACTIVE = 0x0000201E; // 8222

        /// <summary>
        ///     An operations error occurred.
        /// </summary>
        public const int ERROR_DS_OPERATIONS_ERROR = 0x00002020; // 8224

        /// <summary>
        ///     A protocol error occurred.
        /// </summary>
        public const int ERROR_DS_PROTOCOL_ERROR = 0x00002021; // 8225

        /// <summary>
        ///     The time limit for this request was exceeded.
        /// </summary>
        public const int ERROR_DS_TIMELIMIT_EXCEEDED = 0x00002022; // 8226

        /// <summary>
        ///     The size limit for this request was exceeded.
        /// </summary>
        public const int ERROR_DS_SIZELIMIT_EXCEEDED = 0x00002023; // 8227

        /// <summary>
        ///     The administrative limit for this request was exceeded.
        /// </summary>
        public const int ERROR_DS_ADMIN_LIMIT_EXCEEDED = 0x00002024; // 8228

        /// <summary>
        ///     The compare response was false.
        /// </summary>
        public const int ERROR_DS_COMPARE_FALSE = 0x00002025; // 8229

        /// <summary>
        ///     The compare response was true.
        /// </summary>
        public const int ERROR_DS_COMPARE_TRUE = 0x00002026; // 8230

        /// <summary>
        ///     The requested authentication method is not supported by the server.
        /// </summary>
        public const int ERROR_DS_AUTH_METHOD_NOT_SUPPORTED = 0x00002027; // 8231

        /// <summary>
        ///     A more secure authentication method is required for this server.
        /// </summary>
        public const int ERROR_DS_STRONG_AUTH_REQUIRED = 0x00002028; // 8232

        /// <summary>
        ///     Inappropriate authentication.
        /// </summary>
        public const int ERROR_DS_INAPPROPRIATE_AUTH = 0x00002029; // 8233

        /// <summary>
        ///     The authentication mechanism is unknown.
        /// </summary>
        public const int ERROR_DS_AUTH_UNKNOWN = 0x0000202A; // 8234

        /// <summary>
        ///     A referral was returned from the server.
        /// </summary>
        public const int ERROR_DS_REFERRAL = 0x0000202B; // 8235

        /// <summary>
        ///     The server does not support the requested critical extension.
        /// </summary>
        public const int ERROR_DS_UNAVAILABLE_CRIT_EXTENSION = 0x0000202C; // 8236

        /// <summary>
        ///     This request requires a secure connection.
        /// </summary>
        public const int ERROR_DS_CONFIDENTIALITY_REQUIRED = 0x0000202D; // 8237

        /// <summary>
        ///     Inappropriate matching.
        /// </summary>
        public const int ERROR_DS_INAPPROPRIATE_MATCHING = 0x0000202E; // 8238

        /// <summary>
        ///     A constraint violation occurred.
        /// </summary>
        public const int ERROR_DS_CONSTRAINT_VIOLATION = 0x0000202F; // 8239

        /// <summary>
        ///     There is no such object on the server.
        /// </summary>
        public const int ERROR_DS_NO_SUCH_OBJECT = 0x00002030; // 8240

        /// <summary>
        ///     There is an alias problem.
        /// </summary>
        public const int ERROR_DS_ALIAS_PROBLEM = 0x00002031; // 8241

        /// <summary>
        ///     An invalid dn syntax has been specified.
        /// </summary>
        public const int ERROR_DS_INVALID_DN_SYNTAX = 0x00002032; // 8242

        /// <summary>
        ///     The object is a leaf object.
        /// </summary>
        public const int ERROR_DS_IS_LEAF = 0x00002033; // 8243

        /// <summary>
        ///     There is an alias dereferencing problem.
        /// </summary>
        public const int ERROR_DS_ALIAS_DEREF_PROBLEM = 0x00002034; // 8244

        /// <summary>
        ///     The server is unwilling to process the request.
        /// </summary>
        public const int ERROR_DS_UNWILLING_TO_PERFORM = 0x00002035; // 8245

        /// <summary>
        ///     A loop has been detected.
        /// </summary>
        public const int ERROR_DS_LOOP_DETECT = 0x00002036; // 8246

        /// <summary>
        ///     There is a naming violation.
        /// </summary>
        public const int ERROR_DS_NAMING_VIOLATION = 0x00002037; // 8247

        /// <summary>
        ///     The result set is too large.
        /// </summary>
        public const int ERROR_DS_OBJECT_RESULTS_TOO_LARGE = 0x00002038; // 8248

        /// <summary>
        ///     The operation affects multiple DSAs.
        /// </summary>
        public const int ERROR_DS_AFFECTS_MULTIPLE_DSAS = 0x00002039; // 8249

        /// <summary>
        ///     The server is not operational.
        /// </summary>
        public const int ERROR_DS_SERVER_DOWN = 0x0000203A; // 8250

        /// <summary>
        ///     A local error has occurred.
        /// </summary>
        public const int ERROR_DS_LOCAL_ERROR = 0x0000203B; // 8251

        /// <summary>
        ///     An encoding error has occurred.
        /// </summary>
        public const int ERROR_DS_ENCODING_ERROR = 0x0000203C; // 8252

        /// <summary>
        ///     A decoding error has occurred.
        /// </summary>
        public const int ERROR_DS_DECODING_ERROR = 0x0000203D; // 8253

        /// <summary>
        ///     The search filter cannot be recognized.
        /// </summary>
        public const int ERROR_DS_FILTER_UNKNOWN = 0x0000203E; // 8254

        /// <summary>
        ///     One or more parameters are illegal.
        /// </summary>
        public const int ERROR_DS_PARAM_ERROR = 0x0000203F; // 8255

        /// <summary>
        ///     The specified method is not supported.
        /// </summary>
        public const int ERROR_DS_NOT_SUPPORTED = 0x00002040; // 8256

        /// <summary>
        ///     No results were returned.
        /// </summary>
        public const int ERROR_DS_NO_RESULTS_RETURNED = 0x00002041; // 8257

        /// <summary>
        ///     The specified control is not supported by the server.
        /// </summary>
        public const int ERROR_DS_CONTROL_NOT_FOUND = 0x00002042; // 8258

        /// <summary>
        ///     A referral loop was detected by the client.
        /// </summary>
        public const int ERROR_DS_CLIENT_LOOP = 0x00002043; // 8259

        /// <summary>
        ///     The preset referral limit was exceeded.
        /// </summary>
        public const int ERROR_DS_REFERRAL_LIMIT_EXCEEDED = 0x00002044; // 8260

        /// <summary>
        ///     The search requires a SORT control.
        /// </summary>
        public const int ERROR_DS_SORT_CONTROL_MISSING = 0x00002045; // 8261

        /// <summary>
        ///     The search results exceed the offset range specified.
        /// </summary>
        public const int ERROR_DS_OFFSET_RANGE_ERROR = 0x00002046; // 8262

        /// <summary>
        ///     The directory service detected the subsystem that allocates relative identifiers is disabled. This can occur as a
        ///     protective mechanism when the system determines a significant portion of relative identifiers (RIDs) have been
        ///     exhausted. Please see http://go.microsoft.com/fwlink/p/?linkid=228610 for recommended diagnostic steps and the
        ///     procedure to re-enable account creation.
        /// </summary>
        public const int ERROR_DS_RIDMGR_DISABLED = 0x00002047; // 8263

        /// <summary>
        ///     The root object must be the head of a naming context. The root object cannot have an instantiated parent.
        /// </summary>
        public const int ERROR_DS_ROOT_MUST_BE_NC = 0x0000206D; // 8301

        /// <summary>
        ///     The add replica operation cannot be performed. The naming context must be writeable in order to create the replica.
        /// </summary>
        public const int ERROR_DS_ADD_REPLICA_INHIBITED = 0x0000206E; // 8302

        /// <summary>
        ///     A reference to an attribute that is not defined in the schema occurred.
        /// </summary>
        public const int ERROR_DS_ATT_NOT_DEF_IN_SCHEMA = 0x0000206F; // 8303

        /// <summary>
        ///     The maximum size of an object has been exceeded.
        /// </summary>
        public const int ERROR_DS_MAX_OBJ_SIZE_EXCEEDED = 0x00002070; // 8304

        /// <summary>
        ///     An attempt was made to add an object to the directory with a name that is already in use.
        /// </summary>
        public const int ERROR_DS_OBJ_STRING_NAME_EXISTS = 0x00002071; // 8305

        /// <summary>
        ///     An attempt was made to add an object of a class that does not have an RDN defined in the schema.
        /// </summary>
        public const int ERROR_DS_NO_RDN_DEFINED_IN_SCHEMA = 0x00002072; // 8306

        /// <summary>
        ///     An attempt was made to add an object using an RDN that is not the RDN defined in the schema.
        /// </summary>
        public const int ERROR_DS_RDN_DOESNT_MATCH_SCHEMA = 0x00002073; // 8307

        /// <summary>
        ///     None of the requested attributes were found on the objects.
        /// </summary>
        public const int ERROR_DS_NO_REQUESTED_ATTS_FOUND = 0x00002074; // 8308

        /// <summary>
        ///     The user buffer is too small.
        /// </summary>
        public const int ERROR_DS_USER_BUFFER_TO_SMALL = 0x00002075; // 8309

        /// <summary>
        ///     The attribute specified in the operation is not present on the object.
        /// </summary>
        public const int ERROR_DS_ATT_IS_NOT_ON_OBJ = 0x00002076; // 8310

        /// <summary>
        ///     Illegal modify operation. Some aspect of the modification is not permitted.
        /// </summary>
        public const int ERROR_DS_ILLEGAL_MOD_OPERATION = 0x00002077; // 8311

        /// <summary>
        ///     The specified object is too large.
        /// </summary>
        public const int ERROR_DS_OBJ_TOO_LARGE = 0x00002078; // 8312

        /// <summary>
        ///     The specified instance type is not valid.
        /// </summary>
        public const int ERROR_DS_BAD_INSTANCE_TYPE = 0x00002079; // 8313

        /// <summary>
        ///     The operation must be performed at a master DSA.
        /// </summary>
        public const int ERROR_DS_MASTERDSA_REQUIRED = 0x0000207A; // 8314

        /// <summary>
        ///     The object class attribute must be specified.
        /// </summary>
        public const int ERROR_DS_OBJECT_CLASS_REQUIRED = 0x0000207B; // 8315

        /// <summary>
        ///     A required attribute is missing.
        /// </summary>
        public const int ERROR_DS_MISSING_REQUIRED_ATT = 0x0000207C; // 8316

        /// <summary>
        ///     An attempt was made to modify an object to include an attribute that is not legal for its class.
        /// </summary>
        public const int ERROR_DS_ATT_NOT_DEF_FOR_CLASS = 0x0000207D; // 8317

        /// <summary>
        ///     The specified attribute is already present on the object.
        /// </summary>
        public const int ERROR_DS_ATT_ALREADY_EXISTS = 0x0000207E; // 8318

        /// <summary>
        ///     The specified attribute is not present, or has no values.
        /// </summary>
        public const int ERROR_DS_CANT_ADD_ATT_VALUES = 0x00002080; // 8320

        /// <summary>
        ///     Multiple values were specified for an attribute that can have only one value.
        /// </summary>
        public const int ERROR_DS_SINGLE_VALUE_CONSTRAINT = 0x00002081; // 8321

        /// <summary>
        ///     A value for the attribute was not in the acceptable range of values.
        /// </summary>
        public const int ERROR_DS_RANGE_CONSTRAINT = 0x00002082; // 8322

        /// <summary>
        ///     The specified value already exists.
        /// </summary>
        public const int ERROR_DS_ATT_VAL_ALREADY_EXISTS = 0x00002083; // 8323

        /// <summary>
        ///     The attribute cannot be removed because it is not present on the object.
        /// </summary>
        public const int ERROR_DS_CANT_REM_MISSING_ATT = 0x00002084; // 8324

        /// <summary>
        ///     The attribute value cannot be removed because it is not present on the object.
        /// </summary>
        public const int ERROR_DS_CANT_REM_MISSING_ATT_VAL = 0x00002085; // 8325

        /// <summary>
        ///     The specified root object cannot be a subref.
        /// </summary>
        public const int ERROR_DS_ROOT_CANT_BE_SUBREF = 0x00002086; // 8326

        /// <summary>
        ///     Chaining is not permitted.
        /// </summary>
        public const int ERROR_DS_NO_CHAINING = 0x00002087; // 8327

        /// <summary>
        ///     Chained evaluation is not permitted.
        /// </summary>
        public const int ERROR_DS_NO_CHAINED_EVAL = 0x00002088; // 8328

        /// <summary>
        ///     The operation could not be performed because the object's parent is either uninstantiated or deleted.
        /// </summary>
        public const int ERROR_DS_NO_PARENT_OBJECT = 0x00002089; // 8329

        /// <summary>
        ///     Having a parent that is an alias is not permitted. Aliases are leaf objects.
        /// </summary>
        public const int ERROR_DS_PARENT_IS_AN_ALIAS = 0x0000208A; // 8330

        /// <summary>
        ///     The object and parent must be of the same type, either both masters or both replicas.
        /// </summary>
        public const int ERROR_DS_CANT_MIX_MASTER_AND_REPS = 0x0000208B; // 8331

        /// <summary>
        ///     The operation cannot be performed because child objects exist. This operation can only be performed on a leaf
        ///     object.
        /// </summary>
        public const int ERROR_DS_CHILDREN_EXIST = 0x0000208C; // 8332

        /// <summary>
        ///     Directory object not found.
        /// </summary>
        public const int ERROR_DS_OBJ_NOT_FOUND = 0x0000208D; // 8333

        /// <summary>
        ///     The aliased object is missing.
        /// </summary>
        public const int ERROR_DS_ALIASED_OBJ_MISSING = 0x0000208E; // 8334

        /// <summary>
        ///     The object name has bad syntax.
        /// </summary>
        public const int ERROR_DS_BAD_NAME_SYNTAX = 0x0000208F; // 8335

        /// <summary>
        ///     It is not permitted for an alias to refer to another alias.
        /// </summary>
        public const int ERROR_DS_ALIAS_POINTS_TO_ALIAS = 0x00002090; // 8336

        /// <summary>
        ///     The alias cannot be dereferenced.
        /// </summary>
        public const int ERROR_DS_CANT_DEREF_ALIAS = 0x00002091; // 8337

        /// <summary>
        ///     The operation is out of scope.
        /// </summary>
        public const int ERROR_DS_OUT_OF_SCOPE = 0x00002092; // 8338

        /// <summary>
        ///     The operation cannot continue because the object is in the process of being removed.
        /// </summary>
        public const int ERROR_DS_OBJECT_BEING_REMOVED = 0x00002093; // 8339

        /// <summary>
        ///     The DSA object cannot be deleted.
        /// </summary>
        public const int ERROR_DS_CANT_DELETE_DSA_OBJ = 0x00002094; // 8340

        /// <summary>
        ///     A directory service error has occurred.
        /// </summary>
        public const int ERROR_DS_GENERIC_ERROR = 0x00002095; // 8341

        /// <summary>
        ///     The operation can only be performed on an internal master DSA object.
        /// </summary>
        public const int ERROR_DS_DSA_MUST_BE_INT_MASTER = 0x00002096; // 8342

        /// <summary>
        ///     The object must be of class DSA.
        /// </summary>
        public const int ERROR_DS_CLASS_NOT_DSA = 0x00002097; // 8343

        /// <summary>
        ///     Insufficient access rights to perform the operation.
        /// </summary>
        public const int ERROR_DS_INSUFF_ACCESS_RIGHTS = 0x00002098; // 8344

        /// <summary>
        ///     The object cannot be added because the parent is not on the list of possible superiors.
        /// </summary>
        public const int ERROR_DS_ILLEGAL_SUPERIOR = 0x00002099; // 8345

        /// <summary>
        ///     Access to the attribute is not permitted because the attribute is owned by the Security Accounts Manager (SAM).
        /// </summary>
        public const int ERROR_DS_ATTRIBUTE_OWNED_BY_SAM = 0x0000209A; // 8346

        /// <summary>
        ///     The name has too many parts.
        /// </summary>
        public const int ERROR_DS_NAME_TOO_MANY_PARTS = 0x0000209B; // 8347

        /// <summary>
        ///     The name is too long.
        /// </summary>
        public const int ERROR_DS_NAME_TOO_LONG = 0x0000209C; // 8348

        /// <summary>
        ///     The name value is too long.
        /// </summary>
        public const int ERROR_DS_NAME_VALUE_TOO_LONG = 0x0000209D; // 8349

        /// <summary>
        ///     The directory service encountered an error parsing a name.
        /// </summary>
        public const int ERROR_DS_NAME_UNPARSEABLE = 0x0000209E; // 8350

        /// <summary>
        ///     The directory service cannot get the attribute type for a name.
        /// </summary>
        public const int ERROR_DS_NAME_TYPE_UNKNOWN = 0x0000209F; // 8351

        /// <summary>
        ///     The name does not identify an object; the name identifies a phantom.
        /// </summary>
        public const int ERROR_DS_NOT_AN_OBJECT = 0x000020A0; // 8352

        /// <summary>
        ///     The security descriptor is too short.
        /// </summary>
        public const int ERROR_DS_SEC_DESC_TOO_SHORT = 0x000020A1; // 8353

        /// <summary>
        ///     The security descriptor is invalid.
        /// </summary>
        public const int ERROR_DS_SEC_DESC_INVALID = 0x000020A2; // 8354

        /// <summary>
        ///     Failed to create name for deleted object.
        /// </summary>
        public const int ERROR_DS_NO_DELETED_NAME = 0x000020A3; // 8355

        /// <summary>
        ///     The parent of a new subref must exist.
        /// </summary>
        public const int ERROR_DS_SUBREF_MUST_HAVE_PARENT = 0x000020A4; // 8356

        /// <summary>
        ///     The object must be a naming context.
        /// </summary>
        public const int ERROR_DS_NCNAME_MUST_BE_NC = 0x000020A5; // 8357

        /// <summary>
        ///     It is not permitted to add an attribute which is owned by the system.
        /// </summary>
        public const int ERROR_DS_CANT_ADD_SYSTEM_ONLY = 0x000020A6; // 8358

        /// <summary>
        ///     The class of the object must be structural; you cannot instantiate an abstract class.
        /// </summary>
        public const int ERROR_DS_CLASS_MUST_BE_CONCRETE = 0x000020A7; // 8359

        /// <summary>
        ///     The schema object could not be found.
        /// </summary>
        public const int ERROR_DS_INVALID_DMD = 0x000020A8; // 8360

        /// <summary>
        ///     A local object with this GUID (dead or alive) already exists.
        /// </summary>
        public const int ERROR_DS_OBJ_GUID_EXISTS = 0x000020A9; // 8361

        /// <summary>
        ///     The operation cannot be performed on a back link.
        /// </summary>
        public const int ERROR_DS_NOT_ON_BACKLINK = 0x000020AA; // 8362

        /// <summary>
        ///     The cross reference for the specified naming context could not be found.
        /// </summary>
        public const int ERROR_DS_NO_CROSSREF_FOR_NC = 0x000020AB; // 8363

        /// <summary>
        ///     The operation could not be performed because the directory service is shutting down.
        /// </summary>
        public const int ERROR_DS_SHUTTING_DOWN = 0x000020AC; // 8364

        /// <summary>
        ///     The directory service request is invalid.
        /// </summary>
        public const int ERROR_DS_UNKNOWN_OPERATION = 0x000020AD; // 8365

        /// <summary>
        ///     The role owner attribute could not be read.
        /// </summary>
        public const int ERROR_DS_INVALID_ROLE_OWNER = 0x000020AE; // 8366

        /// <summary>
        ///     The requested FSMO operation failed. The current FSMO holder could not be contacted.
        /// </summary>
        public const int ERROR_DS_COULDNT_CONTACT_FSMO = 0x000020AF; // 8367

        /// <summary>
        ///     Modification of a DN across a naming context is not permitted.
        /// </summary>
        public const int ERROR_DS_CROSS_NC_DN_RENAME = 0x000020B0; // 8368

        /// <summary>
        ///     The attribute cannot be modified because it is owned by the system.
        /// </summary>
        public const int ERROR_DS_CANT_MOD_SYSTEM_ONLY = 0x000020B1; // 8369

        /// <summary>
        ///     Only the replicator can perform this function.
        /// </summary>
        public const int ERROR_DS_REPLICATOR_ONLY = 0x000020B2; // 8370

        /// <summary>
        ///     The specified class is not defined.
        /// </summary>
        public const int ERROR_DS_OBJ_CLASS_NOT_DEFINED = 0x000020B3; // 8371

        /// <summary>
        ///     The specified class is not a subclass.
        /// </summary>
        public const int ERROR_DS_OBJ_CLASS_NOT_SUBCLASS = 0x000020B4; // 8372

        /// <summary>
        ///     The name reference is invalid.
        /// </summary>
        public const int ERROR_DS_NAME_REFERENCE_INVALID = 0x000020B5; // 8373

        /// <summary>
        ///     A cross reference already exists.
        /// </summary>
        public const int ERROR_DS_CROSS_REF_EXISTS = 0x000020B6; // 8374

        /// <summary>
        ///     It is not permitted to delete a master cross reference.
        /// </summary>
        public const int ERROR_DS_CANT_DEL_MASTER_CROSSREF = 0x000020B7; // 8375

        /// <summary>
        ///     Subtree notifications are only supported on NC heads.
        /// </summary>
        public const int ERROR_DS_SUBTREE_NOTIFY_NOT_NC_HEAD = 0x000020B8; // 8376

        /// <summary>
        ///     Notification filter is too complex.
        /// </summary>
        public const int ERROR_DS_NOTIFY_FILTER_TOO_COMPLEX = 0x000020B9; // 8377

        /// <summary>
        ///     Schema update failed: duplicate RDN.
        /// </summary>
        public const int ERROR_DS_DUP_RDN = 0x000020BA; // 8378

        /// <summary>
        ///     Schema update failed: duplicate OID.
        /// </summary>
        public const int ERROR_DS_DUP_OID = 0x000020BB; // 8379

        /// <summary>
        ///     Schema update failed: duplicate MAPI identifier.
        /// </summary>
        public const int ERROR_DS_DUP_MAPI_ID = 0x000020BC; // 8380

        /// <summary>
        ///     Schema update failed: duplicate schema-id GUID.
        /// </summary>
        public const int ERROR_DS_DUP_SCHEMA_ID_GUID = 0x000020BD; // 8381

        /// <summary>
        ///     Schema update failed: duplicate LDAP display name.
        /// </summary>
        public const int ERROR_DS_DUP_LDAP_DISPLAY_NAME = 0x000020BE; // 8382

        /// <summary>
        ///     Schema update failed: range-lower less than range upper.
        /// </summary>
        public const int ERROR_DS_SEMANTIC_ATT_TEST = 0x000020BF; // 8383

        /// <summary>
        ///     Schema update failed: syntax mismatch.
        /// </summary>
        public const int ERROR_DS_SYNTAX_MISMATCH = 0x000020C0; // 8384

        /// <summary>
        ///     Schema deletion failed: attribute is used in must-contain.
        /// </summary>
        public const int ERROR_DS_EXISTS_IN_MUST_HAVE = 0x000020C1; // 8385

        /// <summary>
        ///     Schema deletion failed: attribute is used in may-contain.
        /// </summary>
        public const int ERROR_DS_EXISTS_IN_MAY_HAVE = 0x000020C2; // 8386

        /// <summary>
        ///     Schema update failed: attribute in may-contain does not exist.
        /// </summary>
        public const int ERROR_DS_NONEXISTENT_MAY_HAVE = 0x000020C3; // 8387

        /// <summary>
        ///     Schema update failed: attribute in must-contain does not exist.
        /// </summary>
        public const int ERROR_DS_NONEXISTENT_MUST_HAVE = 0x000020C4; // 8388

        /// <summary>
        ///     Schema update failed: class in aux-class list does not exist or is not an auxiliary class.
        /// </summary>
        public const int ERROR_DS_AUX_CLS_TEST_FAIL = 0x000020C5; // 8389

        /// <summary>
        ///     Schema update failed: class in poss-superiors does not exist.
        /// </summary>
        public const int ERROR_DS_NONEXISTENT_POSS_SUP = 0x000020C6; // 8390

        /// <summary>
        ///     Schema update failed: class in subclassof list does not exist or does not satisfy hierarchy rules.
        /// </summary>
        public const int ERROR_DS_SUB_CLS_TEST_FAIL = 0x000020C7; // 8391

        /// <summary>
        ///     Schema update failed: Rdn-Att-Id has wrong syntax.
        /// </summary>
        public const int ERROR_DS_BAD_RDN_ATT_ID_SYNTAX = 0x000020C8; // 8392

        /// <summary>
        ///     Schema deletion failed: class is used as auxiliary class.
        /// </summary>
        public const int ERROR_DS_EXISTS_IN_AUX_CLS = 0x000020C9; // 8393

        /// <summary>
        ///     Schema deletion failed: class is used as sub class.
        /// </summary>
        public const int ERROR_DS_EXISTS_IN_SUB_CLS = 0x000020CA; // 8394

        /// <summary>
        ///     Schema deletion failed: class is used as poss superior.
        /// </summary>
        public const int ERROR_DS_EXISTS_IN_POSS_SUP = 0x000020CB; // 8395

        /// <summary>
        ///     Schema update failed in recalculating validation cache.
        /// </summary>
        public const int ERROR_DS_RECALCSCHEMA_FAILED = 0x000020CC; // 8396

        /// <summary>
        ///     The tree deletion is not finished. The request must be made again to continue deleting the tree.
        /// </summary>
        public const int ERROR_DS_TREE_DELETE_NOT_FINISHED = 0x000020CD; // 8397

        /// <summary>
        ///     The requested delete operation could not be performed.
        /// </summary>
        public const int ERROR_DS_CANT_DELETE = 0x000020CE; // 8398

        /// <summary>
        ///     Cannot read the governs class identifier for the schema record.
        /// </summary>
        public const int ERROR_DS_ATT_SCHEMA_REQ_ID = 0x000020CF; // 8399

        /// <summary>
        ///     The attribute schema has bad syntax.
        /// </summary>
        public const int ERROR_DS_BAD_ATT_SCHEMA_SYNTAX = 0x000020D0; // 8400

        /// <summary>
        ///     The attribute could not be cached.
        /// </summary>
        public const int ERROR_DS_CANT_CACHE_ATT = 0x000020D1; // 8401

        /// <summary>
        ///     The class could not be cached.
        /// </summary>
        public const int ERROR_DS_CANT_CACHE_CLASS = 0x000020D2; // 8402

        /// <summary>
        ///     The attribute could not be removed from the cache.
        /// </summary>
        public const int ERROR_DS_CANT_REMOVE_ATT_CACHE = 0x000020D3; // 8403

        /// <summary>
        ///     The class could not be removed from the cache.
        /// </summary>
        public const int ERROR_DS_CANT_REMOVE_CLASS_CACHE = 0x000020D4; // 8404

        /// <summary>
        ///     The distinguished name attribute could not be read.
        /// </summary>
        public const int ERROR_DS_CANT_RETRIEVE_DN = 0x000020D5; // 8405

        /// <summary>
        ///     No superior reference has been configured for the directory service. The directory service is therefore unable to
        ///     issue referrals to objects outside this forest.
        /// </summary>
        public const int ERROR_DS_MISSING_SUPREF = 0x000020D6; // 8406

        /// <summary>
        ///     The instance type attribute could not be retrieved.
        /// </summary>
        public const int ERROR_DS_CANT_RETRIEVE_INSTANCE = 0x000020D7; // 8407

        /// <summary>
        ///     An internal error has occurred.
        /// </summary>
        public const int ERROR_DS_CODE_INCONSISTENCY = 0x000020D8; // 8408

        /// <summary>
        ///     A database error has occurred.
        /// </summary>
        public const int ERROR_DS_DATABASE_ERROR = 0x000020D9; // 8409

        /// <summary>
        ///     The attribute GOVERNSID is missing.
        /// </summary>
        public const int ERROR_DS_GOVERNSID_MISSING = 0x000020DA; // 8410

        /// <summary>
        ///     An expected attribute is missing.
        /// </summary>
        public const int ERROR_DS_MISSING_EXPECTED_ATT = 0x000020DB; // 8411

        /// <summary>
        ///     The specified naming context is missing a cross reference.
        /// </summary>
        public const int ERROR_DS_NCNAME_MISSING_CR_REF = 0x000020DC; // 8412

        /// <summary>
        ///     A security checking error has occurred.
        /// </summary>
        public const int ERROR_DS_SECURITY_CHECKING_ERROR = 0x000020DD; // 8413

        /// <summary>
        ///     The schema is not loaded.
        /// </summary>
        public const int ERROR_DS_SCHEMA_NOT_LOADED = 0x000020DE; // 8414

        /// <summary>
        ///     Schema allocation failed. Please check if the machine is running low on memory.
        /// </summary>
        public const int ERROR_DS_SCHEMA_ALLOC_FAILED = 0x000020DF; // 8415

        /// <summary>
        ///     Failed to obtain the required syntax for the attribute schema.
        /// </summary>
        public const int ERROR_DS_ATT_SCHEMA_REQ_SYNTAX = 0x000020E0; // 8416

        /// <summary>
        ///     The global catalog verification failed. The global catalog is not available or does not support the operation. Some
        ///     part of the directory is currently not available.
        /// </summary>
        public const int ERROR_DS_GCVERIFY_ERROR = 0x000020E1; // 8417

        /// <summary>
        ///     The replication operation failed because of a schema mismatch between the servers involved.
        /// </summary>
        public const int ERROR_DS_DRA_SCHEMA_MISMATCH = 0x000020E2; // 8418

        /// <summary>
        ///     The DSA object could not be found.
        /// </summary>
        public const int ERROR_DS_CANT_FIND_DSA_OBJ = 0x000020E3; // 8419

        /// <summary>
        ///     The naming context could not be found.
        /// </summary>
        public const int ERROR_DS_CANT_FIND_EXPECTED_NC = 0x000020E4; // 8420

        /// <summary>
        ///     The naming context could not be found in the cache.
        /// </summary>
        public const int ERROR_DS_CANT_FIND_NC_IN_CACHE = 0x000020E5; // 8421

        /// <summary>
        ///     The child object could not be retrieved.
        /// </summary>
        public const int ERROR_DS_CANT_RETRIEVE_CHILD = 0x000020E6; // 8422

        /// <summary>
        ///     The modification was not permitted for security reasons.
        /// </summary>
        public const int ERROR_DS_SECURITY_ILLEGAL_MODIFY = 0x000020E7; // 8423

        /// <summary>
        ///     The operation cannot replace the hidden record.
        /// </summary>
        public const int ERROR_DS_CANT_REPLACE_HIDDEN_REC = 0x000020E8; // 8424

        /// <summary>
        ///     The hierarchy file is invalid.
        /// </summary>
        public const int ERROR_DS_BAD_HIERARCHY_FILE = 0x000020E9; // 8425

        /// <summary>
        ///     The attempt to build the hierarchy table failed.
        /// </summary>
        public const int ERROR_DS_BUILD_HIERARCHY_TABLE_FAILED = 0x000020EA; // 8426

        /// <summary>
        ///     The directory configuration parameter is missing from the registry.
        /// </summary>
        public const int ERROR_DS_CONFIG_PARAM_MISSING = 0x000020EB; // 8427

        /// <summary>
        ///     The attempt to count the address book indices failed.
        /// </summary>
        public const int ERROR_DS_COUNTING_AB_INDICES_FAILED = 0x000020EC; // 8428

        /// <summary>
        ///     The allocation of the hierarchy table failed.
        /// </summary>
        public const int ERROR_DS_HIERARCHY_TABLE_MALLOC_FAILED = 0x000020ED; // 8429

        /// <summary>
        ///     The directory service encountered an internal failure.
        /// </summary>
        public const int ERROR_DS_INTERNAL_FAILURE = 0x000020EE; // 8430

        /// <summary>
        ///     The directory service encountered an unknown failure.
        /// </summary>
        public const int ERROR_DS_UNKNOWN_ERROR = 0x000020EF; // 8431

        /// <summary>
        ///     A root object requires a class of 'top'.
        /// </summary>
        public const int ERROR_DS_ROOT_REQUIRES_CLASS_TOP = 0x000020F0; // 8432

        /// <summary>
        ///     This directory server is shutting down, and cannot take ownership of new floating single-master operation roles.
        /// </summary>
        public const int ERROR_DS_REFUSING_FSMO_ROLES = 0x000020F1; // 8433

        /// <summary>
        ///     The directory service is missing mandatory configuration information, and is unable to determine the ownership of
        ///     floating single-master operation roles.
        /// </summary>
        public const int ERROR_DS_MISSING_FSMO_SETTINGS = 0x000020F2; // 8434

        /// <summary>
        ///     The directory service was unable to transfer ownership of one or more floating single-master operation roles to
        ///     other servers.
        /// </summary>
        public const int ERROR_DS_UNABLE_TO_SURRENDER_ROLES = 0x000020F3; // 8435

        /// <summary>
        ///     The replication operation failed.
        /// </summary>
        public const int ERROR_DS_DRA_GENERIC = 0x000020F4; // 8436

        /// <summary>
        ///     An invalid parameter was specified for this replication operation.
        /// </summary>
        public const int ERROR_DS_DRA_INVALID_PARAMETER = 0x000020F5; // 8437

        /// <summary>
        ///     The directory service is too busy to complete the replication operation at this time.
        /// </summary>
        public const int ERROR_DS_DRA_BUSY = 0x000020F6; // 8438

        /// <summary>
        ///     The distinguished name specified for this replication operation is invalid.
        /// </summary>
        public const int ERROR_DS_DRA_BAD_DN = 0x000020F7; // 8439

        /// <summary>
        ///     The naming context specified for this replication operation is invalid.
        /// </summary>
        public const int ERROR_DS_DRA_BAD_NC = 0x000020F8; // 8440

        /// <summary>
        ///     The distinguished name specified for this replication operation already exists.
        /// </summary>
        public const int ERROR_DS_DRA_DN_EXISTS = 0x000020F9; // 8441

        /// <summary>
        ///     The replication system encountered an internal error.
        /// </summary>
        public const int ERROR_DS_DRA_INTERNAL_ERROR = 0x000020FA; // 8442

        /// <summary>
        ///     The replication operation encountered a database inconsistency.
        /// </summary>
        public const int ERROR_DS_DRA_INCONSISTENT_DIT = 0x000020FB; // 8443

        /// <summary>
        ///     The server specified for this replication operation could not be contacted.
        /// </summary>
        public const int ERROR_DS_DRA_CONNECTION_FAILED = 0x000020FC; // 8444

        /// <summary>
        ///     The replication operation encountered an object with an invalid instance type.
        /// </summary>
        public const int ERROR_DS_DRA_BAD_INSTANCE_TYPE = 0x000020FD; // 8445

        /// <summary>
        ///     The replication operation failed to allocate memory.
        /// </summary>
        public const int ERROR_DS_DRA_OUT_OF_MEM = 0x000020FE; // 8446

        /// <summary>
        ///     The replication operation encountered an error with the mail system.
        /// </summary>
        public const int ERROR_DS_DRA_MAIL_PROBLEM = 0x000020FF; // 8447

        /// <summary>
        ///     The replication reference information for the target server already exists.
        /// </summary>
        public const int ERROR_DS_DRA_REF_ALREADY_EXISTS = 0x00002100; // 8448

        /// <summary>
        ///     The replication reference information for the target server does not exist.
        /// </summary>
        public const int ERROR_DS_DRA_REF_NOT_FOUND = 0x00002101; // 8449

        /// <summary>
        ///     The naming context cannot be removed because it is replicated to another server.
        /// </summary>
        public const int ERROR_DS_DRA_OBJ_IS_REP_SOURCE = 0x00002102; // 8450

        /// <summary>
        ///     The replication operation encountered a database error.
        /// </summary>
        public const int ERROR_DS_DRA_DB_ERROR = 0x00002103; // 8451

        /// <summary>
        ///     The naming context is in the process of being removed or is not replicated from the specified server.
        /// </summary>
        public const int ERROR_DS_DRA_NO_REPLICA = 0x00002104; // 8452

        /// <summary>
        ///     Replication access was denied.
        /// </summary>
        public const int ERROR_DS_DRA_ACCESS_DENIED = 0x00002105; // 8453

        /// <summary>
        ///     The requested operation is not supported by this version of the directory service.
        /// </summary>
        public const int ERROR_DS_DRA_NOT_SUPPORTED = 0x00002106; // 8454

        /// <summary>
        ///     The replication remote procedure call was cancelled.
        /// </summary>
        public const int ERROR_DS_DRA_RPC_CANCELLED = 0x00002107; // 8455

        /// <summary>
        ///     The source server is currently rejecting replication requests.
        /// </summary>
        public const int ERROR_DS_DRA_SOURCE_DISABLED = 0x00002108; // 8456

        /// <summary>
        ///     The destination server is currently rejecting replication requests.
        /// </summary>
        public const int ERROR_DS_DRA_SINK_DISABLED = 0x00002109; // 8457

        /// <summary>
        ///     The replication operation failed due to a collision of object names.
        /// </summary>
        public const int ERROR_DS_DRA_NAME_COLLISION = 0x0000210A; // 8458

        /// <summary>
        ///     The replication source has been reinstalled.
        /// </summary>
        public const int ERROR_DS_DRA_SOURCE_REINSTALLED = 0x0000210B; // 8459

        /// <summary>
        ///     The replication operation failed because a required parent object is missing.
        /// </summary>
        public const int ERROR_DS_DRA_MISSING_PARENT = 0x0000210C; // 8460

        /// <summary>
        ///     The replication operation was preempted.
        /// </summary>
        public const int ERROR_DS_DRA_PREEMPTED = 0x0000210D; // 8461

        /// <summary>
        ///     The replication synchronization attempt was abandoned because of a lack of updates.
        /// </summary>
        public const int ERROR_DS_DRA_ABANDON_SYNC = 0x0000210E; // 8462

        /// <summary>
        ///     The replication operation was terminated because the system is shutting down.
        /// </summary>
        public const int ERROR_DS_DRA_SHUTDOWN = 0x0000210F; // 8463

        /// <summary>
        ///     Synchronization attempt failed because the destination DC is currently waiting to synchronize new partial
        ///     attributes from source. This condition is normal if a recent schema change modified the partial attribute set. The
        ///     destination partial attribute set is not a subset of source partial attribute set.
        /// </summary>
        public const int ERROR_DS_DRA_INCOMPATIBLE_PARTIAL_SET = 0x00002110; // 8464

        /// <summary>
        ///     The replication synchronization attempt failed because a master replica attempted to sync from a partial replica.
        /// </summary>
        public const int ERROR_DS_DRA_SOURCE_IS_PARTIAL_REPLICA = 0x00002111; // 8465

        /// <summary>
        ///     The server specified for this replication operation was contacted, but that server was unable to contact an
        ///     additional server needed to complete the operation.
        /// </summary>
        public const int ERROR_DS_DRA_EXTN_CONNECTION_FAILED = 0x00002112; // 8466

        /// <summary>
        ///     The version of the directory service schema of the source forest is not compatible with the version of directory
        ///     service on this computer.
        /// </summary>
        public const int ERROR_DS_INSTALL_SCHEMA_MISMATCH = 0x00002113; // 8467

        /// <summary>
        ///     Schema update failed: An attribute with the same link identifier already exists.
        /// </summary>
        public const int ERROR_DS_DUP_LINK_ID = 0x00002114; // 8468

        /// <summary>
        ///     Name translation: Generic processing error.
        /// </summary>
        public const int ERROR_DS_NAME_ERROR_RESOLVING = 0x00002115; // 8469

        /// <summary>
        ///     Name translation: Could not find the name or insufficient right to see name.
        /// </summary>
        public const int ERROR_DS_NAME_ERROR_NOT_FOUND = 0x00002116; // 8470

        /// <summary>
        ///     Name translation: Input name mapped to more than one output name.
        /// </summary>
        public const int ERROR_DS_NAME_ERROR_NOT_UNIQUE = 0x00002117; // 8471

        /// <summary>
        ///     Name translation: Input name found, but not the associated output format.
        /// </summary>
        public const int ERROR_DS_NAME_ERROR_NO_MAPPING = 0x00002118; // 8472

        /// <summary>
        ///     Name translation: Unable to resolve completely, only the domain was found.
        /// </summary>
        public const int ERROR_DS_NAME_ERROR_DOMAIN_ONLY = 0x00002119; // 8473

        /// <summary>
        ///     Name translation: Unable to perform purely syntactical mapping at the client without going out to the wire.
        /// </summary>
        public const int ERROR_DS_NAME_ERROR_NO_SYNTACTICAL_MAPPING = 0x0000211A; // 8474

        /// <summary>
        ///     Modification of a constructed attribute is not allowed.
        /// </summary>
        public const int ERROR_DS_CONSTRUCTED_ATT_MOD = 0x0000211B; // 8475

        /// <summary>
        ///     The OM-Object-Class specified is incorrect for an attribute with the specified syntax.
        /// </summary>
        public const int ERROR_DS_WRONG_OM_OBJ_CLASS = 0x0000211C; // 8476

        /// <summary>
        ///     The replication request has been posted; waiting for reply.
        /// </summary>
        public const int ERROR_DS_DRA_REPL_PENDING = 0x0000211D; // 8477

        /// <summary>
        ///     The requested operation requires a directory service, and none was available.
        /// </summary>
        public const int ERROR_DS_DS_REQUIRED = 0x0000211E; // 8478

        /// <summary>
        ///     The LDAP display name of the class or attribute contains non-ASCII characters.
        /// </summary>
        public const int ERROR_DS_INVALID_LDAP_DISPLAY_NAME = 0x0000211F; // 8479

        /// <summary>
        ///     The requested search operation is only supported for base searches.
        /// </summary>
        public const int ERROR_DS_NON_BASE_SEARCH = 0x00002120; // 8480

        /// <summary>
        ///     The search failed to retrieve attributes from the database.
        /// </summary>
        public const int ERROR_DS_CANT_RETRIEVE_ATTS = 0x00002121; // 8481

        /// <summary>
        ///     The schema update operation tried to add a backward link attribute that has no corresponding forward link.
        /// </summary>
        public const int ERROR_DS_BACKLINK_WITHOUT_LINK = 0x00002122; // 8482

        /// <summary>
        ///     Source and destination of a cross-domain move do not agree on the object's epoch number. Either source or
        ///     destination does not have the latest version of the object.
        /// </summary>
        public const int ERROR_DS_EPOCH_MISMATCH = 0x00002123; // 8483

        /// <summary>
        ///     Source and destination of a cross-domain move do not agree on the object's current name. Either source or
        ///     destination does not have the latest version of the object.
        /// </summary>
        public const int ERROR_DS_SRC_NAME_MISMATCH = 0x00002124; // 8484

        /// <summary>
        ///     Source and destination for the cross-domain move operation are identical. Caller should use local move operation
        ///     instead of cross-domain move operation.
        /// </summary>
        public const int ERROR_DS_SRC_AND_DST_NC_IDENTICAL = 0x00002125; // 8485

        /// <summary>
        ///     Source and destination for a cross-domain move are not in agreement on the naming contexts in the forest. Either
        ///     source or destination does not have the latest version of the Partitions container.
        /// </summary>
        public const int ERROR_DS_DST_NC_MISMATCH = 0x00002126; // 8486

        /// <summary>
        ///     Destination of a cross-domain move is not authoritative for the destination naming context.
        /// </summary>
        public const int ERROR_DS_NOT_AUTHORITIVE_FOR_DST_NC = 0x00002127; // 8487

        /// <summary>
        ///     Source and destination of a cross-domain move do not agree on the identity of the source object. Either source or
        ///     destination does not have the latest version of the source object.
        /// </summary>
        public const int ERROR_DS_SRC_GUID_MISMATCH = 0x00002128; // 8488

        /// <summary>
        ///     Object being moved across-domains is already known to be deleted by the destination server. The source server does
        ///     not have the latest version of the source object.
        /// </summary>
        public const int ERROR_DS_CANT_MOVE_DELETED_OBJECT = 0x00002129; // 8489

        /// <summary>
        ///     Another operation which requires exclusive access to the PDC FSMO is already in progress.
        /// </summary>
        public const int ERROR_DS_PDC_OPERATION_IN_PROGRESS = 0x0000212A; // 8490

        /// <summary>
        ///     A cross-domain move operation failed such that two versions of the moved object exist - one each in the source and
        ///     destination domains. The destination object needs to be removed to restore the system to a consistent state.
        /// </summary>
        public const int ERROR_DS_CROSS_DOMAIN_CLEANUP_REQD = 0x0000212B; // 8491

        /// <summary>
        ///     This object may not be moved across domain boundaries either because cross-domain moves for this class are
        ///     disallowed, or the object has some special characteristics, e.g.: trust account or restricted RID, which prevent
        ///     its move.
        /// </summary>
        public const int ERROR_DS_ILLEGAL_XDOM_MOVE_OPERATION = 0x0000212C; // 8492

        /// <summary>
        ///     Can't move objects with memberships across domain boundaries as once moved, this would violate the membership
        ///     conditions of the account group. Remove the object from any account group memberships and retry.
        /// </summary>
        public const int ERROR_DS_CANT_WITH_ACCT_GROUP_MEMBERSHPS = 0x0000212D; // 8493

        /// <summary>
        ///     A naming context head must be the immediate child of another naming context head, not of an interior node.
        /// </summary>
        public const int ERROR_DS_NC_MUST_HAVE_NC_PARENT = 0x0000212E; // 8494

        /// <summary>
        ///     The directory cannot validate the proposed naming context name because it does not hold a replica of the naming
        ///     context above the proposed naming context. Please ensure that the domain naming master role is held by a server
        ///     that is configured as a global catalog server, and that the server is up to date with its replication partners.
        ///     (Applies only to Windows 2000 Domain Naming masters.)
        /// </summary>
        public const int ERROR_DS_CR_IMPOSSIBLE_TO_VALIDATE = 0x0000212F; // 8495

        /// <summary>
        ///     Destination domain must be in native mode.
        /// </summary>
        public const int ERROR_DS_DST_DOMAIN_NOT_NATIVE = 0x00002130; // 8496

        /// <summary>
        ///     The operation cannot be performed because the server does not have an infrastructure container in the domain of
        ///     interest.
        /// </summary>
        public const int ERROR_DS_MISSING_INFRASTRUCTURE_CONTAINER = 0x00002131; // 8497

        /// <summary>
        ///     Cross-domain move of non-empty account groups is not allowed.
        /// </summary>
        public const int ERROR_DS_CANT_MOVE_ACCOUNT_GROUP = 0x00002132; // 8498

        /// <summary>
        ///     Cross-domain move of non-empty resource groups is not allowed.
        /// </summary>
        public const int ERROR_DS_CANT_MOVE_RESOURCE_GROUP = 0x00002133; // 8499

        /// <summary>
        ///     The search flags for the attribute are invalid. The ANR bit is valid only on attributes of Unicode or Teletex
        ///     strings.
        /// </summary>
        public const int ERROR_DS_INVALID_SEARCH_FLAG = 0x00002134; // 8500

        /// <summary>
        ///     Tree deletions starting at an object which has an NC head as a descendant are not allowed.
        /// </summary>
        public const int ERROR_DS_NO_TREE_DELETE_ABOVE_NC = 0x00002135; // 8501

        /// <summary>
        ///     The directory service failed to lock a tree in preparation for a tree deletion because the tree was in use.
        /// </summary>
        public const int ERROR_DS_COULDNT_LOCK_TREE_FOR_DELETE = 0x00002136; // 8502

        /// <summary>
        ///     The directory service failed to identify the list of objects to delete while attempting a tree deletion.
        /// </summary>
        public const int ERROR_DS_COULDNT_IDENTIFY_OBJECTS_FOR_TREE_DELETE = 0x00002137; // 8503

        /// <summary>
        ///     Security Accounts Manager initialization failed because of the following error: %1. Error Status: 0x%2. Please
        ///     shutdown this system and reboot into Directory Services Restore Mode, check the event log for more detailed
        ///     information.
        /// </summary>
        public const int ERROR_DS_SAM_INIT_FAILURE = 0x00002138; // 8504

        /// <summary>
        ///     Only an administrator can modify the membership list of an administrative group.
        /// </summary>
        public const int ERROR_DS_SENSITIVE_GROUP_VIOLATION = 0x00002139; // 8505

        /// <summary>
        ///     Cannot change the primary group ID of a domain controller account.
        /// </summary>
        public const int ERROR_DS_CANT_MOD_PRIMARYGROUPID = 0x0000213A; // 8506

        /// <summary>
        ///     An attempt is made to modify the base schema.
        /// </summary>
        public const int ERROR_DS_ILLEGAL_BASE_SCHEMA_MOD = 0x0000213B; // 8507

        /// <summary>
        ///     Adding a new mandatory attribute to an existing class, deleting a mandatory attribute from an existing class, or
        ///     adding an optional attribute to the special class Top that is not a backlink attribute (directly or through
        ///     inheritance, for example, by adding or deleting an auxiliary class) is not allowed.
        /// </summary>
        public const int ERROR_DS_NONSAFE_SCHEMA_CHANGE = 0x0000213C; // 8508

        /// <summary>
        ///     Schema update is not allowed on this DC because the DC is not the schema FSMO Role Owner.
        /// </summary>
        public const int ERROR_DS_SCHEMA_UPDATE_DISALLOWED = 0x0000213D; // 8509

        /// <summary>
        ///     An object of this class cannot be created under the schema container. You can only create attribute-schema and
        ///     class-schema objects under the schema container.
        /// </summary>
        public const int ERROR_DS_CANT_CREATE_UNDER_SCHEMA = 0x0000213E; // 8510

        /// <summary>
        ///     The replica/child install failed to get the objectVersion attribute on the schema container on the source DC.
        ///     Either the attribute is missing on the schema container or the credentials supplied do not have permission to read
        ///     it.
        /// </summary>
        public const int ERROR_DS_INSTALL_NO_SRC_SCH_VERSION = 0x0000213F; // 8511

        /// <summary>
        ///     The replica/child install failed to read the objectVersion attribute in the SCHEMA section of the file schema.ini
        ///     in the system32 directory.
        /// </summary>
        public const int ERROR_DS_INSTALL_NO_SCH_VERSION_IN_INIFILE = 0x00002140; // 8512

        /// <summary>
        ///     The specified group type is invalid.
        /// </summary>
        public const int ERROR_DS_INVALID_GROUP_TYPE = 0x00002141; // 8513

        /// <summary>
        ///     You cannot nest global groups in a mixed domain if the group is security-enabled.
        /// </summary>
        public const int ERROR_DS_NO_NEST_GLOBALGROUP_IN_MIXEDDOMAIN = 0x00002142; // 8514

        /// <summary>
        ///     You cannot nest local groups in a mixed domain if the group is security-enabled.
        /// </summary>
        public const int ERROR_DS_NO_NEST_LOCALGROUP_IN_MIXEDDOMAIN = 0x00002143; // 8515

        /// <summary>
        ///     A global group cannot have a local group as a member.
        /// </summary>
        public const int ERROR_DS_GLOBAL_CANT_HAVE_LOCAL_MEMBER = 0x00002144; // 8516

        /// <summary>
        ///     A global group cannot have a universal group as a member.
        /// </summary>
        public const int ERROR_DS_GLOBAL_CANT_HAVE_UNIVERSAL_MEMBER = 0x00002145; // 8517

        /// <summary>
        ///     A universal group cannot have a local group as a member.
        /// </summary>
        public const int ERROR_DS_UNIVERSAL_CANT_HAVE_LOCAL_MEMBER = 0x00002146; // 8518

        /// <summary>
        ///     A global group cannot have a cross-domain member.
        /// </summary>
        public const int ERROR_DS_GLOBAL_CANT_HAVE_CROSSDOMAIN_MEMBER = 0x00002147; // 8519

        /// <summary>
        ///     A local group cannot have another cross domain local group as a member.
        /// </summary>
        public const int ERROR_DS_LOCAL_CANT_HAVE_CROSSDOMAIN_LOCAL_MEMBER = 0x00002148; // 8520

        /// <summary>
        ///     A group with primary members cannot change to a security-disabled group.
        /// </summary>
        public const int ERROR_DS_HAVE_PRIMARY_MEMBERS = 0x00002149; // 8521

        /// <summary>
        ///     The schema cache load failed to convert the string default SD on a class-schema object.
        /// </summary>
        public const int ERROR_DS_STRING_SD_CONVERSION_FAILED = 0x0000214A; // 8522

        /// <summary>
        ///     Only DSAs configured to be Global Catalog servers should be allowed to hold the Domain Naming Master FSMO role.
        ///     (Applies only to Windows 2000 servers.)
        /// </summary>
        public const int ERROR_DS_NAMING_MASTER_GC = 0x0000214B; // 8523

        /// <summary>
        ///     The DSA operation is unable to proceed because of a DNS lookup failure.
        /// </summary>
        public const int ERROR_DS_DNS_LOOKUP_FAILURE = 0x0000214C; // 8524

        /// <summary>
        ///     While processing a change to the DNS Host Name for an object, the Service Principal Name values could not be kept
        ///     in sync.
        /// </summary>
        public const int ERROR_DS_COULDNT_UPDATE_SPNS = 0x0000214D; // 8525

        /// <summary>
        ///     The Security Descriptor attribute could not be read.
        /// </summary>
        public const int ERROR_DS_CANT_RETRIEVE_SD = 0x0000214E; // 8526

        /// <summary>
        ///     The object requested was not found, but an object with that key was found.
        /// </summary>
        public const int ERROR_DS_KEY_NOT_UNIQUE = 0x0000214F; // 8527

        /// <summary>
        ///     The syntax of the linked attribute being added is incorrect. Forward links can only have syntax 2.5.5.1, 2.5.5.7,
        ///     and 2.5.5.14, and backlinks can only have syntax 2.5.5.1.
        /// </summary>
        public const int ERROR_DS_WRONG_LINKED_ATT_SYNTAX = 0x00002150; // 8528

        /// <summary>
        ///     Security Account Manager needs to get the boot password.
        /// </summary>
        public const int ERROR_DS_SAM_NEED_BOOTKEY_PASSWORD = 0x00002151; // 8529

        /// <summary>
        ///     Security Account Manager needs to get the boot key from floppy disk.
        /// </summary>
        public const int ERROR_DS_SAM_NEED_BOOTKEY_FLOPPY = 0x00002152; // 8530

        /// <summary>
        ///     Directory Service cannot start.
        /// </summary>
        public const int ERROR_DS_CANT_START = 0x00002153; // 8531

        /// <summary>
        ///     Directory Services could not start.
        /// </summary>
        public const int ERROR_DS_INIT_FAILURE = 0x00002154; // 8532

        /// <summary>
        ///     The connection between client and server requires packet privacy or better.
        /// </summary>
        public const int ERROR_DS_NO_PKT_PRIVACY_ON_CONNECTION = 0x00002155; // 8533

        /// <summary>
        ///     The source domain may not be in the same forest as destination.
        /// </summary>
        public const int ERROR_DS_SOURCE_DOMAIN_IN_FOREST = 0x00002156; // 8534

        /// <summary>
        ///     The destination domain must be in the forest.
        /// </summary>
        public const int ERROR_DS_DESTINATION_DOMAIN_NOT_IN_FOREST = 0x00002157; // 8535

        /// <summary>
        ///     The operation requires that destination domain auditing be enabled.
        /// </summary>
        public const int ERROR_DS_DESTINATION_AUDITING_NOT_ENABLED = 0x00002158; // 8536

        /// <summary>
        ///     The operation couldn't locate a DC for the source domain.
        /// </summary>
        public const int ERROR_DS_CANT_FIND_DC_FOR_SRC_DOMAIN = 0x00002159; // 8537

        /// <summary>
        ///     The source object must be a group or user.
        /// </summary>
        public const int ERROR_DS_SRC_OBJ_NOT_GROUP_OR_USER = 0x0000215A; // 8538

        /// <summary>
        ///     The source object's SID already exists in destination forest.
        /// </summary>
        public const int ERROR_DS_SRC_SID_EXISTS_IN_FOREST = 0x0000215B; // 8539

        /// <summary>
        ///     The source and destination object must be of the same type.
        /// </summary>
        public const int ERROR_DS_SRC_AND_DST_OBJECT_CLASS_MISMATCH = 0x0000215C; // 8540

        /// <summary>
        ///     Security Accounts Manager initialization failed because of the following error: %1. Error Status: 0x%2. Click OK to
        ///     shut down the system and reboot into Safe Mode. Check the event log for detailed information.
        /// </summary>
        public const int ERROR_SAM_INIT_FAILURE = 0x0000215D; // 8541

        /// <summary>
        ///     Schema information could not be included in the replication request.
        /// </summary>
        public const int ERROR_DS_DRA_SCHEMA_INFO_SHIP = 0x0000215E; // 8542

        /// <summary>
        ///     The replication operation could not be completed due to a schema incompatibility.
        /// </summary>
        public const int ERROR_DS_DRA_SCHEMA_CONFLICT = 0x0000215F; // 8543

        /// <summary>
        ///     The replication operation could not be completed due to a previous schema incompatibility.
        /// </summary>
        public const int ERROR_DS_DRA_EARLIER_SCHEMA_CONFLICT = 0x00002160; // 8544

        /// <summary>
        ///     The replication update could not be applied because either the source or the destination has not yet received
        ///     information regarding a recent cross-domain move operation.
        /// </summary>
        public const int ERROR_DS_DRA_OBJ_NC_MISMATCH = 0x00002161; // 8545

        /// <summary>
        ///     The requested domain could not be deleted because there exist domain controllers that still host this domain.
        /// </summary>
        public const int ERROR_DS_NC_STILL_HAS_DSAS = 0x00002162; // 8546

        /// <summary>
        ///     The requested operation can be performed only on a global catalog server.
        /// </summary>
        public const int ERROR_DS_GC_REQUIRED = 0x00002163; // 8547

        /// <summary>
        ///     A local group can only be a member of other local groups in the same domain.
        /// </summary>
        public const int ERROR_DS_LOCAL_MEMBER_OF_LOCAL_ONLY = 0x00002164; // 8548

        /// <summary>
        ///     Foreign security principals cannot be members of universal groups.
        /// </summary>
        public const int ERROR_DS_NO_FPO_IN_UNIVERSAL_GROUPS = 0x00002165; // 8549

        /// <summary>
        ///     The attribute is not allowed to be replicated to the GC because of security reasons.
        /// </summary>
        public const int ERROR_DS_CANT_ADD_TO_GC = 0x00002166; // 8550

        /// <summary>
        ///     The checkpoint with the PDC could not be taken because there too many modifications being processed currently.
        /// </summary>
        public const int ERROR_DS_NO_CHECKPOINT_WITH_PDC = 0x00002167; // 8551

        /// <summary>
        ///     The operation requires that source domain auditing be enabled.
        /// </summary>
        public const int ERROR_DS_SOURCE_AUDITING_NOT_ENABLED = 0x00002168; // 8552

        /// <summary>
        ///     Security principal objects can only be created inside domain naming contexts.
        /// </summary>
        public const int ERROR_DS_CANT_CREATE_IN_NONDOMAIN_NC = 0x00002169; // 8553

        /// <summary>
        ///     A Service Principal Name (SPN) could not be constructed because the provided hostname is not in the necessary
        ///     format.
        /// </summary>
        public const int ERROR_DS_INVALID_NAME_FOR_SPN = 0x0000216A; // 8554

        /// <summary>
        ///     A Filter was passed that uses constructed attributes.
        /// </summary>
        public const int ERROR_DS_FILTER_USES_CONTRUCTED_ATTRS = 0x0000216B; // 8555

        /// <summary>
        ///     The unicodePwd attribute value must be enclosed in double quotes.
        /// </summary>
        public const int ERROR_DS_UNICODEPWD_NOT_IN_QUOTES = 0x0000216C; // 8556

        /// <summary>
        ///     Your computer could not be joined to the domain. You have exceeded the maximum number of computer accounts you are
        ///     allowed to create in this domain. Contact your system administrator to have this limit reset or increased.
        /// </summary>
        public const int ERROR_DS_MACHINE_ACCOUNT_QUOTA_EXCEEDED = 0x0000216D; // 8557

        /// <summary>
        ///     For security reasons, the operation must be run on the destination DC.
        /// </summary>
        public const int ERROR_DS_MUST_BE_RUN_ON_DST_DC = 0x0000216E; // 8558

        /// <summary>
        ///     For security reasons, the source DC must be NT4SP4 or greater.
        /// </summary>
        public const int ERROR_DS_SRC_DC_MUST_BE_SP4_OR_GREATER = 0x0000216F; // 8559

        /// <summary>
        ///     Critical Directory Service System objects cannot be deleted during tree delete operations. The tree delete may have
        ///     been partially performed.
        /// </summary>
        public const int ERROR_DS_CANT_TREE_DELETE_CRITICAL_OBJ = 0x00002170; // 8560

        /// <summary>
        ///     Directory Services could not start because of the following error: %1. Error Status: 0x%2. Please click OK to
        ///     shutdown the system. You can use the recovery console to diagnose the system further.
        /// </summary>
        public const int ERROR_DS_INIT_FAILURE_CONSOLE = 0x00002171; // 8561

        /// <summary>
        ///     Security Accounts Manager initialization failed because of the following error: %1. Error Status: 0x%2. Please
        ///     click OK to shutdown the system. You can use the recovery console to diagnose the system further.
        /// </summary>
        public const int ERROR_DS_SAM_INIT_FAILURE_CONSOLE = 0x00002172; // 8562

        /// <summary>
        ///     The version of the operating system is incompatible with the current AD DS forest functional level or AD LDS
        ///     Configuration Set functional level. You must upgrade to a new version of the operating system before this server
        ///     can become an AD DS Domain Controller or add an AD LDS Instance in this AD DS Forest or AD LDS Configuration Set.
        /// </summary>
        public const int ERROR_DS_FOREST_VERSION_TOO_HIGH = 0x00002173; // 8563

        /// <summary>
        ///     The version of the operating system installed is incompatible with the current domain functional level. You must
        ///     upgrade to a new version of the operating system before this server can become a domain controller in this domain.
        /// </summary>
        public const int ERROR_DS_DOMAIN_VERSION_TOO_HIGH = 0x00002174; // 8564

        /// <summary>
        ///     The version of the operating system installed on this server no longer supports the current AD DS Forest functional
        ///     level or AD LDS Configuration Set functional level. You must raise the AD DS Forest functional level or AD LDS
        ///     Configuration Set functional level before this server can become an AD DS Domain Controller or an AD LDS Instance
        ///     in this Forest or Configuration Set.
        /// </summary>
        public const int ERROR_DS_FOREST_VERSION_TOO_LOW = 0x00002175; // 8565

        /// <summary>
        ///     The version of the operating system installed on this server no longer supports the current domain functional
        ///     level. You must raise the domain functional level before this server can become a domain controller in this domain.
        /// </summary>
        public const int ERROR_DS_DOMAIN_VERSION_TOO_LOW = 0x00002176; // 8566

        /// <summary>
        ///     The version of the operating system installed on this server is incompatible with the functional level of the
        ///     domain or forest.
        /// </summary>
        public const int ERROR_DS_INCOMPATIBLE_VERSION = 0x00002177; // 8567

        /// <summary>
        ///     The functional level of the domain (or forest) cannot be raised to the requested value, because there exist one or
        ///     more domain controllers in the domain (or forest) that are at a lower incompatible functional level.
        /// </summary>
        public const int ERROR_DS_LOW_DSA_VERSION = 0x00002178; // 8568

        /// <summary>
        ///     The forest functional level cannot be raised to the requested value since one or more domains are still in mixed
        ///     domain mode. All domains in the forest must be in native mode, for you to raise the forest functional level.
        /// </summary>
        public const int ERROR_DS_NO_BEHAVIOR_VERSION_IN_MIXEDDOMAIN = 0x00002179; // 8569

        /// <summary>
        ///     The sort order requested is not supported.
        /// </summary>
        public const int ERROR_DS_NOT_SUPPORTED_SORT_ORDER = 0x0000217A; // 8570

        /// <summary>
        ///     The requested name already exists as a unique identifier.
        /// </summary>
        public const int ERROR_DS_NAME_NOT_UNIQUE = 0x0000217B; // 8571

        /// <summary>
        ///     The machine account was created pre-NT4. The account needs to be recreated.
        /// </summary>
        public const int ERROR_DS_MACHINE_ACCOUNT_CREATED_PRENT4 = 0x0000217C; // 8572

        /// <summary>
        ///     The database is out of version store.
        /// </summary>
        public const int ERROR_DS_OUT_OF_VERSION_STORE = 0x0000217D; // 8573

        /// <summary>
        ///     Unable to continue operation because multiple conflicting controls were used.
        /// </summary>
        public const int ERROR_DS_INCOMPATIBLE_CONTROLS_USED = 0x0000217E; // 8574

        /// <summary>
        ///     Unable to find a valid security descriptor reference domain for this partition.
        /// </summary>
        public const int ERROR_DS_NO_REF_DOMAIN = 0x0000217F; // 8575

        /// <summary>
        ///     Schema update failed: The link identifier is reserved.
        /// </summary>
        public const int ERROR_DS_RESERVED_LINK_ID = 0x00002180; // 8576

        /// <summary>
        ///     Schema update failed: There are no link identifiers available.
        /// </summary>
        public const int ERROR_DS_LINK_ID_NOT_AVAILABLE = 0x00002181; // 8577

        /// <summary>
        ///     An account group cannot have a universal group as a member.
        /// </summary>
        public const int ERROR_DS_AG_CANT_HAVE_UNIVERSAL_MEMBER = 0x00002182; // 8578

        /// <summary>
        ///     Rename or move operations on naming context heads or read-only objects are not allowed.
        /// </summary>
        public const int ERROR_DS_MODIFYDN_DISALLOWED_BY_INSTANCE_TYPE = 0x00002183; // 8579

        /// <summary>
        ///     Move operations on objects in the schema naming context are not allowed.
        /// </summary>
        public const int ERROR_DS_NO_OBJECT_MOVE_IN_SCHEMA_NC = 0x00002184; // 8580

        /// <summary>
        ///     A system flag has been set on the object and does not allow the object to be moved or renamed.
        /// </summary>
        public const int ERROR_DS_MODIFYDN_DISALLOWED_BY_FLAG = 0x00002185; // 8581

        /// <summary>
        ///     This object is not allowed to change its grandparent container. Moves are not forbidden on this object, but are
        ///     restricted to sibling containers.
        /// </summary>
        public const int ERROR_DS_MODIFYDN_WRONG_GRANDPARENT = 0x00002186; // 8582

        /// <summary>
        ///     Unable to resolve completely, a referral to another forest is generated.
        /// </summary>
        public const int ERROR_DS_NAME_ERROR_TRUST_REFERRAL = 0x00002187; // 8583

        /// <summary>
        ///     The requested action is not supported on standard server.
        /// </summary>
        public const int ERROR_NOT_SUPPORTED_ON_STANDARD_SERVER = 0x00002188; // 8584

        /// <summary>
        ///     Could not access a partition of the directory service located on a remote server. Make sure at least one server is
        ///     running for the partition in question.
        /// </summary>
        public const int ERROR_DS_CANT_ACCESS_REMOTE_PART_OF_AD = 0x00002189; // 8585

        /// <summary>
        ///     The directory cannot validate the proposed naming context (or partition) name because it does not hold a replica
        ///     nor can it contact a replica of the naming context above the proposed naming context. Please ensure that the parent
        ///     naming context is properly registered in DNS, and at least one replica of this naming context is reachable by the
        ///     Domain Naming master.
        /// </summary>
        public const int ERROR_DS_CR_IMPOSSIBLE_TO_VALIDATE_V2 = 0x0000218A; // 8586

        /// <summary>
        ///     The thread limit for this request was exceeded.
        /// </summary>
        public const int ERROR_DS_THREAD_LIMIT_EXCEEDED = 0x0000218B; // 8587

        /// <summary>
        ///     The Global catalog server is not in the closest site.
        /// </summary>
        public const int ERROR_DS_NOT_CLOSEST = 0x0000218C; // 8588

        /// <summary>
        ///     The DS cannot derive a service principal name (SPN) with which to mutually authenticate the target server because
        ///     the corresponding server object in the local DS database has no serverReference attribute.
        /// </summary>
        public const int ERROR_DS_CANT_DERIVE_SPN_WITHOUT_SERVER_REF = 0x0000218D; // 8589

        /// <summary>
        ///     The Directory Service failed to enter single user mode.
        /// </summary>
        public const int ERROR_DS_SINGLE_USER_MODE_FAILED = 0x0000218E; // 8590

        /// <summary>
        ///     The Directory Service cannot parse the script because of a syntax error.
        /// </summary>
        public const int ERROR_DS_NTDSCRIPT_SYNTAX_ERROR = 0x0000218F; // 8591

        /// <summary>
        ///     The Directory Service cannot process the script because of an error.
        /// </summary>
        public const int ERROR_DS_NTDSCRIPT_PROCESS_ERROR = 0x00002190; // 8592

        /// <summary>
        ///     The directory service cannot perform the requested operation because the servers involved are of different
        ///     replication epochs (which is usually related to a domain rename that is in progress).
        /// </summary>
        public const int ERROR_DS_DIFFERENT_REPL_EPOCHS = 0x00002191; // 8593

        /// <summary>
        ///     The directory service binding must be renegotiated due to a change in the server extensions information.
        /// </summary>
        public const int ERROR_DS_DRS_EXTENSIONS_CHANGED = 0x00002192; // 8594

        /// <summary>
        ///     Operation not allowed on a disabled cross ref.
        /// </summary>
        public const int ERROR_DS_REPLICA_SET_CHANGE_NOT_ALLOWED_ON_DISABLED_CR = 0x00002193; // 8595

        /// <summary>
        ///     Schema update failed: No values for msDS-IntId are available.
        /// </summary>
        public const int ERROR_DS_NO_MSDS_INTID = 0x00002194; // 8596

        /// <summary>
        ///     Schema update failed: Duplicate msDS-INtId. Retry the operation.
        /// </summary>
        public const int ERROR_DS_DUP_MSDS_INTID = 0x00002195; // 8597

        /// <summary>
        ///     Schema deletion failed: attribute is used in rDNAttID.
        /// </summary>
        public const int ERROR_DS_EXISTS_IN_RDNATTID = 0x00002196; // 8598

        /// <summary>
        ///     The directory service failed to authorize the request.
        /// </summary>
        public const int ERROR_DS_AUTHORIZATION_FAILED = 0x00002197; // 8599

        /// <summary>
        ///     The Directory Service cannot process the script because it is invalid.
        /// </summary>
        public const int ERROR_DS_INVALID_SCRIPT = 0x00002198; // 8600

        /// <summary>
        ///     The remote create cross reference operation failed on the Domain Naming Master FSMO. The operation's error is in
        ///     the extended data.
        /// </summary>
        public const int ERROR_DS_REMOTE_CROSSREF_OP_FAILED = 0x00002199; // 8601

        /// <summary>
        ///     A cross reference is in use locally with the same name.
        /// </summary>
        public const int ERROR_DS_CROSS_REF_BUSY = 0x0000219A; // 8602

        /// <summary>
        ///     The DS cannot derive a service principal name (SPN) with which to mutually authenticate the target server because
        ///     the server's domain has been deleted from the forest.
        /// </summary>
        public const int ERROR_DS_CANT_DERIVE_SPN_FOR_DELETED_DOMAIN = 0x0000219B; // 8603

        /// <summary>
        ///     Writeable NCs prevent this DC from demoting.
        /// </summary>
        public const int ERROR_DS_CANT_DEMOTE_WITH_WRITEABLE_NC = 0x0000219C; // 8604

        /// <summary>
        ///     The requested object has a non-unique identifier and cannot be retrieved.
        /// </summary>
        public const int ERROR_DS_DUPLICATE_ID_FOUND = 0x0000219D; // 8605

        /// <summary>
        ///     Insufficient attributes were given to create an object. This object may not exist because it may have been deleted
        ///     and already garbage collected.
        /// </summary>
        public const int ERROR_DS_INSUFFICIENT_ATTR_TO_CREATE_OBJECT = 0x0000219E; // 8606

        /// <summary>
        ///     The group cannot be converted due to attribute restrictions on the requested group type.
        /// </summary>
        public const int ERROR_DS_GROUP_CONVERSION_ERROR = 0x0000219F; // 8607

        /// <summary>
        ///     Cross-domain move of non-empty basic application groups is not allowed.
        /// </summary>
        public const int ERROR_DS_CANT_MOVE_APP_BASIC_GROUP = 0x000021A0; // 8608

        /// <summary>
        ///     Cross-domain move of non-empty query based application groups is not allowed.
        /// </summary>
        public const int ERROR_DS_CANT_MOVE_APP_QUERY_GROUP = 0x000021A1; // 8609

        /// <summary>
        ///     The FSMO role ownership could not be verified because its directory partition has not replicated successfully with
        ///     at least one replication partner.
        /// </summary>
        public const int ERROR_DS_ROLE_NOT_VERIFIED = 0x000021A2; // 8610

        /// <summary>
        ///     The target container for a redirection of a well known object container cannot already be a special container.
        /// </summary>
        public const int ERROR_DS_WKO_CONTAINER_CANNOT_BE_SPECIAL = 0x000021A3; // 8611

        /// <summary>
        ///     The Directory Service cannot perform the requested operation because a domain rename operation is in progress.
        /// </summary>
        public const int ERROR_DS_DOMAIN_RENAME_IN_PROGRESS = 0x000021A4; // 8612

        /// <summary>
        ///     The directory service detected a child partition below the requested partition name. The partition hierarchy must
        ///     be created in a top down method.
        /// </summary>
        public const int ERROR_DS_EXISTING_AD_CHILD_NC = 0x000021A5; // 8613

        /// <summary>
        ///     The directory service cannot replicate with this server because the time since the last replication with this
        ///     server has exceeded the tombstone lifetime.
        /// </summary>
        public const int ERROR_DS_REPL_LIFETIME_EXCEEDED = 0x000021A6; // 8614

        /// <summary>
        ///     The requested operation is not allowed on an object under the system container.
        /// </summary>
        public const int ERROR_DS_DISALLOWED_IN_SYSTEM_CONTAINER = 0x000021A7; // 8615

        /// <summary>
        ///     The LDAP servers network send queue has filled up because the client is not processing the results of its requests
        ///     fast enough. No more requests will be processed until the client catches up. If the client does not catch up then
        ///     it will be disconnected.
        /// </summary>
        public const int ERROR_DS_LDAP_SEND_QUEUE_FULL = 0x000021A8; // 8616

        /// <summary>
        ///     The scheduled replication did not take place because the system was too busy to execute the request within the
        ///     schedule window. The replication queue is overloaded. Consider reducing the number of partners or decreasing the
        ///     scheduled replication frequency.
        /// </summary>
        public const int ERROR_DS_DRA_OUT_SCHEDULE_WINDOW = 0x000021A9; // 8617

        /// <summary>
        ///     At this time, it cannot be determined if the branch replication policy is available on the hub domain controller.
        ///     Please retry at a later time to account for replication latencies.
        /// </summary>
        public const int ERROR_DS_POLICY_NOT_KNOWN = 0x000021AA; // 8618

        /// <summary>
        ///     The site settings object for the specified site does not exist.
        /// </summary>
        public const int ERROR_NO_SITE_SETTINGS_OBJECT = 0x000021AB; // 8619

        /// <summary>
        ///     The local account store does not contain secret material for the specified account.
        /// </summary>
        public const int ERROR_NO_SECRETS = 0x000021AC; // 8620

        /// <summary>
        ///     Could not find a writable domain controller in the domain.
        /// </summary>
        public const int ERROR_NO_WRITABLE_DC_FOUND = 0x000021AD; // 8621

        /// <summary>
        ///     The server object for the domain controller does not exist.
        /// </summary>
        public const int ERROR_DS_NO_SERVER_OBJECT = 0x000021AE; // 8622

        /// <summary>
        ///     The NTDS Settings object for the domain controller does not exist.
        /// </summary>
        public const int ERROR_DS_NO_NTDSA_OBJECT = 0x000021AF; // 8623

        /// <summary>
        ///     The requested search operation is not supported for ASQ searches.
        /// </summary>
        public const int ERROR_DS_NON_ASQ_SEARCH = 0x000021B0; // 8624

        /// <summary>
        ///     A required audit event could not be generated for the operation.
        /// </summary>
        public const int ERROR_DS_AUDIT_FAILURE = 0x000021B1; // 8625

        /// <summary>
        ///     The search flags for the attribute are invalid. The subtree index bit is valid only on single valued attributes.
        /// </summary>
        public const int ERROR_DS_INVALID_SEARCH_FLAG_SUBTREE = 0x000021B2; // 8626

        /// <summary>
        ///     The search flags for the attribute are invalid. The tuple index bit is valid only on attributes of Unicode strings.
        /// </summary>
        public const int ERROR_DS_INVALID_SEARCH_FLAG_TUPLE = 0x000021B3; // 8627

        /// <summary>
        ///     The address books are nested too deeply. Failed to build the hierarchy table.
        /// </summary>
        public const int ERROR_DS_HIERARCHY_TABLE_TOO_DEEP = 0x000021B4; // 8628

        /// <summary>
        ///     The specified up-to-date-ness vector is corrupt.
        /// </summary>
        public const int ERROR_DS_DRA_CORRUPT_UTD_VECTOR = 0x000021B5; // 8629

        /// <summary>
        ///     The request to replicate secrets is denied.
        /// </summary>
        public const int ERROR_DS_DRA_SECRETS_DENIED = 0x000021B6; // 8630

        /// <summary>
        ///     Schema update failed: The MAPI identifier is reserved.
        /// </summary>
        public const int ERROR_DS_RESERVED_MAPI_ID = 0x000021B7; // 8631

        /// <summary>
        ///     Schema update failed: There are no MAPI identifiers available.
        /// </summary>
        public const int ERROR_DS_MAPI_ID_NOT_AVAILABLE = 0x000021B8; // 8632

        /// <summary>
        ///     The replication operation failed because the required attributes of the local krbtgt object are missing.
        /// </summary>
        public const int ERROR_DS_DRA_MISSING_KRBTGT_SECRET = 0x000021B9; // 8633

        /// <summary>
        ///     The domain name of the trusted domain already exists in the forest.
        /// </summary>
        public const int ERROR_DS_DOMAIN_NAME_EXISTS_IN_FOREST = 0x000021BA; // 8634

        /// <summary>
        ///     The flat name of the trusted domain already exists in the forest.
        /// </summary>
        public const int ERROR_DS_FLAT_NAME_EXISTS_IN_FOREST = 0x000021BB; // 8635

        /// <summary>
        ///     The User Principal Name (UPN) is invalid.
        /// </summary>
        public const int ERROR_INVALID_USER_PRINCIPAL_NAME = 0x000021BC; // 8636

        /// <summary>
        ///     OID mapped groups cannot have members.
        /// </summary>
        public const int ERROR_DS_OID_MAPPED_GROUP_CANT_HAVE_MEMBERS = 0x000021BD; // 8637

        /// <summary>
        ///     The specified OID cannot be found.
        /// </summary>
        public const int ERROR_DS_OID_NOT_FOUND = 0x000021BE; // 8638

        /// <summary>
        ///     The replication operation failed because the target object referred by a link value is recycled.
        /// </summary>
        public const int ERROR_DS_DRA_RECYCLED_TARGET = 0x000021BF; // 8639

        /// <summary>
        ///     The redirect operation failed because the target object is in a NC different from the domain NC of the current
        ///     domain controller.
        /// </summary>
        public const int ERROR_DS_DISALLOWED_NC_REDIRECT = 0x000021C0; // 8640

        /// <summary>
        ///     The functional level of the AD LDS configuration set cannot be lowered to the requested value.
        /// </summary>
        public const int ERROR_DS_HIGH_ADLDS_FFL = 0x000021C1; // 8641

        /// <summary>
        ///     The functional level of the domain (or forest) cannot be lowered to the requested value.
        /// </summary>
        public const int ERROR_DS_HIGH_DSA_VERSION = 0x000021C2; // 8642

        /// <summary>
        ///     The functional level of the AD LDS configuration set cannot be raised to the requested value, because there exist
        ///     one or more ADLDS instances that are at a lower incompatible functional level.
        /// </summary>
        public const int ERROR_DS_LOW_ADLDS_FFL = 0x000021C3; // 8643

        /// <summary>
        ///     The domain join cannot be completed because the SID of the domain you attempted to join was identical to the SID of
        ///     this machine. This is a symptom of an improperly cloned operating system install.  You should run sysprep on this
        ///     machine in order to generate a new machine SID. Please see http://go.microsoft.com/fwlink/p/?linkid=168895 for more
        ///     information.
        /// </summary>
        public const int ERROR_DOMAIN_SID_SAME_AS_LOCAL_WORKSTATION = 0x000021C4; // 8644

        /// <summary>
        ///     The undelete operation failed because the Sam Account Name or Additional Sam Account Name of the object being
        ///     undeleted conflicts with an existing live object.
        /// </summary>
        public const int ERROR_DS_UNDELETE_SAM_VALIDATION_FAILED = 0x000021C5; // 8645

        /// <summary>
        ///     The system is not authoritative for the specified account and therefore cannot complete the operation. Please retry
        ///     the operation using the provider associated with this account. If this is an online provider please use the
        ///     provider's online site.
        /// </summary>
        public const int ERROR_INCORRECT_ACCOUNT_TYPE = 0x000021C6; // 8646

        #endregion

        #region 9000 - 11999

        /// <summary>
        ///     DNS server unable to interpret format.
        /// </summary>
        public const int DNS_ERROR_RCODE_FORMAT_ERROR = 0x00002329; // 9001

        /// <summary>
        ///     DNS server failure.
        /// </summary>
        public const int DNS_ERROR_RCODE_SERVER_FAILURE = 0x0000232A; // 9002

        /// <summary>
        ///     DNS name does not exist.
        /// </summary>
        public const int DNS_ERROR_RCODE_NAME_ERROR = 0x0000232B; // 9003

        /// <summary>
        ///     DNS request not supported by name server.
        /// </summary>
        public const int DNS_ERROR_RCODE_NOT_IMPLEMENTED = 0x0000232C; // 9004

        /// <summary>
        ///     DNS operation refused.
        /// </summary>
        public const int DNS_ERROR_RCODE_REFUSED = 0x0000232D; // 9005

        /// <summary>
        ///     DNS name that ought not exist, does exist.
        /// </summary>
        public const int DNS_ERROR_RCODE_YXDOMAIN = 0x0000232E; // 9006

        /// <summary>
        ///     DNS RR set that ought not exist, does exist.
        /// </summary>
        public const int DNS_ERROR_RCODE_YXRRSET = 0x0000232F; // 9007

        /// <summary>
        ///     DNS RR set that ought to exist, does not exist.
        /// </summary>
        public const int DNS_ERROR_RCODE_NXRRSET = 0x00002330; // 9008

        /// <summary>
        ///     DNS server not authoritative for zone.
        /// </summary>
        public const int DNS_ERROR_RCODE_NOTAUTH = 0x00002331; // 9009

        /// <summary>
        ///     DNS name in update or prereq is not in zone.
        /// </summary>
        public const int DNS_ERROR_RCODE_NOTZONE = 0x00002332; // 9010

        /// <summary>
        ///     DNS signature failed to verify.
        /// </summary>
        public const int DNS_ERROR_RCODE_BADSIG = 0x00002338; // 9016

        /// <summary>
        ///     DNS bad key.
        /// </summary>
        public const int DNS_ERROR_RCODE_BADKEY = 0x00002339; // 9017

        /// <summary>
        ///     DNS signature validity expired.
        /// </summary>
        public const int DNS_ERROR_RCODE_BADTIME = 0x0000233A; // 9018

        /// <summary>
        ///     Only the DNS server acting as the key master for the zone may perform this operation.
        /// </summary>
        public const int DNS_ERROR_KEYMASTER_REQUIRED = 0x0000238D; // 9101

        /// <summary>
        ///     This operation is not allowed on a zone that is signed or has signing keys.
        /// </summary>
        public const int DNS_ERROR_NOT_ALLOWED_ON_SIGNED_ZONE = 0x0000238E; // 9102

        /// <summary>
        ///     NSEC3 is not compatible with the RSA-SHA-1 algorithm. Choose a different algorithm or use NSEC.
        /// </summary>
        public const int DNS_ERROR_NSEC3_INCOMPATIBLE_WITH_RSA_SHA1 = 0x0000238F; // 9103

        /// <summary>
        ///     The zone does not have enough signing keys. There must be at least one key signing key (KSK) and at least one zone
        ///     signing key (ZSK).
        /// </summary>
        public const int DNS_ERROR_NOT_ENOUGH_SIGNING_KEY_DESCRIPTORS = 0x00002390; // 9104

        /// <summary>
        ///     The specified algorithm is not supported.
        /// </summary>
        public const int DNS_ERROR_UNSUPPORTED_ALGORITHM = 0x00002391; // 9105

        /// <summary>
        ///     The specified key size is not supported.
        /// </summary>
        public const int DNS_ERROR_INVALID_KEY_SIZE = 0x00002392; // 9106

        /// <summary>
        ///     One or more of the signing keys for a zone are not accessible to the DNS server. Zone signing will not be
        ///     operational until this error is resolved.
        /// </summary>
        public const int DNS_ERROR_SIGNING_KEY_NOT_ACCESSIBLE = 0x00002393; // 9107

        /// <summary>
        ///     The specified key storage provider does not support DPAPI++ data protection. Zone signing will not be operational
        ///     until this error is resolved.
        /// </summary>
        public const int DNS_ERROR_KSP_DOES_NOT_SUPPORT_PROTECTION = 0x00002394; // 9108

        /// <summary>
        ///     An unexpected DPAPI++ error was encountered. Zone signing will not be operational until this error is resolved.
        /// </summary>
        public const int DNS_ERROR_UNEXPECTED_DATA_PROTECTION_ERROR = 0x00002395; // 9109

        /// <summary>
        ///     An unexpected crypto error was encountered. Zone signing may not be operational until this error is resolved.
        /// </summary>
        public const int DNS_ERROR_UNEXPECTED_CNG_ERROR = 0x00002396; // 9110

        /// <summary>
        ///     The DNS server encountered a signing key with an unknown version. Zone signing will not be operational until this
        ///     error is resolved.
        /// </summary>
        public const int DNS_ERROR_UNKNOWN_SIGNING_PARAMETER_VERSION = 0x00002397; // 9111

        /// <summary>
        ///     The specified key service provider cannot be opened by the DNS server.
        /// </summary>
        public const int DNS_ERROR_KSP_NOT_ACCESSIBLE = 0x00002398; // 9112

        /// <summary>
        ///     The DNS server cannot accept any more signing keys with the specified algorithm and KSK flag value for this zone.
        /// </summary>
        public const int DNS_ERROR_TOO_MANY_SKDS = 0x00002399; // 9113

        /// <summary>
        ///     The specified rollover period is invalid.
        /// </summary>
        public const int DNS_ERROR_INVALID_ROLLOVER_PERIOD = 0x0000239A; // 9114

        /// <summary>
        ///     The specified initial rollover offset is invalid.
        /// </summary>
        public const int DNS_ERROR_INVALID_INITIAL_ROLLOVER_OFFSET = 0x0000239B; // 9115

        /// <summary>
        ///     The specified signing key is already in process of rolling over keys.
        /// </summary>
        public const int DNS_ERROR_ROLLOVER_IN_PROGRESS = 0x0000239C; // 9116

        /// <summary>
        ///     The specified signing key does not have a standby key to revoke.
        /// </summary>
        public const int DNS_ERROR_STANDBY_KEY_NOT_PRESENT = 0x0000239D; // 9117

        /// <summary>
        ///     This operation is not allowed on a zone signing key (ZSK).
        /// </summary>
        public const int DNS_ERROR_NOT_ALLOWED_ON_ZSK = 0x0000239E; // 9118

        /// <summary>
        ///     This operation is not allowed on an active signing key.
        /// </summary>
        public const int DNS_ERROR_NOT_ALLOWED_ON_ACTIVE_SKD = 0x0000239F; // 9119

        /// <summary>
        ///     The specified signing key is already queued for rollover.
        /// </summary>
        public const int DNS_ERROR_ROLLOVER_ALREADY_QUEUED = 0x000023A0; // 9120

        /// <summary>
        ///     This operation is not allowed on an unsigned zone.
        /// </summary>
        public const int DNS_ERROR_NOT_ALLOWED_ON_UNSIGNED_ZONE = 0x000023A1; // 9121

        /// <summary>
        ///     This operation could not be completed because the DNS server listed as the current key master for this zone is down
        ///     or misconfigured. Resolve the problem on the current key master for this zone or use another DNS server to seize
        ///     the key master role.
        /// </summary>
        public const int DNS_ERROR_BAD_KEYMASTER = 0x000023A2; // 9122

        /// <summary>
        ///     The specified signature validity period is invalid.
        /// </summary>
        public const int DNS_ERROR_INVALID_SIGNATURE_VALIDITY_PERIOD = 0x000023A3; // 9123

        /// <summary>
        ///     The specified NSEC3 iteration count is higher than allowed by the minimum key length used in the zone.
        /// </summary>
        public const int DNS_ERROR_INVALID_NSEC3_ITERATION_COUNT = 0x000023A4; // 9124

        /// <summary>
        ///     This operation could not be completed because the DNS server has been configured with DNSSEC features disabled.
        ///     Enable DNSSEC on the DNS server.
        /// </summary>
        public const int DNS_ERROR_DNSSEC_IS_DISABLED = 0x000023A5; // 9125

        /// <summary>
        ///     This operation could not be completed because the XML stream received is empty or syntactically invalid.
        /// </summary>
        public const int DNS_ERROR_INVALID_XML = 0x000023A6; // 9126

        /// <summary>
        ///     This operation completed, but no trust anchors were added because all of the trust anchors received were either
        ///     invalid, unsupported, expired, or would not become valid in less than 30 days.
        /// </summary>
        public const int DNS_ERROR_NO_VALID_TRUST_ANCHORS = 0x000023A7; // 9127

        /// <summary>
        ///     The specified signing key is not waiting for parental DS update.
        /// </summary>
        public const int DNS_ERROR_ROLLOVER_NOT_POKEABLE = 0x000023A8; // 9128

        /// <summary>
        ///     Hash collision detected during NSEC3 signing. Specify a different user-provided salt, or use a randomly generated
        ///     salt, and attempt to sign the zone again.
        /// </summary>
        public const int DNS_ERROR_NSEC3_NAME_COLLISION = 0x000023A9; // 9129

        /// <summary>
        ///     NSEC is not compatible with the NSEC3-RSA-SHA-1 algorithm. Choose a different algorithm or use NSEC3.
        /// </summary>
        public const int DNS_ERROR_NSEC_INCOMPATIBLE_WITH_NSEC3_RSA_SHA1 = 0x000023AA; // 9130

        /// <summary>
        ///     No records found for given DNS query.
        /// </summary>
        public const int DNS_INFO_NO_RECORDS = 0x0000251D; // 9501

        /// <summary>
        ///     Bad DNS packet.
        /// </summary>
        public const int DNS_ERROR_BAD_PACKET = 0x0000251E; // 9502

        /// <summary>
        ///     No DNS packet.
        /// </summary>
        public const int DNS_ERROR_NO_PACKET = 0x0000251F; // 9503

        /// <summary>
        ///     DNS error, check rcode.
        /// </summary>
        public const int DNS_ERROR_RCODE = 0x00002520; // 9504

        /// <summary>
        ///     Unsecured DNS packet.
        /// </summary>
        public const int DNS_ERROR_UNSECURE_PACKET = 0x00002521; // 9505

        /// <summary>
        ///     DNS query request is pending.
        /// </summary>
        public const int DNS_REQUEST_PENDING = 0x00002522; // 9506

        /// <summary>
        ///     Invalid DNS type.
        /// </summary>
        public const int DNS_ERROR_INVALID_TYPE = 0x0000254F; // 9551

        /// <summary>
        ///     Invalid IP address.
        /// </summary>
        public const int DNS_ERROR_INVALID_IP_ADDRESS = 0x00002550; // 9552

        /// <summary>
        ///     Invalid property.
        /// </summary>
        public const int DNS_ERROR_INVALID_PROPERTY = 0x00002551; // 9553

        /// <summary>
        ///     Try DNS operation again later.
        /// </summary>
        public const int DNS_ERROR_TRY_AGAIN_LATER = 0x00002552; // 9554

        /// <summary>
        ///     Record for given name and type is not unique.
        /// </summary>
        public const int DNS_ERROR_NOT_UNIQUE = 0x00002553; // 9555

        /// <summary>
        ///     DNS name does not comply with RFC specifications.
        /// </summary>
        public const int DNS_ERROR_NON_RFC_NAME = 0x00002554; // 9556

        /// <summary>
        ///     DNS name is a fully-qualified DNS name.
        /// </summary>
        public const int DNS_STATUS_FQDN = 0x00002555; // 9557

        /// <summary>
        ///     DNS name is dotted (multi-label).
        /// </summary>
        public const int DNS_STATUS_DOTTED_NAME = 0x00002556; // 9558

        /// <summary>
        ///     DNS name is a single-part name.
        /// </summary>
        public const int DNS_STATUS_SINGLE_PART_NAME = 0x00002557; // 9559

        /// <summary>
        ///     DNS name contains an invalid character.
        /// </summary>
        public const int DNS_ERROR_INVALID_NAME_CHAR = 0x00002558; // 9560

        /// <summary>
        ///     DNS name is entirely numeric.
        /// </summary>
        public const int DNS_ERROR_NUMERIC_NAME = 0x00002559; // 9561

        /// <summary>
        ///     The operation requested is not permitted on a DNS root server.
        /// </summary>
        public const int DNS_ERROR_NOT_ALLOWED_ON_ROOT_SERVER = 0x0000255A; // 9562

        /// <summary>
        ///     The record could not be created because this part of the DNS namespace has been delegated to another server.
        /// </summary>
        public const int DNS_ERROR_NOT_ALLOWED_UNDER_DELEGATION = 0x0000255B; // 9563

        /// <summary>
        ///     The DNS server could not find a set of root hints.
        /// </summary>
        public const int DNS_ERROR_CANNOT_FIND_ROOT_HINTS = 0x0000255C; // 9564

        /// <summary>
        ///     The DNS server found root hints but they were not consistent across all adapters.
        /// </summary>
        public const int DNS_ERROR_INCONSISTENT_ROOT_HINTS = 0x0000255D; // 9565

        /// <summary>
        ///     The specified value is too small for this parameter.
        /// </summary>
        public const int DNS_ERROR_DWORD_VALUE_TOO_SMALL = 0x0000255E; // 9566

        /// <summary>
        ///     The specified value is too large for this parameter.
        /// </summary>
        public const int DNS_ERROR_DWORD_VALUE_TOO_LARGE = 0x0000255F; // 9567

        /// <summary>
        ///     This operation is not allowed while the DNS server is loading zones in the background. Please try again later.
        /// </summary>
        public const int DNS_ERROR_BACKGROUND_LOADING = 0x00002560; // 9568

        /// <summary>
        ///     The operation requested is not permitted on against a DNS server running on a read-only DC.
        /// </summary>
        public const int DNS_ERROR_NOT_ALLOWED_ON_RODC = 0x00002561; // 9569

        /// <summary>
        ///     No data is allowed to exist underneath a DNAME record.
        /// </summary>
        public const int DNS_ERROR_NOT_ALLOWED_UNDER_DNAME = 0x00002562; // 9570

        /// <summary>
        ///     This operation requires credentials delegation.
        /// </summary>
        public const int DNS_ERROR_DELEGATION_REQUIRED = 0x00002563; // 9571

        /// <summary>
        ///     Name resolution policy table has been corrupted. DNS resolution will fail until it is fixed. Contact your network
        ///     administrator.
        /// </summary>
        public const int DNS_ERROR_INVALID_POLICY_TABLE = 0x00002564; // 9572

        /// <summary>
        ///     DNS zone does not exist.
        /// </summary>
        public const int DNS_ERROR_ZONE_DOES_NOT_EXIST = 0x00002581; // 9601

        /// <summary>
        ///     DNS zone information not available.
        /// </summary>
        public const int DNS_ERROR_NO_ZONE_INFO = 0x00002582; // 9602

        /// <summary>
        ///     Invalid operation for DNS zone.
        /// </summary>
        public const int DNS_ERROR_INVALID_ZONE_OPERATION = 0x00002583; // 9603

        /// <summary>
        ///     Invalid DNS zone configuration.
        /// </summary>
        public const int DNS_ERROR_ZONE_CONFIGURATION_ERROR = 0x00002584; // 9604

        /// <summary>
        ///     DNS zone has no start of authority (SOA) record.
        /// </summary>
        public const int DNS_ERROR_ZONE_HAS_NO_SOA_RECORD = 0x00002585; // 9605

        /// <summary>
        ///     DNS zone has no Name Server (NS) record.
        /// </summary>
        public const int DNS_ERROR_ZONE_HAS_NO_NS_RECORDS = 0x00002586; // 9606

        /// <summary>
        ///     DNS zone is locked.
        /// </summary>
        public const int DNS_ERROR_ZONE_LOCKED = 0x00002587; // 9607

        /// <summary>
        ///     DNS zone creation failed.
        /// </summary>
        public const int DNS_ERROR_ZONE_CREATION_FAILED = 0x00002588; // 9608

        /// <summary>
        ///     DNS zone already exists.
        /// </summary>
        public const int DNS_ERROR_ZONE_ALREADY_EXISTS = 0x00002589; // 9609

        /// <summary>
        ///     DNS automatic zone already exists.
        /// </summary>
        public const int DNS_ERROR_AUTOZONE_ALREADY_EXISTS = 0x0000258A; // 9610

        /// <summary>
        ///     Invalid DNS zone type.
        /// </summary>
        public const int DNS_ERROR_INVALID_ZONE_TYPE = 0x0000258B; // 9611

        /// <summary>
        ///     Secondary DNS zone requires master IP address.
        /// </summary>
        public const int DNS_ERROR_SECONDARY_REQUIRES_MASTER_IP = 0x0000258C; // 9612

        /// <summary>
        ///     DNS zone not secondary.
        /// </summary>
        public const int DNS_ERROR_ZONE_NOT_SECONDARY = 0x0000258D; // 9613

        /// <summary>
        ///     Need secondary IP address.
        /// </summary>
        public const int DNS_ERROR_NEED_SECONDARY_ADDRESSES = 0x0000258E; // 9614

        /// <summary>
        ///     WINS initialization failed.
        /// </summary>
        public const int DNS_ERROR_WINS_INIT_FAILED = 0x0000258F; // 9615

        /// <summary>
        ///     Need WINS servers.
        /// </summary>
        public const int DNS_ERROR_NEED_WINS_SERVERS = 0x00002590; // 9616

        /// <summary>
        ///     NBTSTAT initialization call failed.
        /// </summary>
        public const int DNS_ERROR_NBSTAT_INIT_FAILED = 0x00002591; // 9617

        /// <summary>
        ///     Invalid delete of start of authority (SOA).
        /// </summary>
        public const int DNS_ERROR_SOA_DELETE_INVALID = 0x00002592; // 9618

        /// <summary>
        ///     A conditional forwarding zone already exists for that name.
        /// </summary>
        public const int DNS_ERROR_FORWARDER_ALREADY_EXISTS = 0x00002593; // 9619

        /// <summary>
        ///     This zone must be configured with one or more master DNS server IP addresses.
        /// </summary>
        public const int DNS_ERROR_ZONE_REQUIRES_MASTER_IP = 0x00002594; // 9620

        /// <summary>
        ///     The operation cannot be performed because this zone is shut down.
        /// </summary>
        public const int DNS_ERROR_ZONE_IS_SHUTDOWN = 0x00002595; // 9621

        /// <summary>
        ///     This operation cannot be performed because the zone is currently being signed. Please try again later.
        /// </summary>
        public const int DNS_ERROR_ZONE_LOCKED_FOR_SIGNING = 0x00002596; // 9622

        /// <summary>
        ///     Primary DNS zone requires datafile.
        /// </summary>
        public const int DNS_ERROR_PRIMARY_REQUIRES_DATAFILE = 0x000025B3; // 9651

        /// <summary>
        ///     Invalid datafile name for DNS zone.
        /// </summary>
        public const int DNS_ERROR_INVALID_DATAFILE_NAME = 0x000025B4; // 9652

        /// <summary>
        ///     Failed to open datafile for DNS zone.
        /// </summary>
        public const int DNS_ERROR_DATAFILE_OPEN_FAILURE = 0x000025B5; // 9653

        /// <summary>
        ///     Failed to write datafile for DNS zone.
        /// </summary>
        public const int DNS_ERROR_FILE_WRITEBACK_FAILED = 0x000025B6; // 9654

        /// <summary>
        ///     Failure while reading datafile for DNS zone.
        /// </summary>
        public const int DNS_ERROR_DATAFILE_PARSING = 0x000025B7; // 9655

        /// <summary>
        ///     DNS record does not exist.
        /// </summary>
        public const int DNS_ERROR_RECORD_DOES_NOT_EXIST = 0x000025E5; // 9701

        /// <summary>
        ///     DNS record format error.
        /// </summary>
        public const int DNS_ERROR_RECORD_FORMAT = 0x000025E6; // 9702

        /// <summary>
        ///     Node creation failure in DNS.
        /// </summary>
        public const int DNS_ERROR_NODE_CREATION_FAILED = 0x000025E7; // 9703

        /// <summary>
        ///     Unknown DNS record type.
        /// </summary>
        public const int DNS_ERROR_UNKNOWN_RECORD_TYPE = 0x000025E8; // 9704

        /// <summary>
        ///     DNS record timed out.
        /// </summary>
        public const int DNS_ERROR_RECORD_TIMED_OUT = 0x000025E9; // 9705

        /// <summary>
        ///     Name not in DNS zone.
        /// </summary>
        public const int DNS_ERROR_NAME_NOT_IN_ZONE = 0x000025EA; // 9706

        /// <summary>
        ///     CNAME loop detected.
        /// </summary>
        public const int DNS_ERROR_CNAME_LOOP = 0x000025EB; // 9707

        /// <summary>
        ///     Node is a CNAME DNS record.
        /// </summary>
        public const int DNS_ERROR_NODE_IS_CNAME = 0x000025EC; // 9708

        /// <summary>
        ///     A CNAME record already exists for given name.
        /// </summary>
        public const int DNS_ERROR_CNAME_COLLISION = 0x000025ED; // 9709

        /// <summary>
        ///     Record only at DNS zone root.
        /// </summary>
        public const int DNS_ERROR_RECORD_ONLY_AT_ZONE_ROOT = 0x000025EE; // 9710

        /// <summary>
        ///     DNS record already exists.
        /// </summary>
        public const int DNS_ERROR_RECORD_ALREADY_EXISTS = 0x000025EF; // 9711

        /// <summary>
        ///     Secondary DNS zone data error.
        /// </summary>
        public const int DNS_ERROR_SECONDARY_DATA = 0x000025F0; // 9712

        /// <summary>
        ///     Could not create DNS cache data.
        /// </summary>
        public const int DNS_ERROR_NO_CREATE_CACHE_DATA = 0x000025F1; // 9713

        /// <summary>
        ///     DNS name does not exist.
        /// </summary>
        public const int DNS_ERROR_NAME_DOES_NOT_EXIST = 0x000025F2; // 9714

        /// <summary>
        ///     Could not create pointer (PTR) record.
        /// </summary>
        public const int DNS_WARNING_PTR_CREATE_FAILED = 0x000025F3; // 9715

        /// <summary>
        ///     DNS domain was undeleted.
        /// </summary>
        public const int DNS_WARNING_DOMAIN_UNDELETED = 0x000025F4; // 9716

        /// <summary>
        ///     The directory service is unavailable.
        /// </summary>
        public const int DNS_ERROR_DS_UNAVAILABLE = 0x000025F5; // 9717

        /// <summary>
        ///     DNS zone already exists in the directory service.
        /// </summary>
        public const int DNS_ERROR_DS_ZONE_ALREADY_EXISTS = 0x000025F6; // 9718

        /// <summary>
        ///     DNS server not creating or reading the boot file for the directory service integrated DNS zone.
        /// </summary>
        public const int DNS_ERROR_NO_BOOTFILE_IF_DS_ZONE = 0x000025F7; // 9719

        /// <summary>
        ///     Node is a DNAME DNS record.
        /// </summary>
        public const int DNS_ERROR_NODE_IS_DNAME = 0x000025F8; // 9720

        /// <summary>
        ///     A DNAME record already exists for given name.
        /// </summary>
        public const int DNS_ERROR_DNAME_COLLISION = 0x000025F9; // 9721

        /// <summary>
        ///     An alias loop has been detected with either CNAME or DNAME records.
        /// </summary>
        public const int DNS_ERROR_ALIAS_LOOP = 0x000025FA; // 9722

        /// <summary>
        ///     DNS AXFR (zone transfer) complete.
        /// </summary>
        public const int DNS_INFO_AXFR_COMPLETE = 0x00002617; // 9751

        /// <summary>
        ///     DNS zone transfer failed.
        /// </summary>
        public const int DNS_ERROR_AXFR = 0x00002618; // 9752

        /// <summary>
        ///     Added local WINS server.
        /// </summary>
        public const int DNS_INFO_ADDED_LOCAL_WINS = 0x00002619; // 9753

        /// <summary>
        ///     Secure update call needs to continue update request.
        /// </summary>
        public const int DNS_STATUS_CONTINUE_NEEDED = 0x00002649; // 9801

        /// <summary>
        ///     TCP/IP network protocol not installed.
        /// </summary>
        public const int DNS_ERROR_NO_TCPIP = 0x0000267B; // 9851

        /// <summary>
        ///     No DNS servers configured for local system.
        /// </summary>
        public const int DNS_ERROR_NO_DNS_SERVERS = 0x0000267C; // 9852

        /// <summary>
        ///     The specified directory partition does not exist.
        /// </summary>
        public const int DNS_ERROR_DP_DOES_NOT_EXIST = 0x000026AD; // 9901

        /// <summary>
        ///     The specified directory partition already exists.
        /// </summary>
        public const int DNS_ERROR_DP_ALREADY_EXISTS = 0x000026AE; // 9902

        /// <summary>
        ///     This DNS server is not enlisted in the specified directory partition.
        /// </summary>
        public const int DNS_ERROR_DP_NOT_ENLISTED = 0x000026AF; // 9903

        /// <summary>
        ///     This DNS server is already enlisted in the specified directory partition.
        /// </summary>
        public const int DNS_ERROR_DP_ALREADY_ENLISTED = 0x000026B0; // 9904

        /// <summary>
        ///     The directory partition is not available at this time. Please wait a few minutes and try again.
        /// </summary>
        public const int DNS_ERROR_DP_NOT_AVAILABLE = 0x000026B1; // 9905

        /// <summary>
        ///     The operation failed because the domain naming master FSMO role could not be reached. The domain controller holding
        ///     the domain naming master FSMO role is down or unable to service the request or is not running Windows Server 2003
        ///     or later.
        /// </summary>
        public const int DNS_ERROR_DP_FSMO_ERROR = 0x000026B2; // 9906

        /// <summary>
        ///     A blocking operation was interrupted by a call to WSACancelBlockingCall.
        /// </summary>
        public const int WSAEINTR = 0x00002714; // 10004

        /// <summary>
        ///     The file handle supplied is not valid.
        /// </summary>
        public const int WSAEBADF = 0x00002719; // 10009

        /// <summary>
        ///     An attempt was made to access a socket in a way forbidden by its access permissions.
        /// </summary>
        public const int WSAEACCES = 0x0000271D; // 10013

        /// <summary>
        ///     The system detected an invalid pointer address in attempting to use a pointer argument in a call.
        /// </summary>
        public const int WSAEFAULT = 0x0000271E; // 10014

        /// <summary>
        ///     An invalid argument was supplied.
        /// </summary>
        public const int WSAEINVAL = 0x00002726; // 10022

        /// <summary>
        ///     Too many open sockets.
        /// </summary>
        public const int WSAEMFILE = 0x00002728; // 10024

        /// <summary>
        ///     A non-blocking socket operation could not be completed immediately.
        /// </summary>
        public const int WSAEWOULDBLOCK = 0x00002733; // 10035

        /// <summary>
        ///     A blocking operation is currently executing.
        /// </summary>
        public const int WSAEINPROGRESS = 0x00002734; // 10036

        /// <summary>
        ///     An operation was attempted on a non-blocking socket that already had an operation in progress.
        /// </summary>
        public const int WSAEALREADY = 0x00002735; // 10037

        /// <summary>
        ///     An operation was attempted on something that is not a socket.
        /// </summary>
        public const int WSAENOTSOCK = 0x00002736; // 10038

        /// <summary>
        ///     A required address was omitted from an operation on a socket.
        /// </summary>
        public const int WSAEDESTADDRREQ = 0x00002737; // 10039

        /// <summary>
        ///     A message sent on a datagram socket was larger than the internal message buffer or some other network limit, or the
        ///     buffer used to receive a datagram into was smaller than the datagram itself.
        /// </summary>
        public const int WSAEMSGSIZE = 0x00002738; // 10040

        /// <summary>
        ///     A protocol was specified in the socket function call that does not support the semantics of the socket type
        ///     requested.
        /// </summary>
        public const int WSAEPROTOTYPE = 0x00002739; // 10041

        /// <summary>
        ///     An unknown, invalid, or unsupported option or level was specified in a getsockopt or setsockopt call.
        /// </summary>
        public const int WSAENOPROTOOPT = 0x0000273A; // 10042

        /// <summary>
        ///     The requested protocol has not been configured into the system, or no implementation for it exists.
        /// </summary>
        public const int WSAEPROTONOSUPPORT = 0x0000273B; // 10043

        /// <summary>
        ///     The support for the specified socket type does not exist in this address family.
        /// </summary>
        public const int WSAESOCKTNOSUPPORT = 0x0000273C; // 10044

        /// <summary>
        ///     The attempted operation is not supported for the type of object referenced.
        /// </summary>
        public const int WSAEOPNOTSUPP = 0x0000273D; // 10045

        /// <summary>
        ///     The protocol family has not been configured into the system or no implementation for it exists.
        /// </summary>
        public const int WSAEPFNOSUPPORT = 0x0000273E; // 10046

        /// <summary>
        ///     An address incompatible with the requested protocol was used.
        /// </summary>
        public const int WSAEAFNOSUPPORT = 0x0000273F; // 10047

        /// <summary>
        ///     Only one usage of each socket address (protocol/network address/port) is normally permitted.
        /// </summary>
        public const int WSAEADDRINUSE = 0x00002740; // 10048

        /// <summary>
        ///     The requested address is not valid in its context.
        /// </summary>
        public const int WSAEADDRNOTAVAIL = 0x00002741; // 10049

        /// <summary>
        ///     A socket operation encountered a dead network.
        /// </summary>
        public const int WSAENETDOWN = 0x00002742; // 10050

        /// <summary>
        ///     A socket operation was attempted to an unreachable network.
        /// </summary>
        public const int WSAENETUNREACH = 0x00002743; // 10051

        /// <summary>
        ///     The connection has been broken due to keep-alive activity detecting a failure while the operation was in progress.
        /// </summary>
        public const int WSAENETRESET = 0x00002744; // 10052

        /// <summary>
        ///     An established connection was aborted by the software in your host machine.
        /// </summary>
        public const int WSAECONNABORTED = 0x00002745; // 10053

        /// <summary>
        ///     An existing connection was forcibly closed by the remote host.
        /// </summary>
        public const int WSAECONNRESET = 0x00002746; // 10054

        /// <summary>
        ///     An operation on a socket could not be performed because the system lacked sufficient buffer space or because a
        ///     queue was full.
        /// </summary>
        public const int WSAENOBUFS = 0x00002747; // 10055

        /// <summary>
        ///     A connect request was made on an already connected socket.
        /// </summary>
        public const int WSAEISCONN = 0x00002748; // 10056

        /// <summary>
        ///     A request to send or receive data was disallowed because the socket is not connected and (when sending on a
        ///     datagram socket using a sendto call) no address was supplied.
        /// </summary>
        public const int WSAENOTCONN = 0x00002749; // 10057

        /// <summary>
        ///     A request to send or receive data was disallowed because the socket had already been shut down in that direction
        ///     with a previous shutdown call.
        /// </summary>
        public const int WSAESHUTDOWN = 0x0000274A; // 10058

        /// <summary>
        ///     Too many references to some kernel object.
        /// </summary>
        public const int WSAETOOMANYREFS = 0x0000274B; // 10059

        /// <summary>
        ///     A connection attempt failed because the connected party did not properly respond after a period of time, or
        ///     established connection failed because connected host has failed to respond.
        /// </summary>
        public const int WSAETIMEDOUT = 0x0000274C; // 10060

        /// <summary>
        ///     No connection could be made because the target machine actively refused it.
        /// </summary>
        public const int WSAECONNREFUSED = 0x0000274D; // 10061

        /// <summary>
        ///     Cannot translate name.
        /// </summary>
        public const int WSAELOOP = 0x0000274E; // 10062

        /// <summary>
        ///     Name component or name was too long.
        /// </summary>
        public const int WSAENAMETOOLONG = 0x0000274F; // 10063

        /// <summary>
        ///     A socket operation failed because the destination host was down.
        /// </summary>
        public const int WSAEHOSTDOWN = 0x00002750; // 10064

        /// <summary>
        ///     A socket operation was attempted to an unreachable host.
        /// </summary>
        public const int WSAEHOSTUNREACH = 0x00002751; // 10065

        /// <summary>
        ///     Cannot remove a directory that is not empty.
        /// </summary>
        public const int WSAENOTEMPTY = 0x00002752; // 10066

        /// <summary>
        ///     A Windows Sockets implementation may have a limit on the number of applications that may use it simultaneously.
        /// </summary>
        public const int WSAEPROCLIM = 0x00002753; // 10067

        /// <summary>
        ///     Ran out of quota.
        /// </summary>
        public const int WSAEUSERS = 0x00002754; // 10068

        /// <summary>
        ///     Ran out of disk quota.
        /// </summary>
        public const int WSAEDQUOT = 0x00002755; // 10069

        /// <summary>
        ///     File handle reference is no longer available.
        /// </summary>
        public const int WSAESTALE = 0x00002756; // 10070

        /// <summary>
        ///     Item is not available locally.
        /// </summary>
        public const int WSAEREMOTE = 0x00002757; // 10071

        /// <summary>
        ///     WSAStartup cannot function at this time because the underlying system it uses to provide network services is
        ///     currently unavailable.
        /// </summary>
        public const int WSASYSNOTREADY = 0x0000276B; // 10091

        /// <summary>
        ///     The Windows Sockets version requested is not supported.
        /// </summary>
        public const int WSAVERNOTSUPPORTED = 0x0000276C; // 10092

        /// <summary>
        ///     Either the application has not called WSAStartup, or WSAStartup failed.
        /// </summary>
        public const int WSANOTINITIALISED = 0x0000276D; // 10093

        /// <summary>
        ///     Returned by WSARecv or WSARecvFrom to indicate the remote party has initiated a graceful shutdown sequence.
        /// </summary>
        public const int WSAEDISCON = 0x00002775; // 10101

        /// <summary>
        ///     No more results can be returned by WSALookupServiceNext.
        /// </summary>
        public const int WSAENOMORE = 0x00002776; // 10102

        /// <summary>
        ///     A call to WSALookupServiceEnd was made while this call was still processing. The call has been canceled.
        /// </summary>
        public const int WSAECANCELLED = 0x00002777; // 10103

        /// <summary>
        ///     The procedure call table is invalid.
        /// </summary>
        public const int WSAEINVALIDPROCTABLE = 0x00002778; // 10104

        /// <summary>
        ///     The requested service provider is invalid.
        /// </summary>
        public const int WSAEINVALIDPROVIDER = 0x00002779; // 10105

        /// <summary>
        ///     The requested service provider could not be loaded or initialized.
        /// </summary>
        public const int WSAEPROVIDERFAILEDINIT = 0x0000277A; // 10106

        /// <summary>
        ///     A system call has failed.
        /// </summary>
        public const int WSASYSCALLFAILURE = 0x0000277B; // 10107

        /// <summary>
        ///     No such service is known. The service cannot be found in the specified name space.
        /// </summary>
        public const int WSASERVICE_NOT_FOUND = 0x0000277C; // 10108

        /// <summary>
        ///     The specified class was not found.
        /// </summary>
        public const int WSATYPE_NOT_FOUND = 0x0000277D; // 10109

        /// <summary>
        ///     No more results can be returned by WSALookupServiceNext.
        /// </summary>
        public const int WSA_E_NO_MORE = 0x0000277E; // 10110

        /// <summary>
        ///     A call to WSALookupServiceEnd was made while this call was still processing. The call has been canceled.
        /// </summary>
        public const int WSA_E_CANCELLED = 0x0000277F; // 10111

        /// <summary>
        ///     A database query failed because it was actively refused.
        /// </summary>
        public const int WSAEREFUSED = 0x00002780; // 10112

        /// <summary>
        ///     No such host is known.
        /// </summary>
        public const int WSAHOST_NOT_FOUND = 0x00002AF9; // 11001

        /// <summary>
        ///     This is usually a temporary error during hostname resolution and means that the local server did not receive a
        ///     response from an authoritative server.
        /// </summary>
        public const int WSATRY_AGAIN = 0x00002AFA; // 11002

        /// <summary>
        ///     A non-recoverable error occurred during a database lookup.
        /// </summary>
        public const int WSANO_RECOVERY = 0x00002AFB; // 11003

        /// <summary>
        ///     The requested name is valid, but no data of the requested type was found.
        /// </summary>
        public const int WSANO_DATA = 0x00002AFC; // 11004

        /// <summary>
        ///     At least one reserve has arrived.
        /// </summary>
        public const int WSA_QOS_RECEIVERS = 0x00002AFD; // 11005

        /// <summary>
        ///     At least one path has arrived.
        /// </summary>
        public const int WSA_QOS_SENDERS = 0x00002AFE; // 11006

        /// <summary>
        ///     There are no senders.
        /// </summary>
        public const int WSA_QOS_NO_SENDERS = 0x00002AFF; // 11007

        /// <summary>
        ///     There are no receivers.
        /// </summary>
        public const int WSA_QOS_NO_RECEIVERS = 0x00002B00; // 11008

        /// <summary>
        ///     Reserve has been confirmed.
        /// </summary>
        public const int WSA_QOS_REQUEST_CONFIRMED = 0x00002B01; // 11009

        /// <summary>
        ///     Error due to lack of resources.
        /// </summary>
        public const int WSA_QOS_ADMISSION_FAILURE = 0x00002B02; // 11010

        /// <summary>
        ///     Rejected for administrative reasons - bad credentials.
        /// </summary>
        public const int WSA_QOS_POLICY_FAILURE = 0x00002B03; // 11011

        /// <summary>
        ///     Unknown or conflicting style.
        /// </summary>
        public const int WSA_QOS_BAD_STYLE = 0x00002B04; // 11012

        /// <summary>
        ///     Problem with some part of the filterspec or providerspecific buffer in general.
        /// </summary>
        public const int WSA_QOS_BAD_OBJECT = 0x00002B05; // 11013

        /// <summary>
        ///     Problem with some part of the flowspec.
        /// </summary>
        public const int WSA_QOS_TRAFFIC_CTRL_ERROR = 0x00002B06; // 11014

        /// <summary>
        ///     General QOS error.
        /// </summary>
        public const int WSA_QOS_GENERIC_ERROR = 0x00002B07; // 11015

        /// <summary>
        ///     An invalid or unrecognized service type was found in the flowspec.
        /// </summary>
        public const int WSA_QOS_ESERVICETYPE = 0x00002B08; // 11016

        /// <summary>
        ///     An invalid or inconsistent flowspec was found in the QOS structure.
        /// </summary>
        public const int WSA_QOS_EFLOWSPEC = 0x00002B09; // 11017

        /// <summary>
        ///     Invalid QOS provider-specific buffer.
        /// </summary>
        public const int WSA_QOS_EPROVSPECBUF = 0x00002B0A; // 11018

        /// <summary>
        ///     An invalid QOS filter style was used.
        /// </summary>
        public const int WSA_QOS_EFILTERSTYLE = 0x00002B0B; // 11019

        /// <summary>
        ///     An invalid QOS filter type was used.
        /// </summary>
        public const int WSA_QOS_EFILTERTYPE = 0x00002B0C; // 11020

        /// <summary>
        ///     An incorrect number of QOS FILTERSPECs were specified in the FLOWDESCRIPTOR.
        /// </summary>
        public const int WSA_QOS_EFILTERCOUNT = 0x00002B0D; // 11021

        /// <summary>
        ///     An object with an invalid ObjectLength field was specified in the QOS provider-specific buffer.
        /// </summary>
        public const int WSA_QOS_EOBJLENGTH = 0x00002B0E; // 11022

        /// <summary>
        ///     An incorrect number of flow descriptors was specified in the QOS structure.
        /// </summary>
        public const int WSA_QOS_EFLOWCOUNT = 0x00002B0F; // 11023

        /// <summary>
        ///     An unrecognized object was found in the QOS provider-specific buffer.
        /// </summary>
        public const int WSA_QOS_EUNKOWNPSOBJ = 0x00002B10; // 11024

        /// <summary>
        ///     An invalid policy object was found in the QOS provider-specific buffer.
        /// </summary>
        public const int WSA_QOS_EPOLICYOBJ = 0x00002B11; // 11025

        /// <summary>
        ///     An invalid QOS flow descriptor was found in the flow descriptor list.
        /// </summary>
        public const int WSA_QOS_EFLOWDESC = 0x00002B12; // 11026

        /// <summary>
        ///     An invalid or inconsistent flowspec was found in the QOS provider specific buffer.
        /// </summary>
        public const int WSA_QOS_EPSFLOWSPEC = 0x00002B13; // 11027

        /// <summary>
        ///     An invalid FILTERSPEC was found in the QOS provider-specific buffer.
        /// </summary>
        public const int WSA_QOS_EPSFILTERSPEC = 0x00002B14; // 11028

        /// <summary>
        ///     An invalid shape discard mode object was found in the QOS provider specific buffer.
        /// </summary>
        public const int WSA_QOS_ESDMODEOBJ = 0x00002B15; // 11029

        /// <summary>
        ///     An invalid shaping rate object was found in the QOS provider-specific buffer.
        /// </summary>
        public const int WSA_QOS_ESHAPERATEOBJ = 0x00002B16; // 11030

        /// <summary>
        ///     A reserved policy element was found in the QOS provider-specific buffer.
        /// </summary>
        public const int WSA_QOS_RESERVED_PETYPE = 0x00002B17; // 11031

        /// <summary>
        ///     No such host is known securely.
        /// </summary>
        public const int WSA_SECURE_HOST_NOT_FOUND = 0x00002B18; // 11032

        /// <summary>
        ///     Name based IPSEC policy could not be added.
        /// </summary>
        public const int WSA_IPSEC_NAME_POLICY_ERROR = 0x00002B19; // 11033

        #endregion

        #region 12000 - 15999

        /// <summary>
        ///     The specified quick mode policy already exists.
        /// </summary>
        public const int ERROR_IPSEC_QM_POLICY_EXISTS = 0x000032C8; // 13000

        /// <summary>
        ///     The specified quick mode policy was not found.
        /// </summary>
        public const int ERROR_IPSEC_QM_POLICY_NOT_FOUND = 0x000032C9; // 13001

        /// <summary>
        ///     The specified quick mode policy is being used.
        /// </summary>
        public const int ERROR_IPSEC_QM_POLICY_IN_USE = 0x000032CA; // 13002

        /// <summary>
        ///     The specified main mode policy already exists.
        /// </summary>
        public const int ERROR_IPSEC_MM_POLICY_EXISTS = 0x000032CB; // 13003

        /// <summary>
        ///     The specified main mode policy was not found.
        /// </summary>
        public const int ERROR_IPSEC_MM_POLICY_NOT_FOUND = 0x000032CC; // 13004

        /// <summary>
        ///     The specified main mode policy is being used.
        /// </summary>
        public const int ERROR_IPSEC_MM_POLICY_IN_USE = 0x000032CD; // 13005

        /// <summary>
        ///     The specified main mode filter already exists.
        /// </summary>
        public const int ERROR_IPSEC_MM_FILTER_EXISTS = 0x000032CE; // 13006

        /// <summary>
        ///     The specified main mode filter was not found.
        /// </summary>
        public const int ERROR_IPSEC_MM_FILTER_NOT_FOUND = 0x000032CF; // 13007

        /// <summary>
        ///     The specified transport mode filter already exists.
        /// </summary>
        public const int ERROR_IPSEC_TRANSPORT_FILTER_EXISTS = 0x000032D0; // 13008

        /// <summary>
        ///     The specified transport mode filter does not exist.
        /// </summary>
        public const int ERROR_IPSEC_TRANSPORT_FILTER_NOT_FOUND = 0x000032D1; // 13009

        /// <summary>
        ///     The specified main mode authentication list exists.
        /// </summary>
        public const int ERROR_IPSEC_MM_AUTH_EXISTS = 0x000032D2; // 13010

        /// <summary>
        ///     The specified main mode authentication list was not found.
        /// </summary>
        public const int ERROR_IPSEC_MM_AUTH_NOT_FOUND = 0x000032D3; // 13011

        /// <summary>
        ///     The specified main mode authentication list is being used.
        /// </summary>
        public const int ERROR_IPSEC_MM_AUTH_IN_USE = 0x000032D4; // 13012

        /// <summary>
        ///     The specified default main mode policy was not found.
        /// </summary>
        public const int ERROR_IPSEC_DEFAULT_MM_POLICY_NOT_FOUND = 0x000032D5; // 13013

        /// <summary>
        ///     The specified default main mode authentication list was not found.
        /// </summary>
        public const int ERROR_IPSEC_DEFAULT_MM_AUTH_NOT_FOUND = 0x000032D6; // 13014

        /// <summary>
        ///     The specified default quick mode policy was not found.
        /// </summary>
        public const int ERROR_IPSEC_DEFAULT_QM_POLICY_NOT_FOUND = 0x000032D7; // 13015

        /// <summary>
        ///     The specified tunnel mode filter exists.
        /// </summary>
        public const int ERROR_IPSEC_TUNNEL_FILTER_EXISTS = 0x000032D8; // 13016

        /// <summary>
        ///     The specified tunnel mode filter was not found.
        /// </summary>
        public const int ERROR_IPSEC_TUNNEL_FILTER_NOT_FOUND = 0x000032D9; // 13017

        /// <summary>
        ///     The Main Mode filter is pending deletion.
        /// </summary>
        public const int ERROR_IPSEC_MM_FILTER_PENDING_DELETION = 0x000032DA; // 13018

        /// <summary>
        ///     The transport filter is pending deletion.
        /// </summary>
        public const int ERROR_IPSEC_TRANSPORT_FILTER_PENDING_DELETION = 0x000032DB; // 13019

        /// <summary>
        ///     The tunnel filter is pending deletion.
        /// </summary>
        public const int ERROR_IPSEC_TUNNEL_FILTER_PENDING_DELETION = 0x000032DC; // 13020

        /// <summary>
        ///     The Main Mode policy is pending deletion.
        /// </summary>
        public const int ERROR_IPSEC_MM_POLICY_PENDING_DELETION = 0x000032DD; // 13021

        /// <summary>
        ///     The Main Mode authentication bundle is pending deletion.
        /// </summary>
        public const int ERROR_IPSEC_MM_AUTH_PENDING_DELETION = 0x000032DE; // 13022

        /// <summary>
        ///     The Quick Mode policy is pending deletion.
        /// </summary>
        public const int ERROR_IPSEC_QM_POLICY_PENDING_DELETION = 0x000032DF; // 13023

        /// <summary>
        ///     The Main Mode policy was successfully added, but some of the requested offers are not supported.
        /// </summary>
        public const int WARNING_IPSEC_MM_POLICY_PRUNED = 0x000032E0; // 13024

        /// <summary>
        ///     The Quick Mode policy was successfully added, but some of the requested offers are not supported.
        /// </summary>
        public const int WARNING_IPSEC_QM_POLICY_PRUNED = 0x000032E1; // 13025

        /// <summary>
        ///     ERROR_IPSEC_IKE_NEG_STATUS_BEGIN
        /// </summary>
        public const int ERROR_IPSEC_IKE_NEG_STATUS_BEGIN = 0x000035E8; // 13800

        /// <summary>
        ///     IKE authentication credentials are unacceptable.
        /// </summary>
        public const int ERROR_IPSEC_IKE_AUTH_FAIL = 0x000035E9; // 13801

        /// <summary>
        ///     IKE security attributes are unacceptable.
        /// </summary>
        public const int ERROR_IPSEC_IKE_ATTRIB_FAIL = 0x000035EA; // 13802

        /// <summary>
        ///     IKE Negotiation in progress.
        /// </summary>
        public const int ERROR_IPSEC_IKE_NEGOTIATION_PENDING = 0x000035EB; // 13803

        /// <summary>
        ///     General processing error.
        /// </summary>
        public const int ERROR_IPSEC_IKE_GENERAL_PROCESSING_ERROR = 0x000035EC; // 13804

        /// <summary>
        ///     Negotiation timed out.
        /// </summary>
        public const int ERROR_IPSEC_IKE_TIMED_OUT = 0x000035ED; // 13805

        /// <summary>
        ///     IKE failed to find valid machine certificate. Contact your Network Security Administrator about installing a valid
        ///     certificate in the appropriate Certificate Store.
        /// </summary>
        public const int ERROR_IPSEC_IKE_NO_CERT = 0x000035EE; // 13806

        /// <summary>
        ///     IKE SA deleted by peer before establishment completed.
        /// </summary>
        public const int ERROR_IPSEC_IKE_SA_DELETED = 0x000035EF; // 13807

        /// <summary>
        ///     IKE SA deleted before establishment completed.
        /// </summary>
        public const int ERROR_IPSEC_IKE_SA_REAPED = 0x000035F0; // 13808

        /// <summary>
        ///     Negotiation request sat in Queue too long.
        /// </summary>
        public const int ERROR_IPSEC_IKE_MM_ACQUIRE_DROP = 0x000035F1; // 13809

        /// <summary>
        ///     Negotiation request sat in Queue too long.
        /// </summary>
        public const int ERROR_IPSEC_IKE_QM_ACQUIRE_DROP = 0x000035F2; // 13810

        /// <summary>
        ///     Negotiation request sat in Queue too long.
        /// </summary>
        public const int ERROR_IPSEC_IKE_QUEUE_DROP_MM = 0x000035F3; // 13811

        /// <summary>
        ///     Negotiation request sat in Queue too long.
        /// </summary>
        public const int ERROR_IPSEC_IKE_QUEUE_DROP_NO_MM = 0x000035F4; // 13812

        /// <summary>
        ///     No response from peer.
        /// </summary>
        public const int ERROR_IPSEC_IKE_DROP_NO_RESPONSE = 0x000035F5; // 13813

        /// <summary>
        ///     Negotiation took too long.
        /// </summary>
        public const int ERROR_IPSEC_IKE_MM_DELAY_DROP = 0x000035F6; // 13814

        /// <summary>
        ///     Negotiation took too long.
        /// </summary>
        public const int ERROR_IPSEC_IKE_QM_DELAY_DROP = 0x000035F7; // 13815

        /// <summary>
        ///     Unknown error occurred.
        /// </summary>
        public const int ERROR_IPSEC_IKE_ERROR = 0x000035F8; // 13816

        /// <summary>
        ///     Certificate Revocation Check failed.
        /// </summary>
        public const int ERROR_IPSEC_IKE_CRL_FAILED = 0x000035F9; // 13817

        /// <summary>
        ///     Invalid certificate key usage.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_KEY_USAGE = 0x000035FA; // 13818

        /// <summary>
        ///     Invalid certificate type.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_CERT_TYPE = 0x000035FB; // 13819

        /// <summary>
        ///     IKE negotiation failed because the machine certificate used does not have a private key. IPsec certificates require
        ///     a private key. Contact your Network Security administrator about replacing with a certificate that has a private
        ///     key.
        /// </summary>
        public const int ERROR_IPSEC_IKE_NO_PRIVATE_KEY = 0x000035FC; // 13820

        /// <summary>
        ///     Simultaneous rekeys were detected.
        /// </summary>
        public const int ERROR_IPSEC_IKE_SIMULTANEOUS_REKEY = 0x000035FD; // 13821

        /// <summary>
        ///     Failure in Diffie-Hellman computation.
        /// </summary>
        public const int ERROR_IPSEC_IKE_DH_FAIL = 0x000035FE; // 13822

        /// <summary>
        ///     Don't know how to process critical payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_CRITICAL_PAYLOAD_NOT_RECOGNIZED = 0x000035FF; // 13823

        /// <summary>
        ///     Invalid header.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_HEADER = 0x00003600; // 13824

        /// <summary>
        ///     No policy configured.
        /// </summary>
        public const int ERROR_IPSEC_IKE_NO_POLICY = 0x00003601; // 13825

        /// <summary>
        ///     Failed to verify signature.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_SIGNATURE = 0x00003602; // 13826

        /// <summary>
        ///     Failed to authenticate using Kerberos.
        /// </summary>
        public const int ERROR_IPSEC_IKE_KERBEROS_ERROR = 0x00003603; // 13827

        /// <summary>
        ///     Peer's certificate did not have a public key.
        /// </summary>
        public const int ERROR_IPSEC_IKE_NO_PUBLIC_KEY = 0x00003604; // 13828

        /// <summary>
        ///     Error processing error payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PROCESS_ERR = 0x00003605; // 13829

        /// <summary>
        ///     Error processing SA payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PROCESS_ERR_SA = 0x00003606; // 13830

        /// <summary>
        ///     Error processing Proposal payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PROCESS_ERR_PROP = 0x00003607; // 13831

        /// <summary>
        ///     Error processing Transform payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PROCESS_ERR_TRANS = 0x00003608; // 13832

        /// <summary>
        ///     Error processing KE payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PROCESS_ERR_KE = 0x00003609; // 13833

        /// <summary>
        ///     Error processing ID payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PROCESS_ERR_ID = 0x0000360A; // 13834

        /// <summary>
        ///     Error processing Cert payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PROCESS_ERR_CERT = 0x0000360B; // 13835

        /// <summary>
        ///     Error processing Certificate Request payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PROCESS_ERR_CERT_REQ = 0x0000360C; // 13836

        /// <summary>
        ///     Error processing Hash payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PROCESS_ERR_HASH = 0x0000360D; // 13837

        /// <summary>
        ///     Error processing Signature payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PROCESS_ERR_SIG = 0x0000360E; // 13838

        /// <summary>
        ///     Error processing Nonce payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PROCESS_ERR_NONCE = 0x0000360F; // 13839

        /// <summary>
        ///     Error processing Notify payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PROCESS_ERR_NOTIFY = 0x00003610; // 13840

        /// <summary>
        ///     Error processing Delete Payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PROCESS_ERR_DELETE = 0x00003611; // 13841

        /// <summary>
        ///     Error processing VendorId payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PROCESS_ERR_VENDOR = 0x00003612; // 13842

        /// <summary>
        ///     Invalid payload received.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_PAYLOAD = 0x00003613; // 13843

        /// <summary>
        ///     Soft SA loaded.
        /// </summary>
        public const int ERROR_IPSEC_IKE_LOAD_SOFT_SA = 0x00003614; // 13844

        /// <summary>
        ///     Soft SA torn down.
        /// </summary>
        public const int ERROR_IPSEC_IKE_SOFT_SA_TORN_DOWN = 0x00003615; // 13845

        /// <summary>
        ///     Invalid cookie received.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_COOKIE = 0x00003616; // 13846

        /// <summary>
        ///     Peer failed to send valid machine certificate.
        /// </summary>
        public const int ERROR_IPSEC_IKE_NO_PEER_CERT = 0x00003617; // 13847

        /// <summary>
        ///     Certification Revocation check of peer's certificate failed.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PEER_CRL_FAILED = 0x00003618; // 13848

        /// <summary>
        ///     New policy invalidated SAs formed with old policy.
        /// </summary>
        public const int ERROR_IPSEC_IKE_POLICY_CHANGE = 0x00003619; // 13849

        /// <summary>
        ///     There is no available Main Mode IKE policy.
        /// </summary>
        public const int ERROR_IPSEC_IKE_NO_MM_POLICY = 0x0000361A; // 13850

        /// <summary>
        ///     Failed to enabled TCB privilege.
        /// </summary>
        public const int ERROR_IPSEC_IKE_NOTCBPRIV = 0x0000361B; // 13851

        /// <summary>
        ///     Failed to load SECURITY.DLL.
        /// </summary>
        public const int ERROR_IPSEC_IKE_SECLOADFAIL = 0x0000361C; // 13852

        /// <summary>
        ///     Failed to obtain security function table dispatch address from SSPI.
        /// </summary>
        public const int ERROR_IPSEC_IKE_FAILSSPINIT = 0x0000361D; // 13853

        /// <summary>
        ///     Failed to query Kerberos package to obtain max token size.
        /// </summary>
        public const int ERROR_IPSEC_IKE_FAILQUERYSSP = 0x0000361E; // 13854

        /// <summary>
        ///     Failed to obtain Kerberos server credentials for ISAKMP/ERROR_IPSEC_IKE service. Kerberos authentication will not
        ///     function. The most likely reason for this is lack of domain membership. This is normal if your computer is a member
        ///     of a workgroup.
        /// </summary>
        public const int ERROR_IPSEC_IKE_SRVACQFAIL = 0x0000361F; // 13855

        /// <summary>
        ///     Failed to determine SSPI principal name for ISAKMP/ERROR_IPSEC_IKE service (QueryCredentialsAttributes).
        /// </summary>
        public const int ERROR_IPSEC_IKE_SRVQUERYCRED = 0x00003620; // 13856

        /// <summary>
        ///     Failed to obtain new SPI for the inbound SA from IPsec driver. The most common cause for this is that the driver
        ///     does not have the correct filter. Check your policy to verify the filters.
        /// </summary>
        public const int ERROR_IPSEC_IKE_GETSPIFAIL = 0x00003621; // 13857

        /// <summary>
        ///     Given filter is invalid.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_FILTER = 0x00003622; // 13858

        /// <summary>
        ///     Memory allocation failed.
        /// </summary>
        public const int ERROR_IPSEC_IKE_OUT_OF_MEMORY = 0x00003623; // 13859

        /// <summary>
        ///     Failed to add Security Association to IPsec Driver. The most common cause for this is if the IKE negotiation took
        ///     too long to complete. If the problem persists, reduce the load on the faulting machine.
        /// </summary>
        public const int ERROR_IPSEC_IKE_ADD_UPDATE_KEY_FAILED = 0x00003624; // 13860

        /// <summary>
        ///     Invalid policy.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_POLICY = 0x00003625; // 13861

        /// <summary>
        ///     Invalid DOI.
        /// </summary>
        public const int ERROR_IPSEC_IKE_UNKNOWN_DOI = 0x00003626; // 13862

        /// <summary>
        ///     Invalid situation.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_SITUATION = 0x00003627; // 13863

        /// <summary>
        ///     Diffie-Hellman failure.
        /// </summary>
        public const int ERROR_IPSEC_IKE_DH_FAILURE = 0x00003628; // 13864

        /// <summary>
        ///     Invalid Diffie-Hellman group.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_GROUP = 0x00003629; // 13865

        /// <summary>
        ///     Error encrypting payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_ENCRYPT = 0x0000362A; // 13866

        /// <summary>
        ///     Error decrypting payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_DECRYPT = 0x0000362B; // 13867

        /// <summary>
        ///     Policy match error.
        /// </summary>
        public const int ERROR_IPSEC_IKE_POLICY_MATCH = 0x0000362C; // 13868

        /// <summary>
        ///     Unsupported ID.
        /// </summary>
        public const int ERROR_IPSEC_IKE_UNSUPPORTED_ID = 0x0000362D; // 13869

        /// <summary>
        ///     Hash verification failed.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_HASH = 0x0000362E; // 13870

        /// <summary>
        ///     Invalid hash algorithm.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_HASH_ALG = 0x0000362F; // 13871

        /// <summary>
        ///     Invalid hash size.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_HASH_SIZE = 0x00003630; // 13872

        /// <summary>
        ///     Invalid encryption algorithm.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_ENCRYPT_ALG = 0x00003631; // 13873

        /// <summary>
        ///     Invalid authentication algorithm.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_AUTH_ALG = 0x00003632; // 13874

        /// <summary>
        ///     Invalid certificate signature.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_SIG = 0x00003633; // 13875

        /// <summary>
        ///     Load failed.
        /// </summary>
        public const int ERROR_IPSEC_IKE_LOAD_FAILED = 0x00003634; // 13876

        /// <summary>
        ///     Deleted via RPC call.
        /// </summary>
        public const int ERROR_IPSEC_IKE_RPC_DELETE = 0x00003635; // 13877

        /// <summary>
        ///     Temporary state created to perform reinitialization. This is not a real failure.
        /// </summary>
        public const int ERROR_IPSEC_IKE_BENIGN_REINIT = 0x00003636; // 13878

        /// <summary>
        ///     The lifetime value received in the Responder Lifetime Notify is below the Windows 2000 configured minimum value.
        ///     Please fix the policy on the peer machine.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_RESPONDER_LIFETIME_NOTIFY = 0x00003637; // 13879

        /// <summary>
        ///     The recipient cannot handle version of IKE specified in the header.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_MAJOR_VERSION = 0x00003638; // 13880

        /// <summary>
        ///     Key length in certificate is too small for configured security requirements.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_CERT_KEYLEN = 0x00003639; // 13881

        /// <summary>
        ///     Max number of established MM SAs to peer exceeded.
        /// </summary>
        public const int ERROR_IPSEC_IKE_MM_LIMIT = 0x0000363A; // 13882

        /// <summary>
        ///     IKE received a policy that disables negotiation.
        /// </summary>
        public const int ERROR_IPSEC_IKE_NEGOTIATION_DISABLED = 0x0000363B; // 13883

        /// <summary>
        ///     Reached maximum quick mode limit for the main mode. New main mode will be started.
        /// </summary>
        public const int ERROR_IPSEC_IKE_QM_LIMIT = 0x0000363C; // 13884

        /// <summary>
        ///     Main mode SA lifetime expired or peer sent a main mode delete.
        /// </summary>
        public const int ERROR_IPSEC_IKE_MM_EXPIRED = 0x0000363D; // 13885

        /// <summary>
        ///     Main mode SA assumed to be invalid because peer stopped responding.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PEER_MM_ASSUMED_INVALID = 0x0000363E; // 13886

        /// <summary>
        ///     Certificate doesn't chain to a trusted root in IPsec policy.
        /// </summary>
        public const int ERROR_IPSEC_IKE_CERT_CHAIN_POLICY_MISMATCH = 0x0000363F; // 13887

        /// <summary>
        ///     Received unexpected message ID.
        /// </summary>
        public const int ERROR_IPSEC_IKE_UNEXPECTED_MESSAGE_ID = 0x00003640; // 13888

        /// <summary>
        ///     Received invalid authentication offers.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_AUTH_PAYLOAD = 0x00003641; // 13889

        /// <summary>
        ///     Sent DoS cookie notify to initiator.
        /// </summary>
        public const int ERROR_IPSEC_IKE_DOS_COOKIE_SENT = 0x00003642; // 13890

        /// <summary>
        ///     IKE service is shutting down.
        /// </summary>
        public const int ERROR_IPSEC_IKE_SHUTTING_DOWN = 0x00003643; // 13891

        /// <summary>
        ///     Could not verify binding between CGA address and certificate.
        /// </summary>
        public const int ERROR_IPSEC_IKE_CGA_AUTH_FAILED = 0x00003644; // 13892

        /// <summary>
        ///     Error processing NatOA payload.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PROCESS_ERR_NATOA = 0x00003645; // 13893

        /// <summary>
        ///     Parameters of the main mode are invalid for this quick mode.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INVALID_MM_FOR_QM = 0x00003646; // 13894

        /// <summary>
        ///     Quick mode SA was expired by IPsec driver.
        /// </summary>
        public const int ERROR_IPSEC_IKE_QM_EXPIRED = 0x00003647; // 13895

        /// <summary>
        ///     Too many dynamically added IKEEXT filters were detected.
        /// </summary>
        public const int ERROR_IPSEC_IKE_TOO_MANY_FILTERS = 0x00003648; // 13896

        /// <summary>
        ///     ERROR_IPSEC_IKE_NEG_STATUS_END
        /// </summary>
        public const int ERROR_IPSEC_IKE_NEG_STATUS_END = 0x00003649; // 13897

        /// <summary>
        ///     NAP reauth succeeded and must delete the dummy NAP IKEv2 tunnel.
        /// </summary>
        public const int ERROR_IPSEC_IKE_KILL_DUMMY_NAP_TUNNEL = 0x0000364A; // 13898

        /// <summary>
        ///     Error in assigning inner IP address to initiator in tunnel mode.
        /// </summary>
        public const int ERROR_IPSEC_IKE_INNER_IP_ASSIGNMENT_FAILURE = 0x0000364B; // 13899

        /// <summary>
        ///     Require configuration payload missing.
        /// </summary>
        public const int ERROR_IPSEC_IKE_REQUIRE_CP_PAYLOAD_MISSING = 0x0000364C; // 13900

        /// <summary>
        ///     A negotiation running as the security principle who issued the connection is in progress.
        /// </summary>
        public const int ERROR_IPSEC_KEY_MODULE_IMPERSONATION_NEGOTIATION_PENDING = 0x0000364D; // 13901

        /// <summary>
        ///     SA was deleted due to IKEv1/AuthIP co-existence suppress check.
        /// </summary>
        public const int ERROR_IPSEC_IKE_COEXISTENCE_SUPPRESS = 0x0000364E; // 13902

        /// <summary>
        ///     Incoming SA request was dropped due to peer IP address rate limiting.
        /// </summary>
        public const int ERROR_IPSEC_IKE_RATELIMIT_DROP = 0x0000364F; // 13903

        /// <summary>
        ///     Peer does not support MOBIKE.
        /// </summary>
        public const int ERROR_IPSEC_IKE_PEER_DOESNT_SUPPORT_MOBIKE = 0x00003650; // 13904

        /// <summary>
        ///     SA establishment is not authorized.
        /// </summary>
        public const int ERROR_IPSEC_IKE_AUTHORIZATION_FAILURE = 0x00003651; // 13905

        /// <summary>
        ///     SA establishment is not authorized because there is not a sufficiently strong PKINIT-based credential.
        /// </summary>
        public const int ERROR_IPSEC_IKE_STRONG_CRED_AUTHORIZATION_FAILURE = 0x00003652; // 13906

        /// <summary>
        ///     SA establishment is not authorized.  You may need to enter updated or different credentials such as a smartcard.
        /// </summary>
        public const int ERROR_IPSEC_IKE_AUTHORIZATION_FAILURE_WITH_OPTIONAL_RETRY = 0x00003653; // 13907

        /// <summary>
        ///     SA establishment is not authorized because there is not a sufficiently strong PKINIT-based credential. This might
        ///     be related to certificate-to-account mapping failure for the SA.
        /// </summary>
        public const int ERROR_IPSEC_IKE_STRONG_CRED_AUTHORIZATION_AND_CERTMAP_FAILURE = 0x00003654; // 13908

        /// <summary>
        ///     ERROR_IPSEC_IKE_NEG_STATUS_EXTENDED_END
        /// </summary>
        public const int ERROR_IPSEC_IKE_NEG_STATUS_EXTENDED_END = 0x00003655; // 13909

        /// <summary>
        ///     The SPI in the packet does not match a valid IPsec SA.
        /// </summary>
        public const int ERROR_IPSEC_BAD_SPI = 0x00003656; // 13910

        /// <summary>
        ///     Packet was received on an IPsec SA whose lifetime has expired.
        /// </summary>
        public const int ERROR_IPSEC_SA_LIFETIME_EXPIRED = 0x00003657; // 13911

        /// <summary>
        ///     Packet was received on an IPsec SA that does not match the packet characteristics.
        /// </summary>
        public const int ERROR_IPSEC_WRONG_SA = 0x00003658; // 13912

        /// <summary>
        ///     Packet sequence number replay check failed.
        /// </summary>
        public const int ERROR_IPSEC_REPLAY_CHECK_FAILED = 0x00003659; // 13913

        /// <summary>
        ///     IPsec header and/or trailer in the packet is invalid.
        /// </summary>
        public const int ERROR_IPSEC_INVALID_PACKET = 0x0000365A; // 13914

        /// <summary>
        ///     IPsec integrity check failed.
        /// </summary>
        public const int ERROR_IPSEC_INTEGRITY_CHECK_FAILED = 0x0000365B; // 13915

        /// <summary>
        ///     IPsec dropped a clear text packet.
        /// </summary>
        public const int ERROR_IPSEC_CLEAR_TEXT_DROP = 0x0000365C; // 13916

        /// <summary>
        ///     IPsec dropped an incoming ESP packet in authenticated firewall mode. This drop is benign.
        /// </summary>
        public const int ERROR_IPSEC_AUTH_FIREWALL_DROP = 0x0000365D; // 13917

        /// <summary>
        ///     IPsec dropped a packet due to DoS throttling.
        /// </summary>
        public const int ERROR_IPSEC_THROTTLE_DROP = 0x0000365E; // 13918

        /// <summary>
        ///     IPsec DoS Protection matched an explicit block rule.
        /// </summary>
        public const int ERROR_IPSEC_DOSP_BLOCK = 0x00003665; // 13925

        /// <summary>
        ///     IPsec DoS Protection received an IPsec specific multicast packet which is not allowed.
        /// </summary>
        public const int ERROR_IPSEC_DOSP_RECEIVED_MULTICAST = 0x00003666; // 13926

        /// <summary>
        ///     IPsec DoS Protection received an incorrectly formatted packet.
        /// </summary>
        public const int ERROR_IPSEC_DOSP_INVALID_PACKET = 0x00003667; // 13927

        /// <summary>
        ///     IPsec DoS Protection failed to look up state.
        /// </summary>
        public const int ERROR_IPSEC_DOSP_STATE_LOOKUP_FAILED = 0x00003668; // 13928

        /// <summary>
        ///     IPsec DoS Protection failed to create state because the maximum number of entries allowed by policy has been
        ///     reached.
        /// </summary>
        public const int ERROR_IPSEC_DOSP_MAX_ENTRIES = 0x00003669; // 13929

        /// <summary>
        ///     IPsec DoS Protection received an IPsec negotiation packet for a keying module which is not allowed by policy.
        /// </summary>
        public const int ERROR_IPSEC_DOSP_KEYMOD_NOT_ALLOWED = 0x0000366A; // 13930

        /// <summary>
        ///     IPsec DoS Protection has not been enabled.
        /// </summary>
        public const int ERROR_IPSEC_DOSP_NOT_INSTALLED = 0x0000366B; // 13931

        /// <summary>
        ///     IPsec DoS Protection failed to create a per internal IP rate limit queue because the maximum number of queues
        ///     allowed by policy has been reached.
        /// </summary>
        public const int ERROR_IPSEC_DOSP_MAX_PER_IP_RATELIMIT_QUEUES = 0x0000366C; // 13932

        /// <summary>
        ///     The requested section was not present in the activation context.
        /// </summary>
        public const int ERROR_SXS_SECTION_NOT_FOUND = 0x000036B0; // 14000

        /// <summary>
        ///     The application has failed to start because its side-by-side configuration is incorrect. Please see the application
        ///     event log or use the command-line sxstrace.exe tool for more detail.
        /// </summary>
        public const int ERROR_SXS_CANT_GEN_ACTCTX = 0x000036B1; // 14001

        /// <summary>
        ///     The application binding data format is invalid.
        /// </summary>
        public const int ERROR_SXS_INVALID_ACTCTXDATA_FORMAT = 0x000036B2; // 14002

        /// <summary>
        ///     The referenced assembly is not installed on your system.
        /// </summary>
        public const int ERROR_SXS_ASSEMBLY_NOT_FOUND = 0x000036B3; // 14003

        /// <summary>
        ///     The manifest file does not begin with the required tag and format information.
        /// </summary>
        public const int ERROR_SXS_MANIFEST_FORMAT_ERROR = 0x000036B4; // 14004

        /// <summary>
        ///     The manifest file contains one or more syntax errors.
        /// </summary>
        public const int ERROR_SXS_MANIFEST_PARSE_ERROR = 0x000036B5; // 14005

        /// <summary>
        ///     The application attempted to activate a disabled activation context.
        /// </summary>
        public const int ERROR_SXS_ACTIVATION_CONTEXT_DISABLED = 0x000036B6; // 14006

        /// <summary>
        ///     The requested lookup key was not found in any active activation context.
        /// </summary>
        public const int ERROR_SXS_KEY_NOT_FOUND = 0x000036B7; // 14007

        /// <summary>
        ///     A component version required by the application conflicts with another component version already active.
        /// </summary>
        public const int ERROR_SXS_VERSION_CONFLICT = 0x000036B8; // 14008

        /// <summary>
        ///     The type requested activation context section does not match the query API used.
        /// </summary>
        public const int ERROR_SXS_WRONG_SECTION_TYPE = 0x000036B9; // 14009

        /// <summary>
        ///     Lack of system resources has required isolated activation to be disabled for the current thread of execution.
        /// </summary>
        public const int ERROR_SXS_THREAD_QUERIES_DISABLED = 0x000036BA; // 14010

        /// <summary>
        ///     An attempt to set the process default activation context failed because the process default activation context was
        ///     already set.
        /// </summary>
        public const int ERROR_SXS_PROCESS_DEFAULT_ALREADY_SET = 0x000036BB; // 14011

        /// <summary>
        ///     The encoding group identifier specified is not recognized.
        /// </summary>
        public const int ERROR_SXS_UNKNOWN_ENCODING_GROUP = 0x000036BC; // 14012

        /// <summary>
        ///     The encoding requested is not recognized.
        /// </summary>
        public const int ERROR_SXS_UNKNOWN_ENCODING = 0x000036BD; // 14013

        /// <summary>
        ///     The manifest contains a reference to an invalid URI.
        /// </summary>
        public const int ERROR_SXS_INVALID_XML_NAMESPACE_URI = 0x000036BE; // 14014

        /// <summary>
        ///     The application manifest contains a reference to a dependent assembly which is not installed.
        /// </summary>
        public const int ERROR_SXS_ROOT_MANIFEST_DEPENDENCY_NOT_INSTALLED = 0x000036BF; // 14015

        /// <summary>
        ///     The manifest for an assembly used by the application has a reference to a dependent assembly which is not
        ///     installed.
        /// </summary>
        public const int ERROR_SXS_LEAF_MANIFEST_DEPENDENCY_NOT_INSTALLED = 0x000036C0; // 14016

        /// <summary>
        ///     The manifest contains an attribute for the assembly identity which is not valid.
        /// </summary>
        public const int ERROR_SXS_INVALID_ASSEMBLY_IDENTITY_ATTRIBUTE = 0x000036C1; // 14017

        /// <summary>
        ///     The manifest is missing the required default namespace specification on the assembly element.
        /// </summary>
        public const int ERROR_SXS_MANIFEST_MISSING_REQUIRED_DEFAULT_NAMESPACE = 0x000036C2; // 14018

        /// <summary>
        ///     The manifest has a default namespace specified on the assembly element but its value is not
        ///     "urn:schemas-microsoft-com:asm.v1".
        /// </summary>
        public const int ERROR_SXS_MANIFEST_INVALID_REQUIRED_DEFAULT_NAMESPACE = 0x000036C3; // 14019

        /// <summary>
        ///     The private manifest probed has crossed a path with an unsupported reparse point.
        /// </summary>
        public const int ERROR_SXS_PRIVATE_MANIFEST_CROSS_PATH_WITH_REPARSE_POINT = 0x000036C4; // 14020

        /// <summary>
        ///     Two or more components referenced directly or indirectly by the application manifest have files by the same name.
        /// </summary>
        public const int ERROR_SXS_DUPLICATE_DLL_NAME = 0x000036C5; // 14021

        /// <summary>
        ///     Two or more components referenced directly or indirectly by the application manifest have window classes with the
        ///     same name.
        /// </summary>
        public const int ERROR_SXS_DUPLICATE_WINDOWCLASS_NAME = 0x000036C6; // 14022

        /// <summary>
        ///     Two or more components referenced directly or indirectly by the application manifest have the same COM server
        ///     CLSIDs.
        /// </summary>
        public const int ERROR_SXS_DUPLICATE_CLSID = 0x000036C7; // 14023

        /// <summary>
        ///     Two or more components referenced directly or indirectly by the application manifest have proxies for the same COM
        ///     interface IIDs.
        /// </summary>
        public const int ERROR_SXS_DUPLICATE_IID = 0x000036C8; // 14024

        /// <summary>
        ///     Two or more components referenced directly or indirectly by the application manifest have the same COM type library
        ///     TLBIDs.
        /// </summary>
        public const int ERROR_SXS_DUPLICATE_TLBID = 0x000036C9; // 14025

        /// <summary>
        ///     Two or more components referenced directly or indirectly by the application manifest have the same COM ProgIDs.
        /// </summary>
        public const int ERROR_SXS_DUPLICATE_PROGID = 0x000036CA; // 14026

        /// <summary>
        ///     Two or more components referenced directly or indirectly by the application manifest are different versions of the
        ///     same component which is not permitted.
        /// </summary>
        public const int ERROR_SXS_DUPLICATE_ASSEMBLY_NAME = 0x000036CB; // 14027

        /// <summary>
        ///     A component's file does not match the verification information present in the component manifest.
        /// </summary>
        public const int ERROR_SXS_FILE_HASH_MISMATCH = 0x000036CC; // 14028

        /// <summary>
        ///     The policy manifest contains one or more syntax errors.
        /// </summary>
        public const int ERROR_SXS_POLICY_PARSE_ERROR = 0x000036CD; // 14029

        /// <summary>
        ///     Manifest Parse Error : A string literal was expected, but no opening quote character was found.
        /// </summary>
        public const int ERROR_SXS_XML_E_MISSINGQUOTE = 0x000036CE; // 14030

        /// <summary>
        ///     Manifest Parse Error : Incorrect syntax was used in a comment.
        /// </summary>
        public const int ERROR_SXS_XML_E_COMMENTSYNTAX = 0x000036CF; // 14031

        /// <summary>
        ///     Manifest Parse Error : A name was started with an invalid character.
        /// </summary>
        public const int ERROR_SXS_XML_E_BADSTARTNAMECHAR = 0x000036D0; // 14032

        /// <summary>
        ///     Manifest Parse Error : A name contained an invalid character.
        /// </summary>
        public const int ERROR_SXS_XML_E_BADNAMECHAR = 0x000036D1; // 14033

        /// <summary>
        ///     Manifest Parse Error : A string literal contained an invalid character.
        /// </summary>
        public const int ERROR_SXS_XML_E_BADCHARINSTRING = 0x000036D2; // 14034

        /// <summary>
        ///     Manifest Parse Error : Invalid syntax for an xml declaration.
        /// </summary>
        public const int ERROR_SXS_XML_E_XMLDECLSYNTAX = 0x000036D3; // 14035

        /// <summary>
        ///     Manifest Parse Error : An Invalid character was found in text content.
        /// </summary>
        public const int ERROR_SXS_XML_E_BADCHARDATA = 0x000036D4; // 14036

        /// <summary>
        ///     Manifest Parse Error : Required white space was missing.
        /// </summary>
        public const int ERROR_SXS_XML_E_MISSINGWHITESPACE = 0x000036D5; // 14037

        /// <summary>
        ///     Manifest Parse Error : The character '>' was expected.
        /// </summary>
        public const int ERROR_SXS_XML_E_EXPECTINGTAGEND = 0x000036D6; // 14038

        /// <summary>
        ///     Manifest Parse Error : A semi colon character was expected.
        /// </summary>
        public const int ERROR_SXS_XML_E_MISSINGSEMICOLON = 0x000036D7; // 14039

        /// <summary>
        ///     Manifest Parse Error : Unbalanced parentheses.
        /// </summary>
        public const int ERROR_SXS_XML_E_UNBALANCEDPAREN = 0x000036D8; // 14040

        /// <summary>
        ///     Manifest Parse Error : Internal error.
        /// </summary>
        public const int ERROR_SXS_XML_E_INTERNALERROR = 0x000036D9; // 14041

        /// <summary>
        ///     Manifest Parse Error : Whitespace is not allowed at this location.
        /// </summary>
        public const int ERROR_SXS_XML_E_UNEXPECTED_WHITESPACE = 0x000036DA; // 14042

        /// <summary>
        ///     Manifest Parse Error : End of file reached in invalid state for current encoding.
        /// </summary>
        public const int ERROR_SXS_XML_E_INCOMPLETE_ENCODING = 0x000036DB; // 14043

        /// <summary>
        ///     Manifest Parse Error : Missing parenthesis.
        /// </summary>
        public const int ERROR_SXS_XML_E_MISSING_PAREN = 0x000036DC; // 14044

        /// <summary>
        ///     Manifest Parse Error : A single or double closing quote character (\' or \") is missing.
        /// </summary>
        public const int ERROR_SXS_XML_E_EXPECTINGCLOSEQUOTE = 0x000036DD; // 14045

        /// <summary>
        ///     Manifest Parse Error : Multiple colons are not allowed in a name.
        /// </summary>
        public const int ERROR_SXS_XML_E_MULTIPLE_COLONS = 0x000036DE; // 14046

        /// <summary>
        ///     Manifest Parse Error : Invalid character for decimal digit.
        /// </summary>
        public const int ERROR_SXS_XML_E_INVALID_DECIMAL = 0x000036DF; // 14047

        /// <summary>
        ///     Manifest Parse Error : Invalid character for hexadecimal digit.
        /// </summary>
        public const int ERROR_SXS_XML_E_INVALID_HEXIDECIMAL = 0x000036E0; // 14048

        /// <summary>
        ///     Manifest Parse Error : Invalid unicode character value for this platform.
        /// </summary>
        public const int ERROR_SXS_XML_E_INVALID_UNICODE = 0x000036E1; // 14049

        /// <summary>
        ///     Manifest Parse Error : Expecting whitespace or '?'.
        /// </summary>
        public const int ERROR_SXS_XML_E_WHITESPACEORQUESTIONMARK = 0x000036E2; // 14050

        /// <summary>
        ///     Manifest Parse Error : End tag was not expected at this location.
        /// </summary>
        public const int ERROR_SXS_XML_E_UNEXPECTEDENDTAG = 0x000036E3; // 14051

        /// <summary>
        ///     Manifest Parse Error : The following tags were not closed: %1.
        /// </summary>
        public const int ERROR_SXS_XML_E_UNCLOSEDTAG = 0x000036E4; // 14052

        /// <summary>
        ///     Manifest Parse Error : Duplicate attribute.
        /// </summary>
        public const int ERROR_SXS_XML_E_DUPLICATEATTRIBUTE = 0x000036E5; // 14053

        /// <summary>
        ///     Manifest Parse Error : Only one top level element is allowed in an XML document.
        /// </summary>
        public const int ERROR_SXS_XML_E_MULTIPLEROOTS = 0x000036E6; // 14054

        /// <summary>
        ///     Manifest Parse Error : Invalid at the top level of the document.
        /// </summary>
        public const int ERROR_SXS_XML_E_INVALIDATROOTLEVEL = 0x000036E7; // 14055

        /// <summary>
        ///     Manifest Parse Error : Invalid xml declaration.
        /// </summary>
        public const int ERROR_SXS_XML_E_BADXMLDECL = 0x000036E8; // 14056

        /// <summary>
        ///     Manifest Parse Error : XML document must have a top level element.
        /// </summary>
        public const int ERROR_SXS_XML_E_MISSINGROOT = 0x000036E9; // 14057

        /// <summary>
        ///     Manifest Parse Error : Unexpected end of file.
        /// </summary>
        public const int ERROR_SXS_XML_E_UNEXPECTEDEOF = 0x000036EA; // 14058

        /// <summary>
        ///     Manifest Parse Error : Parameter entities cannot be used inside markup declarations in an internal subset.
        /// </summary>
        public const int ERROR_SXS_XML_E_BADPEREFINSUBSET = 0x000036EB; // 14059

        /// <summary>
        ///     Manifest Parse Error : Element was not closed.
        /// </summary>
        public const int ERROR_SXS_XML_E_UNCLOSEDSTARTTAG = 0x000036EC; // 14060

        /// <summary>
        ///     Manifest Parse Error : End element was missing the character '>'.
        /// </summary>
        public const int ERROR_SXS_XML_E_UNCLOSEDENDTAG = 0x000036ED; // 14061

        /// <summary>
        ///     Manifest Parse Error : A string literal was not closed.
        /// </summary>
        public const int ERROR_SXS_XML_E_UNCLOSEDSTRING = 0x000036EE; // 14062

        /// <summary>
        ///     Manifest Parse Error : A comment was not closed.
        /// </summary>
        public const int ERROR_SXS_XML_E_UNCLOSEDCOMMENT = 0x000036EF; // 14063

        /// <summary>
        ///     Manifest Parse Error : A declaration was not closed.
        /// </summary>
        public const int ERROR_SXS_XML_E_UNCLOSEDDECL = 0x000036F0; // 14064

        /// <summary>
        ///     Manifest Parse Error : A CDATA section was not closed.
        /// </summary>
        public const int ERROR_SXS_XML_E_UNCLOSEDCDATA = 0x000036F1; // 14065

        /// <summary>
        ///     Manifest Parse Error : The namespace prefix is not allowed to start with the reserved string "xml".
        /// </summary>
        public const int ERROR_SXS_XML_E_RESERVEDNAMESPACE = 0x000036F2; // 14066

        /// <summary>
        ///     Manifest Parse Error : System does not support the specified encoding.
        /// </summary>
        public const int ERROR_SXS_XML_E_INVALIDENCODING = 0x000036F3; // 14067

        /// <summary>
        ///     Manifest Parse Error : Switch from current encoding to specified encoding not supported.
        /// </summary>
        public const int ERROR_SXS_XML_E_INVALIDSWITCH = 0x000036F4; // 14068

        /// <summary>
        ///     Manifest Parse Error : The name 'xml' is reserved and must be lower case.
        /// </summary>
        public const int ERROR_SXS_XML_E_BADXMLCASE = 0x000036F5; // 14069

        /// <summary>
        ///     Manifest Parse Error : The standalone attribute must have the value 'yes' or 'no'.
        /// </summary>
        public const int ERROR_SXS_XML_E_INVALID_STANDALONE = 0x000036F6; // 14070

        /// <summary>
        ///     Manifest Parse Error : The standalone attribute cannot be used in external entities.
        /// </summary>
        public const int ERROR_SXS_XML_E_UNEXPECTED_STANDALONE = 0x000036F7; // 14071

        /// <summary>
        ///     Manifest Parse Error : Invalid version number.
        /// </summary>
        public const int ERROR_SXS_XML_E_INVALID_VERSION = 0x000036F8; // 14072

        /// <summary>
        ///     Manifest Parse Error : Missing equals sign between attribute and attribute value.
        /// </summary>
        public const int ERROR_SXS_XML_E_MISSINGEQUALS = 0x000036F9; // 14073

        /// <summary>
        ///     Assembly Protection Error : Unable to recover the specified assembly.
        /// </summary>
        public const int ERROR_SXS_PROTECTION_RECOVERY_FAILED = 0x000036FA; // 14074

        /// <summary>
        ///     Assembly Protection Error : The public key for an assembly was too short to be allowed.
        /// </summary>
        public const int ERROR_SXS_PROTECTION_PUBLIC_KEY_TOO_SHORT = 0x000036FB; // 14075

        /// <summary>
        ///     Assembly Protection Error : The catalog for an assembly is not valid, or does not match the assembly's manifest.
        /// </summary>
        public const int ERROR_SXS_PROTECTION_CATALOG_NOT_VALID = 0x000036FC; // 14076

        /// <summary>
        ///     An HRESULT could not be translated to a corresponding Win32 error code.
        /// </summary>
        public const int ERROR_SXS_UNTRANSLATABLE_HRESULT = 0x000036FD; // 14077

        /// <summary>
        ///     Assembly Protection Error : The catalog for an assembly is missing.
        /// </summary>
        public const int ERROR_SXS_PROTECTION_CATALOG_FILE_MISSING = 0x000036FE; // 14078

        /// <summary>
        ///     The supplied assembly identity is missing one or more attributes which must be present in this context.
        /// </summary>
        public const int ERROR_SXS_MISSING_ASSEMBLY_IDENTITY_ATTRIBUTE = 0x000036FF; // 14079

        /// <summary>
        ///     The supplied assembly identity has one or more attribute names that contain characters not permitted in XML names.
        /// </summary>
        public const int ERROR_SXS_INVALID_ASSEMBLY_IDENTITY_ATTRIBUTE_NAME = 0x00003700; // 14080

        /// <summary>
        ///     The referenced assembly could not be found.
        /// </summary>
        public const int ERROR_SXS_ASSEMBLY_MISSING = 0x00003701; // 14081

        /// <summary>
        ///     The activation context activation stack for the running thread of execution is corrupt.
        /// </summary>
        public const int ERROR_SXS_CORRUPT_ACTIVATION_STACK = 0x00003702; // 14082

        /// <summary>
        ///     The application isolation metadata for this process or thread has become corrupt.
        /// </summary>
        public const int ERROR_SXS_CORRUPTION = 0x00003703; // 14083

        /// <summary>
        ///     The activation context being deactivated is not the most recently activated one.
        /// </summary>
        public const int ERROR_SXS_EARLY_DEACTIVATION = 0x00003704; // 14084

        /// <summary>
        ///     The activation context being deactivated is not active for the current thread of execution.
        /// </summary>
        public const int ERROR_SXS_INVALID_DEACTIVATION = 0x00003705; // 14085

        /// <summary>
        ///     The activation context being deactivated has already been deactivated.
        /// </summary>
        public const int ERROR_SXS_MULTIPLE_DEACTIVATION = 0x00003706; // 14086

        /// <summary>
        ///     A component used by the isolation facility has requested to terminate the process.
        /// </summary>
        public const int ERROR_SXS_PROCESS_TERMINATION_REQUESTED = 0x00003707; // 14087

        /// <summary>
        ///     A kernel mode component is releasing a reference on an activation context.
        /// </summary>
        public const int ERROR_SXS_RELEASE_ACTIVATION_CONTEXT = 0x00003708; // 14088

        /// <summary>
        ///     The activation context of system default assembly could not be generated.
        /// </summary>
        public const int ERROR_SXS_SYSTEM_DEFAULT_ACTIVATION_CONTEXT_EMPTY = 0x00003709; // 14089

        /// <summary>
        ///     The value of an attribute in an identity is not within the legal range.
        /// </summary>
        public const int ERROR_SXS_INVALID_IDENTITY_ATTRIBUTE_VALUE = 0x0000370A; // 14090

        /// <summary>
        ///     The name of an attribute in an identity is not within the legal range.
        /// </summary>
        public const int ERROR_SXS_INVALID_IDENTITY_ATTRIBUTE_NAME = 0x0000370B; // 14091

        /// <summary>
        ///     An identity contains two definitions for the same attribute.
        /// </summary>
        public const int ERROR_SXS_IDENTITY_DUPLICATE_ATTRIBUTE = 0x0000370C; // 14092

        /// <summary>
        ///     The identity string is malformed. This may be due to a trailing comma, more than two unnamed attributes, missing
        ///     attribute name or missing attribute value.
        /// </summary>
        public const int ERROR_SXS_IDENTITY_PARSE_ERROR = 0x0000370D; // 14093

        /// <summary>
        ///     A string containing localized substitutable content was malformed. Either a dollar sign ($) was followed by
        ///     something other than a left parenthesis or another dollar sign or an substitution's right parenthesis was not
        ///     found.
        /// </summary>
        public const int ERROR_MALFORMED_SUBSTITUTION_STRING = 0x0000370E; // 14094

        /// <summary>
        ///     The public key token does not correspond to the public key specified.
        /// </summary>
        public const int ERROR_SXS_INCORRECT_PUBLIC_KEY_TOKEN = 0x0000370F; // 14095

        /// <summary>
        ///     A substitution string had no mapping.
        /// </summary>
        public const int ERROR_UNMAPPED_SUBSTITUTION_STRING = 0x00003710; // 14096

        /// <summary>
        ///     The component must be locked before making the request.
        /// </summary>
        public const int ERROR_SXS_ASSEMBLY_NOT_LOCKED = 0x00003711; // 14097

        /// <summary>
        ///     The component store has been corrupted.
        /// </summary>
        public const int ERROR_SXS_COMPONENT_STORE_CORRUPT = 0x00003712; // 14098

        /// <summary>
        ///     An advanced installer failed during setup or servicing.
        /// </summary>
        public const int ERROR_ADVANCED_INSTALLER_FAILED = 0x00003713; // 14099

        /// <summary>
        ///     The character encoding in the XML declaration did not match the encoding used in the document.
        /// </summary>
        public const int ERROR_XML_ENCODING_MISMATCH = 0x00003714; // 14100

        /// <summary>
        ///     The identities of the manifests are identical but their contents are different.
        /// </summary>
        public const int ERROR_SXS_MANIFEST_IDENTITY_SAME_BUT_CONTENTS_DIFFERENT = 0x00003715; // 14101

        /// <summary>
        ///     The component identities are different.
        /// </summary>
        public const int ERROR_SXS_IDENTITIES_DIFFERENT = 0x00003716; // 14102

        /// <summary>
        ///     The assembly is not a deployment.
        /// </summary>
        public const int ERROR_SXS_ASSEMBLY_IS_NOT_A_DEPLOYMENT = 0x00003717; // 14103

        /// <summary>
        ///     The file is not a part of the assembly.
        /// </summary>
        public const int ERROR_SXS_FILE_NOT_PART_OF_ASSEMBLY = 0x00003718; // 14104

        /// <summary>
        ///     The size of the manifest exceeds the maximum allowed.
        /// </summary>
        public const int ERROR_SXS_MANIFEST_TOO_BIG = 0x00003719; // 14105

        /// <summary>
        ///     The setting is not registered.
        /// </summary>
        public const int ERROR_SXS_SETTING_NOT_REGISTERED = 0x0000371A; // 14106

        /// <summary>
        ///     One or more required members of the transaction are not present.
        /// </summary>
        public const int ERROR_SXS_TRANSACTION_CLOSURE_INCOMPLETE = 0x0000371B; // 14107

        /// <summary>
        ///     The SMI primitive installer failed during setup or servicing.
        /// </summary>
        public const int ERROR_SMI_PRIMITIVE_INSTALLER_FAILED = 0x0000371C; // 14108

        /// <summary>
        ///     A generic command executable returned a result that indicates failure.
        /// </summary>
        public const int ERROR_GENERIC_COMMAND_FAILED = 0x0000371D; // 14109

        /// <summary>
        ///     A component is missing file verification information in its manifest.
        /// </summary>
        public const int ERROR_SXS_FILE_HASH_MISSING = 0x0000371E; // 14110

        /// <summary>
        ///     The specified channel path is invalid.
        /// </summary>
        public const int ERROR_EVT_INVALID_CHANNEL_PATH = 0x00003A98; // 15000

        /// <summary>
        ///     The specified query is invalid.
        /// </summary>
        public const int ERROR_EVT_INVALID_QUERY = 0x00003A99; // 15001

        /// <summary>
        ///     The publisher metadata cannot be found in the resource.
        /// </summary>
        public const int ERROR_EVT_PUBLISHER_METADATA_NOT_FOUND = 0x00003A9A; // 15002

        /// <summary>
        ///     The template for an event definition cannot be found in the resource (error = %1).
        /// </summary>
        public const int ERROR_EVT_EVENT_TEMPLATE_NOT_FOUND = 0x00003A9B; // 15003

        /// <summary>
        ///     The specified publisher name is invalid.
        /// </summary>
        public const int ERROR_EVT_INVALID_PUBLISHER_NAME = 0x00003A9C; // 15004

        /// <summary>
        ///     The event data raised by the publisher is not compatible with the event template definition in the publisher's
        ///     manifest.
        /// </summary>
        public const int ERROR_EVT_INVALID_EVENT_DATA = 0x00003A9D; // 15005

        /// <summary>
        ///     The specified channel could not be found. Check channel configuration.
        /// </summary>
        public const int ERROR_EVT_CHANNEL_NOT_FOUND = 0x00003A9F; // 15007

        /// <summary>
        ///     The specified xml text was not well-formed. See Extended Error for more details.
        /// </summary>
        public const int ERROR_EVT_MALFORMED_XML_TEXT = 0x00003AA0; // 15008

        /// <summary>
        ///     The caller is trying to subscribe to a direct channel which is not allowed. The events for a direct channel go
        ///     directly to a logfile and cannot be subscribed to.
        /// </summary>
        public const int ERROR_EVT_SUBSCRIPTION_TO_DIRECT_CHANNEL = 0x00003AA1; // 15009

        /// <summary>
        ///     Configuration error.
        /// </summary>
        public const int ERROR_EVT_CONFIGURATION_ERROR = 0x00003AA2; // 15010

        /// <summary>
        ///     The query result is stale / invalid. This may be due to the log being cleared or rolling over after the query
        ///     result was created. Users should handle this code by releasing the query result object and reissuing the query.
        /// </summary>
        public const int ERROR_EVT_QUERY_RESULT_STALE = 0x00003AA3; // 15011

        /// <summary>
        ///     Query result is currently at an invalid position.
        /// </summary>
        public const int ERROR_EVT_QUERY_RESULT_INVALID_POSITION = 0x00003AA4; // 15012

        /// <summary>
        ///     Registered MSXML doesn't support validation.
        /// </summary>
        public const int ERROR_EVT_NON_VALIDATING_MSXML = 0x00003AA5; // 15013

        /// <summary>
        ///     An expression can only be followed by a change of scope operation if it itself evaluates to a node set and is not
        ///     already part of some other change of scope operation.
        /// </summary>
        public const int ERROR_EVT_FILTER_ALREADYSCOPED = 0x00003AA6; // 15014

        /// <summary>
        ///     Can't perform a step operation from a term that does not represent an element set.
        /// </summary>
        public const int ERROR_EVT_FILTER_NOTELTSET = 0x00003AA7; // 15015

        /// <summary>
        ///     Left hand side arguments to binary operators must be either attributes, nodes or variables and right hand side
        ///     arguments must be constants.
        /// </summary>
        public const int ERROR_EVT_FILTER_INVARG = 0x00003AA8; // 15016

        /// <summary>
        ///     A step operation must involve either a node test or, in the case of a predicate, an algebraic expression against
        ///     which to test each node in the node set identified by the preceeding node set can be evaluated.
        /// </summary>
        public const int ERROR_EVT_FILTER_INVTEST = 0x00003AA9; // 15017

        /// <summary>
        ///     This data type is currently unsupported.
        /// </summary>
        public const int ERROR_EVT_FILTER_INVTYPE = 0x00003AAA; // 15018

        /// <summary>
        ///     A syntax error occurred at position %1!d!.
        /// </summary>
        public const int ERROR_EVT_FILTER_PARSEERR = 0x00003AAB; // 15019

        /// <summary>
        ///     This operator is unsupported by this implementation of the filter.
        /// </summary>
        public const int ERROR_EVT_FILTER_UNSUPPORTEDOP = 0x00003AAC; // 15020

        /// <summary>
        ///     The token encountered was unexpected.
        /// </summary>
        public const int ERROR_EVT_FILTER_UNEXPECTEDTOKEN = 0x00003AAD; // 15021

        /// <summary>
        ///     The requested operation cannot be performed over an enabled direct channel. The channel must first be disabled
        ///     before performing the requested operation.
        /// </summary>
        public const int ERROR_EVT_INVALID_OPERATION_OVER_ENABLED_DIRECT_CHANNEL = 0x00003AAE; // 15022

        /// <summary>
        ///     Channel property %1!s! contains invalid value. The value has invalid type, is outside of valid range, can't be
        ///     updated or is not supported by this type of channel.
        /// </summary>
        public const int ERROR_EVT_INVALID_CHANNEL_PROPERTY_VALUE = 0x00003AAF; // 15023

        /// <summary>
        ///     Publisher property %1!s! contains invalid value. The value has invalid type, is outside of valid range, can't be
        ///     updated or is not supported by this type of publisher.
        /// </summary>
        public const int ERROR_EVT_INVALID_PUBLISHER_PROPERTY_VALUE = 0x00003AB0; // 15024

        /// <summary>
        ///     The channel fails to activate.
        /// </summary>
        public const int ERROR_EVT_CHANNEL_CANNOT_ACTIVATE = 0x00003AB1; // 15025

        /// <summary>
        ///     The xpath expression exceeded supported complexity. Please symplify it or split it into two or more simple
        ///     expressions.
        /// </summary>
        public const int ERROR_EVT_FILTER_TOO_COMPLEX = 0x00003AB2; // 15026

        /// <summary>
        ///     the message resource is present but the message is not found in the string/message table.
        /// </summary>
        public const int ERROR_EVT_MESSAGE_NOT_FOUND = 0x00003AB3; // 15027

        /// <summary>
        ///     The message id for the desired message could not be found.
        /// </summary>
        public const int ERROR_EVT_MESSAGE_ID_NOT_FOUND = 0x00003AB4; // 15028

        /// <summary>
        ///     The substitution string for insert index (%1) could not be found.
        /// </summary>
        public const int ERROR_EVT_UNRESOLVED_VALUE_INSERT = 0x00003AB5; // 15029

        /// <summary>
        ///     The description string for parameter reference (%1) could not be found.
        /// </summary>
        public const int ERROR_EVT_UNRESOLVED_PARAMETER_INSERT = 0x00003AB6; // 15030

        /// <summary>
        ///     The maximum number of replacements has been reached.
        /// </summary>
        public const int ERROR_EVT_MAX_INSERTS_REACHED = 0x00003AB7; // 15031

        /// <summary>
        ///     The event definition could not be found for event id (%1).
        /// </summary>
        public const int ERROR_EVT_EVENT_DEFINITION_NOT_FOUND = 0x00003AB8; // 15032

        /// <summary>
        ///     The locale specific resource for the desired message is not present.
        /// </summary>
        public const int ERROR_EVT_MESSAGE_LOCALE_NOT_FOUND = 0x00003AB9; // 15033

        /// <summary>
        ///     The resource is too old to be compatible.
        /// </summary>
        public const int ERROR_EVT_VERSION_TOO_OLD = 0x00003ABA; // 15034

        /// <summary>
        ///     The resource is too new to be compatible.
        /// </summary>
        public const int ERROR_EVT_VERSION_TOO_NEW = 0x00003ABB; // 15035

        /// <summary>
        ///     The channel at index %1!d! of the query can't be opened.
        /// </summary>
        public const int ERROR_EVT_CANNOT_OPEN_CHANNEL_OF_QUERY = 0x00003ABC; // 15036

        /// <summary>
        ///     The publisher has been disabled and its resource is not avaiable. This usually occurs when the publisher is in the
        ///     process of being uninstalled or upgraded.
        /// </summary>
        public const int ERROR_EVT_PUBLISHER_DISABLED = 0x00003ABD; // 15037

        /// <summary>
        ///     Attempted to create a numeric type that is outside of its valid range.
        /// </summary>
        public const int ERROR_EVT_FILTER_OUT_OF_RANGE = 0x00003ABE; // 15038

        /// <summary>
        ///     The subscription fails to activate.
        /// </summary>
        public const int ERROR_EC_SUBSCRIPTION_CANNOT_ACTIVATE = 0x00003AE8; // 15080

        /// <summary>
        ///     The log of the subscription is in disabled state, and can not be used to forward events to. The log must first be
        ///     enabled before the subscription can be activated.
        /// </summary>
        public const int ERROR_EC_LOG_DISABLED = 0x00003AE9; // 15081

        /// <summary>
        ///     When forwarding events from local machine to itself, the query of the subscription can't contain target log of the
        ///     subscription.
        /// </summary>
        public const int ERROR_EC_CIRCULAR_FORWARDING = 0x00003AEA; // 15082

        /// <summary>
        ///     The credential store that is used to save credentials is full.
        /// </summary>
        public const int ERROR_EC_CREDSTORE_FULL = 0x00003AEB; // 15083

        /// <summary>
        ///     The credential used by this subscription can't be found in credential store.
        /// </summary>
        public const int ERROR_EC_CRED_NOT_FOUND = 0x00003AEC; // 15084

        /// <summary>
        ///     No active channel is found for the query.
        /// </summary>
        public const int ERROR_EC_NO_ACTIVE_CHANNEL = 0x00003AED; // 15085

        /// <summary>
        ///     The resource loader failed to find MUI file.
        /// </summary>
        public const int ERROR_MUI_FILE_NOT_FOUND = 0x00003AFC; // 15100

        /// <summary>
        ///     The resource loader failed to load MUI file because the file fail to pass validation.
        /// </summary>
        public const int ERROR_MUI_INVALID_FILE = 0x00003AFD; // 15101

        /// <summary>
        ///     The RC Manifest is corrupted with garbage data or unsupported version or missing required item.
        /// </summary>
        public const int ERROR_MUI_INVALID_RC_CONFIG = 0x00003AFE; // 15102

        /// <summary>
        ///     The RC Manifest has invalid culture name.
        /// </summary>
        public const int ERROR_MUI_INVALID_LOCALE_NAME = 0x00003AFF; // 15103

        /// <summary>
        ///     The RC Manifest has invalid ultimatefallback name.
        /// </summary>
        public const int ERROR_MUI_INVALID_ULTIMATEFALLBACK_NAME = 0x00003B00; // 15104

        /// <summary>
        ///     The resource loader cache doesn't have loaded MUI entry.
        /// </summary>
        public const int ERROR_MUI_FILE_NOT_LOADED = 0x00003B01; // 15105

        /// <summary>
        ///     User stopped resource enumeration.
        /// </summary>
        public const int ERROR_RESOURCE_ENUM_USER_STOP = 0x00003B02; // 15106

        /// <summary>
        ///     UI language installation failed.
        /// </summary>
        public const int ERROR_MUI_INTLSETTINGS_UILANG_NOT_INSTALLED = 0x00003B03; // 15107

        /// <summary>
        ///     Locale installation failed.
        /// </summary>
        public const int ERROR_MUI_INTLSETTINGS_INVALID_LOCALE_NAME = 0x00003B04; // 15108

        /// <summary>
        ///     A resource does not have default or neutral value.
        /// </summary>
        public const int ERROR_MRM_RUNTIME_NO_DEFAULT_OR_NEUTRAL_RESOURCE = 0x00003B06; // 15110

        /// <summary>
        ///     Invalid PRI config file.
        /// </summary>
        public const int ERROR_MRM_INVALID_PRICONFIG = 0x00003B07; // 15111

        /// <summary>
        ///     Invalid file type.
        /// </summary>
        public const int ERROR_MRM_INVALID_FILE_TYPE = 0x00003B08; // 15112

        /// <summary>
        ///     Unknown qualifier.
        /// </summary>
        public const int ERROR_MRM_UNKNOWN_QUALIFIER = 0x00003B09; // 15113

        /// <summary>
        ///     Invalid qualifier value.
        /// </summary>
        public const int ERROR_MRM_INVALID_QUALIFIER_VALUE = 0x00003B0A; // 15114

        /// <summary>
        ///     No Candidate found.
        /// </summary>
        public const int ERROR_MRM_NO_CANDIDATE = 0x00003B0B; // 15115

        /// <summary>
        ///     The ResourceMap or NamedResource has an item that does not have default or neutral resource..
        /// </summary>
        public const int ERROR_MRM_NO_MATCH_OR_DEFAULT_CANDIDATE = 0x00003B0C; // 15116

        /// <summary>
        ///     Invalid ResourceCandidate type.
        /// </summary>
        public const int ERROR_MRM_RESOURCE_TYPE_MISMATCH = 0x00003B0D; // 15117

        /// <summary>
        ///     Duplicate Resource Map.
        /// </summary>
        public const int ERROR_MRM_DUPLICATE_MAP_NAME = 0x00003B0E; // 15118

        /// <summary>
        ///     Duplicate Entry.
        /// </summary>
        public const int ERROR_MRM_DUPLICATE_ENTRY = 0x00003B0F; // 15119

        /// <summary>
        ///     Invalid Resource Identifier.
        /// </summary>
        public const int ERROR_MRM_INVALID_RESOURCE_IDENTIFIER = 0x00003B10; // 15120

        /// <summary>
        ///     Filepath too long.
        /// </summary>
        public const int ERROR_MRM_FILEPATH_TOO_LONG = 0x00003B11; // 15121

        /// <summary>
        ///     Unsupported directory type.
        /// </summary>
        public const int ERROR_MRM_UNSUPPORTED_DIRECTORY_TYPE = 0x00003B12; // 15122

        /// <summary>
        ///     Invalid PRI File.
        /// </summary>
        public const int ERROR_MRM_INVALID_PRI_FILE = 0x00003B16; // 15126

        /// <summary>
        ///     NamedResource Not Found.
        /// </summary>
        public const int ERROR_MRM_NAMED_RESOURCE_NOT_FOUND = 0x00003B17; // 15127

        /// <summary>
        ///     ResourceMap Not Found.
        /// </summary>
        public const int ERROR_MRM_MAP_NOT_FOUND = 0x00003B1F; // 15135

        /// <summary>
        ///     Unsupported MRT profile type.
        /// </summary>
        public const int ERROR_MRM_UNSUPPORTED_PROFILE_TYPE = 0x00003B20; // 15136

        /// <summary>
        ///     Invalid qualifier operator.
        /// </summary>
        public const int ERROR_MRM_INVALID_QUALIFIER_OPERATOR = 0x00003B21; // 15137

        /// <summary>
        ///     Unable to determine qualifier value or qualifier value has not been set.
        /// </summary>
        public const int ERROR_MRM_INDETERMINATE_QUALIFIER_VALUE = 0x00003B22; // 15138

        /// <summary>
        ///     Automerge is enabled in the PRI file.
        /// </summary>
        public const int ERROR_MRM_AUTOMERGE_ENABLED = 0x00003B23; // 15139

        /// <summary>
        ///     Too many resources defined for package.
        /// </summary>
        public const int ERROR_MRM_TOO_MANY_RESOURCES = 0x00003B24; // 15140

        /// <summary>
        ///     The monitor returned a DDC/CI capabilities string that did not comply with the ACCESS.bus 3.0, DDC/CI 1.1 or MCCS 2
        ///     Revision 1 specification.
        /// </summary>
        public const int ERROR_MCA_INVALID_CAPABILITIES_STRING = 0x00003B60; // 15200

        /// <summary>
        ///     The monitor's VCP Version (0xDF) VCP code returned an invalid version value.
        /// </summary>
        public const int ERROR_MCA_INVALID_VCP_VERSION = 0x00003B61; // 15201

        /// <summary>
        ///     The monitor does not comply with the MCCS specification it claims to support.
        /// </summary>
        public const int ERROR_MCA_MONITOR_VIOLATES_MCCS_SPECIFICATION = 0x00003B62; // 15202

        /// <summary>
        ///     The MCCS version in a monitor's mccs_ver capability does not match the MCCS version the monitor reports when the
        ///     VCP Version (0xDF) VCP code is used.
        /// </summary>
        public const int ERROR_MCA_MCCS_VERSION_MISMATCH = 0x00003B63; // 15203

        /// <summary>
        ///     The Monitor Configuration API only works with monitors that support the MCCS 1.0 specification, MCCS 2.0
        ///     specification or the MCCS 2.0 Revision 1 specification.
        /// </summary>
        public const int ERROR_MCA_UNSUPPORTED_MCCS_VERSION = 0x00003B64; // 15204

        /// <summary>
        ///     An internal Monitor Configuration API error occurred.
        /// </summary>
        public const int ERROR_MCA_INTERNAL_ERROR = 0x00003B65; // 15205

        /// <summary>
        ///     The monitor returned an invalid monitor technology type. CRT, Plasma and LCD (TFT) are examples of monitor
        ///     technology types. This error implies that the monitor violated the MCCS 2.0 or MCCS 2.0 Revision 1 specification.
        /// </summary>
        public const int ERROR_MCA_INVALID_TECHNOLOGY_TYPE_RETURNED = 0x00003B66; // 15206

        /// <summary>
        ///     The caller of SetMonitorColorTemperature specified a color temperature that the current monitor did not support.
        ///     This error implies that the monitor violated the MCCS 2.0 or MCCS 2.0 Revision 1 specification.
        /// </summary>
        public const int ERROR_MCA_UNSUPPORTED_COLOR_TEMPERATURE = 0x00003B67; // 15207

        /// <summary>
        ///     The requested system device cannot be identified due to multiple indistinguishable devices potentially matching the
        ///     identification criteria.
        /// </summary>
        public const int ERROR_AMBIGUOUS_SYSTEM_DEVICE = 0x00003B92; // 15250

        /// <summary>
        ///     The requested system device cannot be found.
        /// </summary>
        public const int ERROR_SYSTEM_DEVICE_NOT_FOUND = 0x00003BC3; // 15299

        /// <summary>
        ///     Hash generation for the specified hash version and hash type is not enabled on the server.
        /// </summary>
        public const int ERROR_HASH_NOT_SUPPORTED = 0x00003BC4; // 15300

        /// <summary>
        ///     The hash requested from the server is not available or no longer valid.
        /// </summary>
        public const int ERROR_HASH_NOT_PRESENT = 0x00003BC5; // 15301

        /// <summary>
        ///     The secondary interrupt controller instance that manages the specified interrupt is not registered.
        /// </summary>
        public const int ERROR_SECONDARY_IC_PROVIDER_NOT_REGISTERED = 0x00003BD9; // 15321

        /// <summary>
        ///     The information supplied by the GPIO client driver is invalid.
        /// </summary>
        public const int ERROR_GPIO_CLIENT_INFORMATION_INVALID = 0x00003BDA; // 15322

        /// <summary>
        ///     The version specified by the GPIO client driver is not supported.
        /// </summary>
        public const int ERROR_GPIO_VERSION_NOT_SUPPORTED = 0x00003BDB; // 15323

        /// <summary>
        ///     The registration packet supplied by the GPIO client driver is not valid.
        /// </summary>
        public const int ERROR_GPIO_INVALID_REGISTRATION_PACKET = 0x00003BDC; // 15324

        /// <summary>
        ///     The requested operation is not suppported for the specified handle.
        /// </summary>
        public const int ERROR_GPIO_OPERATION_DENIED = 0x00003BDD; // 15325

        /// <summary>
        ///     The requested connect mode conflicts with an existing mode on one or more of the specified pins.
        /// </summary>
        public const int ERROR_GPIO_INCOMPATIBLE_CONNECT_MODE = 0x00003BDE; // 15326

        /// <summary>
        ///     The interrupt requested to be unmasked is not masked.
        /// </summary>
        public const int ERROR_GPIO_INTERRUPT_ALREADY_UNMASKED = 0x00003BDF; // 15327

        /// <summary>
        ///     The requested run level switch cannot be completed successfully.
        /// </summary>
        public const int ERROR_CANNOT_SWITCH_RUNLEVEL = 0x00003C28; // 15400

        /// <summary>
        ///     The service has an invalid run level setting. The run level for a service must not be higher than the run level of
        ///     its dependent services.
        /// </summary>
        public const int ERROR_INVALID_RUNLEVEL_SETTING = 0x00003C29; // 15401

        /// <summary>
        ///     The requested run level switch cannot be completed successfully since one or more services will not stop or restart
        ///     within the specified timeout.
        /// </summary>
        public const int ERROR_RUNLEVEL_SWITCH_TIMEOUT = 0x00003C2A; // 15402

        /// <summary>
        ///     A run level switch agent did not respond within the specified timeout.
        /// </summary>
        public const int ERROR_RUNLEVEL_SWITCH_AGENT_TIMEOUT = 0x00003C2B; // 15403

        /// <summary>
        ///     A run level switch is currently in progress.
        /// </summary>
        public const int ERROR_RUNLEVEL_SWITCH_IN_PROGRESS = 0x00003C2C; // 15404

        /// <summary>
        ///     One or more services failed to start during the service startup phase of a run level switch.
        /// </summary>
        public const int ERROR_SERVICES_FAILED_AUTOSTART = 0x00003C2D; // 15405

        /// <summary>
        ///     The task stop request cannot be completed immediately since task needs more time to shutdown.
        /// </summary>
        public const int ERROR_COM_TASK_STOP_PENDING = 0x00003C8D; // 15501

        /// <summary>
        ///     Package could not be opened.
        /// </summary>
        public const int ERROR_INSTALL_OPEN_PACKAGE_FAILED = 0x00003CF0; // 15600

        /// <summary>
        ///     Package was not found.
        /// </summary>
        public const int ERROR_INSTALL_PACKAGE_NOT_FOUND = 0x00003CF1; // 15601

        /// <summary>
        ///     Package data is invalid.
        /// </summary>
        public const int ERROR_INSTALL_INVALID_PACKAGE = 0x00003CF2; // 15602

        /// <summary>
        ///     Package failed updates, dependency or conflict validation.
        /// </summary>
        public const int ERROR_INSTALL_RESOLVE_DEPENDENCY_FAILED = 0x00003CF3; // 15603

        /// <summary>
        ///     There is not enough disk space on your computer. Please free up some space and try again.
        /// </summary>
        public const int ERROR_INSTALL_OUT_OF_DISK_SPACE = 0x00003CF4; // 15604

        /// <summary>
        ///     There was a problem downloading your product.
        /// </summary>
        public const int ERROR_INSTALL_NETWORK_FAILURE = 0x00003CF5; // 15605

        /// <summary>
        ///     Package could not be registered.
        /// </summary>
        public const int ERROR_INSTALL_REGISTRATION_FAILURE = 0x00003CF6; // 15606

        /// <summary>
        ///     Package could not be unregistered.
        /// </summary>
        public const int ERROR_INSTALL_DEREGISTRATION_FAILURE = 0x00003CF7; // 15607

        /// <summary>
        ///     User cancelled the install request.
        /// </summary>
        public const int ERROR_INSTALL_CANCEL = 0x00003CF8; // 15608

        /// <summary>
        ///     Install failed. Please contact your software vendor.
        /// </summary>
        public const int ERROR_INSTALL_FAILED = 0x00003CF9; // 15609

        /// <summary>
        ///     Removal failed. Please contact your software vendor.
        /// </summary>
        public const int ERROR_REMOVE_FAILED = 0x00003CFA; // 15610

        /// <summary>
        ///     The provided package is already installed, and reinstallation of the package was blocked. Check the
        ///     AppXDeployment-Server event log for details.
        /// </summary>
        public const int ERROR_PACKAGE_ALREADY_EXISTS = 0x00003CFB; // 15611

        /// <summary>
        ///     The application cannot be started. Try reinstalling the application to fix the problem.
        /// </summary>
        public const int ERROR_NEEDS_REMEDIATION = 0x00003CFC; // 15612

        /// <summary>
        ///     A Prerequisite for an install could not be satisfied.
        /// </summary>
        public const int ERROR_INSTALL_PREREQUISITE_FAILED = 0x00003CFD; // 15613

        /// <summary>
        ///     The package repository is corrupted.
        /// </summary>
        public const int ERROR_PACKAGE_REPOSITORY_CORRUPTED = 0x00003CFE; // 15614

        /// <summary>
        ///     To install this application you need either a Windows developer license or a sideloading-enabled system.
        /// </summary>
        public const int ERROR_INSTALL_POLICY_FAILURE = 0x00003CFF; // 15615

        /// <summary>
        ///     The application cannot be started because it is currently updating.
        /// </summary>
        public const int ERROR_PACKAGE_UPDATING = 0x00003D00; // 15616

        /// <summary>
        ///     The package deployment operation is blocked by policy. Please contact your system administrator.
        /// </summary>
        public const int ERROR_DEPLOYMENT_BLOCKED_BY_POLICY = 0x00003D01; // 15617

        /// <summary>
        ///     The package could not be installed because resources it modifies are currently in use.
        /// </summary>
        public const int ERROR_PACKAGES_IN_USE = 0x00003D02; // 15618

        /// <summary>
        ///     The package could not be recovered because necessary data for recovery have been corrupted.
        /// </summary>
        public const int ERROR_RECOVERY_FILE_CORRUPT = 0x00003D03; // 15619

        /// <summary>
        ///     The signature is invalid. To register in developer mode, AppxSignature.p7x and AppxBlockMap.xml must be valid or
        ///     should not be present.
        /// </summary>
        public const int ERROR_INVALID_STAGED_SIGNATURE = 0x00003D04; // 15620

        /// <summary>
        ///     An error occurred while deleting the package's previously existing application data.
        /// </summary>
        public const int ERROR_DELETING_EXISTING_APPLICATIONDATA_STORE_FAILED = 0x00003D05; // 15621

        /// <summary>
        ///     The package could not be installed because a higher version of this package is already installed.
        /// </summary>
        public const int ERROR_INSTALL_PACKAGE_DOWNGRADE = 0x00003D06; // 15622

        /// <summary>
        ///     An error in a system binary was detected. Try refreshing the PC to fix the problem.
        /// </summary>
        public const int ERROR_SYSTEM_NEEDS_REMEDIATION = 0x00003D07; // 15623

        /// <summary>
        ///     A corrupted CLR NGEN binary was detected on the system.
        /// </summary>
        public const int ERROR_APPX_INTEGRITY_FAILURE_CLR_NGEN = 0x00003D08; // 15624

        /// <summary>
        ///     The operation could not be resumed because necessary data for recovery have been corrupted.
        /// </summary>
        public const int ERROR_RESILIENCY_FILE_CORRUPT = 0x00003D09; // 15625

        /// <summary>
        ///     The package could not be installed because the Windows Firewall service is not running. Enable the Windows Firewall
        ///     service and try again.
        /// </summary>
        public const int ERROR_INSTALL_FIREWALL_SERVICE_NOT_RUNNING = 0x00003D0A; // 15626

        /// <summary>
        ///     The process has no package identity.
        /// </summary>
        public const int APPMODEL_ERROR_NO_PACKAGE = 0x00003D54; // 15700

        /// <summary>
        ///     The package runtime information is corrupted.
        /// </summary>
        public const int APPMODEL_ERROR_PACKAGE_RUNTIME_CORRUPT = 0x00003D55; // 15701

        /// <summary>
        ///     The package identity is corrupted.
        /// </summary>
        public const int APPMODEL_ERROR_PACKAGE_IDENTITY_CORRUPT = 0x00003D56; // 15702

        /// <summary>
        ///     The process has no application identity.
        /// </summary>
        public const int APPMODEL_ERROR_NO_APPLICATION = 0x00003D57; // 15703

        /// <summary>
        ///     Loading the state store failed.
        /// </summary>
        public const int ERROR_STATE_LOAD_STORE_FAILED = 0x00003DB8; // 15800

        /// <summary>
        ///     Retrieving the state version for the application failed.
        /// </summary>
        public const int ERROR_STATE_GET_VERSION_FAILED = 0x00003DB9; // 15801

        /// <summary>
        ///     Setting the state version for the application failed.
        /// </summary>
        public const int ERROR_STATE_SET_VERSION_FAILED = 0x00003DBA; // 15802

        /// <summary>
        ///     Resetting the structured state of the application failed.
        /// </summary>
        public const int ERROR_STATE_STRUCTURED_RESET_FAILED = 0x00003DBB; // 15803

        /// <summary>
        ///     State Manager failed to open the container.
        /// </summary>
        public const int ERROR_STATE_OPEN_CONTAINER_FAILED = 0x00003DBC; // 15804

        /// <summary>
        ///     State Manager failed to create the container.
        /// </summary>
        public const int ERROR_STATE_CREATE_CONTAINER_FAILED = 0x00003DBD; // 15805

        /// <summary>
        ///     State Manager failed to delete the container.
        /// </summary>
        public const int ERROR_STATE_DELETE_CONTAINER_FAILED = 0x00003DBE; // 15806

        /// <summary>
        ///     State Manager failed to read the setting.
        /// </summary>
        public const int ERROR_STATE_READ_SETTING_FAILED = 0x00003DBF; // 15807

        /// <summary>
        ///     State Manager failed to write the setting.
        /// </summary>
        public const int ERROR_STATE_WRITE_SETTING_FAILED = 0x00003DC0; // 15808

        /// <summary>
        ///     State Manager failed to delete the setting.
        /// </summary>
        public const int ERROR_STATE_DELETE_SETTING_FAILED = 0x00003DC1; // 15809

        /// <summary>
        ///     State Manager failed to query the setting.
        /// </summary>
        public const int ERROR_STATE_QUERY_SETTING_FAILED = 0x00003DC2; // 15810

        /// <summary>
        ///     State Manager failed to read the composite setting.
        /// </summary>
        public const int ERROR_STATE_READ_COMPOSITE_SETTING_FAILED = 0x00003DC3; // 15811

        /// <summary>
        ///     State Manager failed to write the composite setting.
        /// </summary>
        public const int ERROR_STATE_WRITE_COMPOSITE_SETTING_FAILED = 0x00003DC4; // 15812

        /// <summary>
        ///     State Manager failed to enumerate the containers.
        /// </summary>
        public const int ERROR_STATE_ENUMERATE_CONTAINER_FAILED = 0x00003DC5; // 15813

        /// <summary>
        ///     State Manager failed to enumerate the settings.
        /// </summary>
        public const int ERROR_STATE_ENUMERATE_SETTINGS_FAILED = 0x00003DC6; // 15814

        /// <summary>
        ///     The size of the state manager composite setting value has exceeded the limit.
        /// </summary>
        public const int ERROR_STATE_COMPOSITE_SETTING_VALUE_SIZE_LIMIT_EXCEEDED = 0x00003DC7; // 15815

        /// <summary>
        ///     The size of the state manager setting value has exceeded the limit.
        /// </summary>
        public const int ERROR_STATE_SETTING_VALUE_SIZE_LIMIT_EXCEEDED = 0x00003DC8; // 15816

        /// <summary>
        ///     The length of the state manager setting name has exceeded the limit.
        /// </summary>
        public const int ERROR_STATE_SETTING_NAME_SIZE_LIMIT_EXCEEDED = 0x00003DC9; // 15817

        /// <summary>
        ///     The length of the state manager container name has exceeded the limit.
        /// </summary>
        public const int ERROR_STATE_CONTAINER_NAME_SIZE_LIMIT_EXCEEDED = 0x00003DCA; // 15818

        /// <summary>
        ///     This API cannot be used in the context of the caller's application type.
        /// </summary>
        public const int ERROR_API_UNAVAILABLE = 0x00003DE1; // 15841

        #endregion
    }
}