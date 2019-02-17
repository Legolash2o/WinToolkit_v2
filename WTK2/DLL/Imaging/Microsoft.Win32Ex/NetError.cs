namespace Microsoft.Win32
{
    /// <summary>
    ///     Provides access to Network error codes.
    /// </summary>
    public static class NetError
    {
        /// <summary>
        ///     The operation completed successfully.
        /// </summary>
        public const int NERR_Success = 0x00000000; // 0

        /// <summary>
        ///     The workstation driver is not installed.
        /// </summary>
        public const int NERR_NetNotStarted = 0x00000836; // 2102

        /// <summary>
        ///     The server could not be located.
        /// </summary>
        public const int NERR_UnknownServer = 0x00000837; // 2103

        /// <summary>
        ///     An internal error occurred. The network cannot access a shared memory segment.
        /// </summary>
        public const int NERR_ShareMem = 0x00000838; // 2104

        /// <summary>
        ///     A network resource shortage occurred.
        /// </summary>
        public const int NERR_NoNetworkResource = 0x00000839; // 2105

        /// <summary>
        ///     This operation is not supported on workstations.
        /// </summary>
        public const int NERR_RemoteOnly = 0x0000083A; // 2106

        /// <summary>
        ///     The device is not connected.
        /// </summary>
        public const int NERR_DevNotRedirected = 0x0000083B; // 2107

        /// <summary>
        ///     The Server service is not started.
        /// </summary>
        public const int NERR_ServerNotStarted = 0x00000842; // 2114

        /// <summary>
        ///     The queue is empty.
        /// </summary>
        public const int NERR_ItemNotFound = 0x00000843; // 2115

        /// <summary>
        ///     The device or directory does not exist.
        /// </summary>
        public const int NERR_UnknownDevDir = 0x00000844; // 2116

        /// <summary>
        ///     The operation is invalid on a redirected resource.
        /// </summary>
        public const int NERR_RedirectedPath = 0x00000845; // 2117

        /// <summary>
        ///     The name has already been shared.
        /// </summary>
        public const int NERR_DuplicateShare = 0x00000846; // 2118

        /// <summary>
        ///     The server is currently out of the requested resource.
        /// </summary>
        public const int NERR_NoRoom = 0x00000847; // 2119

        /// <summary>
        ///     Requested addition of items exceeds the maximum allowed.
        /// </summary>
        public const int NERR_TooManyItems = 0x00000849; // 2121

        /// <summary>
        ///     The Peer service supports only two simultaneous users.
        /// </summary>
        public const int NERR_InvalidMaxUsers = 0x0000084A; // 2122

        /// <summary>
        ///     The API return buffer is too small.
        /// </summary>
        public const int NERR_BufTooSmall = 0x0000084B; // 2123

        /// <summary>
        ///     A remote API error occurred.
        /// </summary>
        public const int NERR_RemoteErr = 0x0000084F; // 2127

        /// <summary>
        ///     An error occurred when opening or reading the configuration file.
        /// </summary>
        public const int NERR_LanmanIniError = 0x00000853; // 2131

        /// <summary>
        ///     A general network error occurred.
        /// </summary>
        public const int NERR_NetworkError = 0x00000858; // 2136

        /// <summary>
        ///     The Workstation service is in an inconsistent state. Restart the computer before restarting the Workstation
        ///     service.
        /// </summary>
        public const int NERR_WkstaInconsistentState = 0x00000859; // 2137

        /// <summary>
        ///     The Workstation service has not been started.
        /// </summary>
        public const int NERR_WkstaNotStarted = 0x0000085A; // 2138

        /// <summary>
        ///     The requested information is not available.
        /// </summary>
        public const int NERR_BrowserNotStarted = 0x0000085B; // 2139

        /// <summary>
        ///     An internal error occurred.
        /// </summary>
        public const int NERR_InternalError = 0x0000085C; // 2140

        /// <summary>
        ///     The server is not configured for transactions.
        /// </summary>
        public const int NERR_BadTransactConfig = 0x0000085D; // 2141

        /// <summary>
        ///     The requested API is not supported on the remote server.
        /// </summary>
        public const int NERR_InvalidAPI = 0x0000085E; // 2142

        /// <summary>
        ///     The event name is invalid.
        /// </summary>
        public const int NERR_BadEventName = 0x0000085F; // 2143

        /// <summary>
        ///     The computer name already exists on the network. Change it and restart the computer.
        /// </summary>
        public const int NERR_DupNameReboot = 0x00000860; // 2144

        /// <summary>
        ///     The specified component could not be found in the configuration information.
        /// </summary>
        public const int NERR_CfgCompNotFound = 0x00000862; // 2146

        /// <summary>
        ///     The specified parameter could not be found in the configuration information.
        /// </summary>
        public const int NERR_CfgParamNotFound = 0x00000863; // 2147

        /// <summary>
        ///     A line in the configuration file is too long.
        /// </summary>
        public const int NERR_LineTooLong = 0x00000865; // 2149

        /// <summary>
        ///     The printer does not exist.
        /// </summary>
        public const int NERR_QNotFound = 0x00000866; // 2150

        /// <summary>
        ///     The print job does not exist.
        /// </summary>
        public const int NERR_JobNotFound = 0x00000867; // 2151

        /// <summary>
        ///     The printer destination cannot be found.
        /// </summary>
        public const int NERR_DestNotFound = 0x00000868; // 2152

        /// <summary>
        ///     The printer destination already exists.
        /// </summary>
        public const int NERR_DestExists = 0x00000869; // 2153

        /// <summary>
        ///     The printer queue already exists.
        /// </summary>
        public const int NERR_QExists = 0x0000086A; // 2154

        /// <summary>
        ///     No more printers can be added.
        /// </summary>
        public const int NERR_QNoRoom = 0x0000086B; // 2155

        /// <summary>
        ///     No more print jobs can be added.
        /// </summary>
        public const int NERR_JobNoRoom = 0x0000086C; // 2156

        /// <summary>
        ///     No more printer destinations can be added.
        /// </summary>
        public const int NERR_DestNoRoom = 0x0000086D; // 2157

        /// <summary>
        ///     This printer destination is idle and cannot accept control operations.
        /// </summary>
        public const int NERR_DestIdle = 0x0000086E; // 2158

        /// <summary>
        ///     This printer destination request contains an invalid control function.
        /// </summary>
        public const int NERR_DestInvalidOp = 0x0000086F; // 2159

        /// <summary>
        ///     The print processor is not responding.
        /// </summary>
        public const int NERR_ProcNoRespond = 0x00000870; // 2160

        /// <summary>
        ///     The spooler is not running.
        /// </summary>
        public const int NERR_SpoolerNotLoaded = 0x00000871; // 2161

        /// <summary>
        ///     This operation cannot be performed on the print destination in its current state.
        /// </summary>
        public const int NERR_DestInvalidState = 0x00000872; // 2162

        /// <summary>
        ///     This operation cannot be performed on the printer queue in its current state.
        /// </summary>
        public const int NERR_QinvalidState = 0x00000873; // 2163

        /// <summary>
        ///     This operation cannot be performed on the print job in its current state.
        /// </summary>
        public const int NERR_JobInvalidState = 0x00000874; // 2164

        /// <summary>
        ///     A spooler memory allocation failure occurred.
        /// </summary>
        public const int NERR_SpoolNoMemory = 0x00000875; // 2165

        /// <summary>
        ///     The device driver does not exist.
        /// </summary>
        public const int NERR_DriverNotFound = 0x00000876; // 2166

        /// <summary>
        ///     The data type is not supported by the print processor.
        /// </summary>
        public const int NERR_DataTypeInvalid = 0x00000877; // 2167

        /// <summary>
        ///     The print processor is not installed.
        /// </summary>
        public const int NERR_ProcNotFound = 0x00000878; // 2168

        /// <summary>
        ///     The service database is locked.
        /// </summary>
        public const int NERR_ServiceTableLocked = 0x00000884; // 2180

        /// <summary>
        ///     The service table is full.
        /// </summary>
        public const int NERR_ServiceTableFull = 0x00000885; // 2181

        /// <summary>
        ///     The requested service has already been started.
        /// </summary>
        public const int NERR_ServiceInstalled = 0x00000886; // 2182

        /// <summary>
        ///     The service does not respond to control actions.
        /// </summary>
        public const int NERR_ServiceEntryLocked = 0x00000887; // 2183

        /// <summary>
        ///     The service has not been started.
        /// </summary>
        public const int NERR_ServiceNotInstalled = 0x00000888; // 2184

        /// <summary>
        ///     The service name is invalid.
        /// </summary>
        public const int NERR_BadServiceName = 0x00000889; // 2185

        /// <summary>
        ///     The service is not responding to the control function.
        /// </summary>
        public const int NERR_ServiceCtlTimeout = 0x0000088A; // 2186

        /// <summary>
        ///     The service control is busy.
        /// </summary>
        public const int NERR_ServiceCtlBusy = 0x0000088B; // 2187

        /// <summary>
        ///     The configuration file contains an invalid service program name.
        /// </summary>
        public const int NERR_BadServiceProgName = 0x0000088C; // 2188

        /// <summary>
        ///     The service could not be controlled in its present state.
        /// </summary>
        public const int NERR_ServiceNotCtrl = 0x0000088D; // 2189

        /// <summary>
        ///     The service ended abnormally.
        /// </summary>
        public const int NERR_ServiceKillProc = 0x0000088E; // 2190

        /// <summary>
        ///     The requested pause or stop is not valid for this service.
        /// </summary>
        public const int NERR_ServiceCtlNotValid = 0x0000088F; // 2191

        /// <summary>
        ///     The service control dispatcher could not find the service name in the dispatch table.
        /// </summary>
        public const int NERR_NotInDispatchTbl = 0x00000890; // 2192

        /// <summary>
        ///     The service control dispatcher pipe read failed.
        /// </summary>
        public const int NERR_BadControlRecv = 0x00000891; // 2193

        /// <summary>
        ///     A thread for the new service could not be created.
        /// </summary>
        public const int NERR_ServiceNotStarting = 0x00000892; // 2194

        /// <summary>
        ///     This workstation is already logged on to the local-area network.
        /// </summary>
        public const int NERR_AlreadyLoggedOn = 0x00000898; // 2200

        /// <summary>
        ///     The workstation is not logged on to the local-area network.
        /// </summary>
        public const int NERR_NotLoggedOn = 0x00000899; // 2201

        /// <summary>
        ///     The user name or group name parameter is invalid.
        /// </summary>
        public const int NERR_BadUsername = 0x0000089A; // 2202

        /// <summary>
        ///     The password parameter is invalid.
        /// </summary>
        public const int NERR_BadPassword = 0x0000089B; // 2203

        /// <summary>
        ///     @W The logon processor did not add the message alias.
        /// </summary>
        public const int NERR_UnableToAddName_W = 0x0000089C; // 2204

        /// <summary>
        ///     The logon processor did not add the message alias.
        /// </summary>
        public const int NERR_UnableToAddName_F = 0x0000089D; // 2205

        /// <summary>
        ///     @W The logoff processor did not delete the message alias.
        /// </summary>
        public const int NERR_UnableToDelName_W = 0x0000089E; // 2206

        /// <summary>
        ///     The logoff processor did not delete the message alias.
        /// </summary>
        public const int NERR_UnableToDelName_F = 0x0000089F; // 2207

        /// <summary>
        ///     Network logons are paused.
        /// </summary>
        public const int NERR_LogonsPaused = 0x000008A1; // 2209

        /// <summary>
        ///     A centralized logon-server conflict occurred.
        /// </summary>
        public const int NERR_LogonServerConflict = 0x000008A2; // 2210

        /// <summary>
        ///     The server is configured without a valid user path.
        /// </summary>
        public const int NERR_LogonNoUserPath = 0x000008A3; // 2211

        /// <summary>
        ///     An error occurred while loading or running the logon script.
        /// </summary>
        public const int NERR_LogonScriptError = 0x000008A4; // 2212

        /// <summary>
        ///     The logon server was not specified. Your computer will be logged on as STANDALONE.
        /// </summary>
        public const int NERR_StandaloneLogon = 0x000008A6; // 2214

        /// <summary>
        ///     The logon server could not be found.
        /// </summary>
        public const int NERR_LogonServerNotFound = 0x000008A7; // 2215

        /// <summary>
        ///     There is already a logon domain for this computer.
        /// </summary>
        public const int NERR_LogonDomainExists = 0x000008A8; // 2216

        /// <summary>
        ///     The logon server could not validate the logon.
        /// </summary>
        public const int NERR_NonValidatedLogon = 0x000008A9; // 2217

        /// <summary>
        ///     The security database could not be found.
        /// </summary>
        public const int NERR_ACFNotFound = 0x000008AB; // 2219

        /// <summary>
        ///     The group name could not be found.
        /// </summary>
        public const int NERR_GroupNotFound = 0x000008AC; // 2220

        /// <summary>
        ///     The user name could not be found.
        /// </summary>
        public const int NERR_UserNotFound = 0x000008AD; // 2221

        /// <summary>
        ///     The resource name could not be found.
        /// </summary>
        public const int NERR_ResourceNotFound = 0x000008AE; // 2222

        /// <summary>
        ///     The group already exists.
        /// </summary>
        public const int NERR_GroupExists = 0x000008AF; // 2223

        /// <summary>
        ///     The user account already exists.
        /// </summary>
        public const int NERR_UserExists = 0x000008B0; // 2224

        /// <summary>
        ///     The resource permission list already exists.
        /// </summary>
        public const int NERR_ResourceExists = 0x000008B1; // 2225

        /// <summary>
        ///     This operation is only allowed on the primary domain controller of the domain.
        /// </summary>
        public const int NERR_NotPrimary = 0x000008B2; // 2226

        /// <summary>
        ///     The security database has not been started.
        /// </summary>
        public const int NERR_ACFNotLoaded = 0x000008B3; // 2227

        /// <summary>
        ///     There are too many names in the user accounts database.
        /// </summary>
        public const int NERR_ACFNoRoom = 0x000008B4; // 2228

        /// <summary>
        ///     A disk I/O failure occurred.
        /// </summary>
        public const int NERR_ACFFileIOFail = 0x000008B5; // 2229

        /// <summary>
        ///     The limit of 64 entries per resource was exceeded.
        /// </summary>
        public const int NERR_ACFTooManyLists = 0x000008B6; // 2230

        /// <summary>
        ///     Deleting a user with a session is not allowed.
        /// </summary>
        public const int NERR_UserLogon = 0x000008B7; // 2231

        /// <summary>
        ///     The parent directory could not be located.
        /// </summary>
        public const int NERR_ACFNoParent = 0x000008B8; // 2232

        /// <summary>
        ///     Unable to add to the security database session cache segment.
        /// </summary>
        public const int NERR_CanNotGrowSegment = 0x000008B9; // 2233

        /// <summary>
        ///     This operation is not allowed on this special group.
        /// </summary>
        public const int NERR_SpeGroupOp = 0x000008BA; // 2234

        /// <summary>
        ///     This user is not cached in user accounts database session cache.
        /// </summary>
        public const int NERR_NotInCache = 0x000008BB; // 2235

        /// <summary>
        ///     The user already belongs to this group.
        /// </summary>
        public const int NERR_UserInGroup = 0x000008BC; // 2236

        /// <summary>
        ///     The user does not belong to this group.
        /// </summary>
        public const int NERR_UserNotInGroup = 0x000008BD; // 2237

        /// <summary>
        ///     This user account is undefined.
        /// </summary>
        public const int NERR_AccountUndefined = 0x000008BE; // 2238

        /// <summary>
        ///     This user account has expired.
        /// </summary>
        public const int NERR_AccountExpired = 0x000008BF; // 2239

        /// <summary>
        ///     The user is not allowed to log on from this workstation.
        /// </summary>
        public const int NERR_InvalidWorkstation = 0x000008C0; // 2240

        /// <summary>
        ///     The user is not allowed to log on at this time.
        /// </summary>
        public const int NERR_InvalidLogonHours = 0x000008C1; // 2241

        /// <summary>
        ///     The password of this user has expired.
        /// </summary>
        public const int NERR_PasswordExpired = 0x000008C2; // 2242

        /// <summary>
        ///     The password of this user cannot change.
        /// </summary>
        public const int NERR_PasswordCantChange = 0x000008C3; // 2243

        /// <summary>
        ///     This password cannot be used now.
        /// </summary>
        public const int NERR_PasswordHistConflict = 0x000008C4; // 2244

        /// <summary>
        ///     The password does not meet the password policy requirements. Check the minimum password length, password complexity
        ///     and password history requirements.
        /// </summary>
        public const int NERR_PasswordTooShort = 0x000008C5; // 2245

        /// <summary>
        ///     The password of this user is too recent to change.
        /// </summary>
        public const int NERR_PasswordTooRecent = 0x000008C6; // 2246

        /// <summary>
        ///     The security database is corrupted.
        /// </summary>
        public const int NERR_InvalidDatabase = 0x000008C7; // 2247

        /// <summary>
        ///     No updates are necessary to this replicant network/local security database.
        /// </summary>
        public const int NERR_DatabaseUpToDate = 0x000008C8; // 2248

        /// <summary>
        ///     This replicant database is outdated; synchronization is required.
        /// </summary>
        public const int NERR_SyncRequired = 0x000008C9; // 2249

        /// <summary>
        ///     The network connection could not be found.
        /// </summary>
        public const int NERR_UseNotFound = 0x000008CA; // 2250

        /// <summary>
        ///     This asg_type is invalid.
        /// </summary>
        public const int NERR_BadAsgType = 0x000008CB; // 2251

        /// <summary>
        ///     This device is currently being shared.
        /// </summary>
        public const int NERR_DeviceIsShared = 0x000008CC; // 2252

        /// <summary>
        ///     The computer name could not be added as a message alias. The name may already exist on the network.
        /// </summary>
        public const int NERR_NoComputerName = 0x000008DE; // 2270

        /// <summary>
        ///     The Messenger service is already started.
        /// </summary>
        public const int NERR_MsgAlreadyStarted = 0x000008DF; // 2271

        /// <summary>
        ///     The Messenger service failed to start.
        /// </summary>
        public const int NERR_MsgInitFailed = 0x000008E0; // 2272

        /// <summary>
        ///     The message alias could not be found on the network.
        /// </summary>
        public const int NERR_NameNotFound = 0x000008E1; // 2273

        /// <summary>
        ///     This message alias has already been forwarded.
        /// </summary>
        public const int NERR_AlreadyForwarded = 0x000008E2; // 2274

        /// <summary>
        ///     This message alias has been added but is still forwarded.
        /// </summary>
        public const int NERR_AddForwarded = 0x000008E3; // 2275

        /// <summary>
        ///     This message alias already exists locally.
        /// </summary>
        public const int NERR_AlreadyExists = 0x000008E4; // 2276

        /// <summary>
        ///     The maximum number of added message aliases has been exceeded.
        /// </summary>
        public const int NERR_TooManyNames = 0x000008E5; // 2277

        /// <summary>
        ///     The computer name could not be deleted.
        /// </summary>
        public const int NERR_DelComputerName = 0x000008E6; // 2278

        /// <summary>
        ///     Messages cannot be forwarded back to the same workstation.
        /// </summary>
        public const int NERR_LocalForward = 0x000008E7; // 2279

        /// <summary>
        ///     An error occurred in the domain message processor.
        /// </summary>
        public const int NERR_GrpMsgProcessor = 0x000008E8; // 2280

        /// <summary>
        ///     The message was sent, but the recipient has paused the Messenger service.
        /// </summary>
        public const int NERR_PausedRemote = 0x000008E9; // 2281

        /// <summary>
        ///     The message was sent but not received.
        /// </summary>
        public const int NERR_BadReceive = 0x000008EA; // 2282

        /// <summary>
        ///     The message alias is currently in use. Try again later.
        /// </summary>
        public const int NERR_NameInUse = 0x000008EB; // 2283

        /// <summary>
        ///     The Messenger service has not been started.
        /// </summary>
        public const int NERR_MsgNotStarted = 0x000008EC; // 2284

        /// <summary>
        ///     The name is not on the local computer.
        /// </summary>
        public const int NERR_NotLocalName = 0x000008ED; // 2285

        /// <summary>
        ///     The forwarded message alias could not be found on the network.
        /// </summary>
        public const int NERR_NoForwardName = 0x000008EE; // 2286

        /// <summary>
        ///     The message alias table on the remote station is full.
        /// </summary>
        public const int NERR_RemoteFull = 0x000008EF; // 2287

        /// <summary>
        ///     Messages for this alias are not currently being forwarded.
        /// </summary>
        public const int NERR_NameNotForwarded = 0x000008F0; // 2288

        /// <summary>
        ///     The broadcast message was truncated.
        /// </summary>
        public const int NERR_TruncatedBroadcast = 0x000008F1; // 2289

        /// <summary>
        ///     This is an invalid device name.
        /// </summary>
        public const int NERR_InvalidDevice = 0x000008F6; // 2294

        /// <summary>
        ///     A write fault occurred.
        /// </summary>
        public const int NERR_WriteFault = 0x000008F7; // 2295

        /// <summary>
        ///     A duplicate message alias exists on the network.
        /// </summary>
        public const int NERR_DuplicateName = 0x000008F9; // 2297

        /// <summary>
        ///     @W This message alias will be deleted later.
        /// </summary>
        public const int NERR_DeleteLater = 0x000008FA; // 2298

        /// <summary>
        ///     The message alias was not successfully deleted from all networks.
        /// </summary>
        public const int NERR_IncompleteDel = 0x000008FB; // 2299

        /// <summary>
        ///     This operation is not supported on computers with multiple networks.
        /// </summary>
        public const int NERR_MultipleNets = 0x000008FC; // 2300

        /// <summary>
        ///     This shared resource does not exist.
        /// </summary>
        public const int NERR_NetNameNotFound = 0x00000906; // 2310

        /// <summary>
        ///     This device is not shared.
        /// </summary>
        public const int NERR_DeviceNotShared = 0x00000907; // 2311

        /// <summary>
        ///     A session does not exist with that computer name.
        /// </summary>
        public const int NERR_ClientNameNotFound = 0x00000908; // 2312

        /// <summary>
        ///     There is not an open file with that identification number.
        /// </summary>
        public const int NERR_FileIdNotFound = 0x0000090A; // 2314

        /// <summary>
        ///     A failure occurred when executing a remote administration command.
        /// </summary>
        public const int NERR_ExecFailure = 0x0000090B; // 2315

        /// <summary>
        ///     A failure occurred when opening a remote temporary file.
        /// </summary>
        public const int NERR_TmpFile = 0x0000090C; // 2316

        /// <summary>
        ///     The data returned from a remote administration command has been truncated to 64K.
        /// </summary>
        public const int NERR_TooMuchData = 0x0000090D; // 2317

        /// <summary>
        ///     This device cannot be shared as both a spooled and a non-spooled resource.
        /// </summary>
        public const int NERR_DeviceShareConflict = 0x0000090E; // 2318

        /// <summary>
        ///     The information in the list of servers may be incorrect.
        /// </summary>
        public const int NERR_BrowserTableIncomplete = 0x0000090F; // 2319

        /// <summary>
        ///     The computer is not active in this domain.
        /// </summary>
        public const int NERR_NotLocalDomain = 0x00000910; // 2320

        /// <summary>
        ///     The share must be removed from the Distributed File System before it can be deleted.
        /// </summary>
        public const int NERR_IsDfsShare = 0x00000911; // 2321

        /// <summary>
        ///     The operation is invalid for this device.
        /// </summary>
        public const int NERR_DevInvalidOpCode = 0x0000091B; // 2331

        /// <summary>
        ///     This device cannot be shared.
        /// </summary>
        public const int NERR_DevNotFound = 0x0000091C; // 2332

        /// <summary>
        ///     This device was not open.
        /// </summary>
        public const int NERR_DevNotOpen = 0x0000091D; // 2333

        /// <summary>
        ///     This device name list is invalid.
        /// </summary>
        public const int NERR_BadQueueDevString = 0x0000091E; // 2334

        /// <summary>
        ///     The queue priority is invalid.
        /// </summary>
        public const int NERR_BadQueuePriority = 0x0000091F; // 2335

        /// <summary>
        ///     There are no shared communication devices.
        /// </summary>
        public const int NERR_NoCommDevs = 0x00000921; // 2337

        /// <summary>
        ///     The queue you specified does not exist.
        /// </summary>
        public const int NERR_QueueNotFound = 0x00000922; // 2338

        /// <summary>
        ///     This list of devices is invalid.
        /// </summary>
        public const int NERR_BadDevString = 0x00000924; // 2340

        /// <summary>
        ///     The requested device is invalid.
        /// </summary>
        public const int NERR_BadDev = 0x00000925; // 2341

        /// <summary>
        ///     This device is already in use by the spooler.
        /// </summary>
        public const int NERR_InUseBySpooler = 0x00000926; // 2342

        /// <summary>
        ///     This device is already in use as a communication device.
        /// </summary>
        public const int NERR_CommDevInUse = 0x00000927; // 2343

        /// <summary>
        ///     This computer name is invalid.
        /// </summary>
        public const int NERR_InvalidComputer = 0x0000092F; // 2351

        /// <summary>
        ///     The string and prefix specified are too long.
        /// </summary>
        public const int NERR_MaxLenExceeded = 0x00000932; // 2354

        /// <summary>
        ///     This path component is invalid.
        /// </summary>
        public const int NERR_BadComponent = 0x00000934; // 2356

        /// <summary>
        ///     Could not determine the type of input.
        /// </summary>
        public const int NERR_CantType = 0x00000935; // 2357

        /// <summary>
        ///     The buffer for types is not big enough.
        /// </summary>
        public const int NERR_TooManyEntries = 0x0000093A; // 2362

        /// <summary>
        ///     Profile files cannot exceed 64K.
        /// </summary>
        public const int NERR_ProfileFileTooBig = 0x00000942; // 2370

        /// <summary>
        ///     The start offset is out of range.
        /// </summary>
        public const int NERR_ProfileOffset = 0x00000943; // 2371

        /// <summary>
        ///     The system cannot delete current connections to network resources.
        /// </summary>
        public const int NERR_ProfileCleanup = 0x00000944; // 2372

        /// <summary>
        ///     The system was unable to parse the command line in this file.
        /// </summary>
        public const int NERR_ProfileUnknownCmd = 0x00000945; // 2373

        /// <summary>
        ///     An error occurred while loading the profile file.
        /// </summary>
        public const int NERR_ProfileLoadErr = 0x00000946; // 2374

        /// <summary>
        ///     @W Errors occurred while saving the profile file. The profile was partially saved.
        /// </summary>
        public const int NERR_ProfileSaveErr = 0x00000947; // 2375

        /// <summary>
        ///     Log file %1 is full.
        /// </summary>
        public const int NERR_LogOverflow = 0x00000949; // 2377

        /// <summary>
        ///     This log file has changed between reads.
        /// </summary>
        public const int NERR_LogFileChanged = 0x0000094A; // 2378

        /// <summary>
        ///     Log file %1 is corrupt.
        /// </summary>
        public const int NERR_LogFileCorrupt = 0x0000094B; // 2379

        /// <summary>
        ///     The source path cannot be a directory.
        /// </summary>
        public const int NERR_SourceIsDir = 0x0000094C; // 2380

        /// <summary>
        ///     The source path is illegal.
        /// </summary>
        public const int NERR_BadSource = 0x0000094D; // 2381

        /// <summary>
        ///     The destination path is illegal.
        /// </summary>
        public const int NERR_BadDest = 0x0000094E; // 2382

        /// <summary>
        ///     The source and destination paths are on different servers.
        /// </summary>
        public const int NERR_DifferentServers = 0x0000094F; // 2383

        /// <summary>
        ///     The Run server you requested is paused.
        /// </summary>
        public const int NERR_RunSrvPaused = 0x00000951; // 2385

        /// <summary>
        ///     An error occurred when communicating with a Run server.
        /// </summary>
        public const int NERR_ErrCommRunSrv = 0x00000955; // 2389

        /// <summary>
        ///     An error occurred when starting a background process.
        /// </summary>
        public const int NERR_ErrorExecingGhost = 0x00000957; // 2391

        /// <summary>
        ///     The shared resource you are connected to could not be found.
        /// </summary>
        public const int NERR_ShareNotFound = 0x00000958; // 2392

        /// <summary>
        ///     The LAN adapter number is invalid.
        /// </summary>
        public const int NERR_InvalidLana = 0x00000960; // 2400

        /// <summary>
        ///     There are open files on the connection.
        /// </summary>
        public const int NERR_OpenFiles = 0x00000961; // 2401

        /// <summary>
        ///     Active connections still exist.
        /// </summary>
        public const int NERR_ActiveConns = 0x00000962; // 2402

        /// <summary>
        ///     This share name or password is invalid.
        /// </summary>
        public const int NERR_BadPasswordCore = 0x00000963; // 2403

        /// <summary>
        ///     The device is being accessed by an active process.
        /// </summary>
        public const int NERR_DevInUse = 0x00000964; // 2404

        /// <summary>
        ///     The drive letter is in use locally.
        /// </summary>
        public const int NERR_LocalDrive = 0x00000965; // 2405

        /// <summary>
        ///     The specified client is already registered for the specified event.
        /// </summary>
        public const int NERR_AlertExists = 0x0000097E; // 2430

        /// <summary>
        ///     The alert table is full.
        /// </summary>
        public const int NERR_TooManyAlerts = 0x0000097F; // 2431

        /// <summary>
        ///     An invalid or nonexistent alert name was raised.
        /// </summary>
        public const int NERR_NoSuchAlert = 0x00000980; // 2432

        /// <summary>
        ///     The alert recipient is invalid.
        /// </summary>
        public const int NERR_BadRecipient = 0x00000981; // 2433

        /// <summary>
        ///     A user's session with this server has been deleted
        /// </summary>
        public const int NERR_AcctLimitExceeded = 0x00000982; // 2434

        /// <summary>
        ///     The log file does not contain the requested record number.
        /// </summary>
        public const int NERR_InvalidLogSeek = 0x00000988; // 2440

        /// <summary>
        ///     The user accounts database is not configured correctly.
        /// </summary>
        public const int NERR_BadUasConfig = 0x00000992; // 2450

        /// <summary>
        ///     This operation is not permitted when the Netlogon service is running.
        /// </summary>
        public const int NERR_InvalidUASOp = 0x00000993; // 2451

        /// <summary>
        ///     This operation is not allowed on the last administrative account.
        /// </summary>
        public const int NERR_LastAdmin = 0x00000994; // 2452

        /// <summary>
        ///     Could not find domain controller for this domain.
        /// </summary>
        public const int NERR_DCNotFound = 0x00000995; // 2453

        /// <summary>
        ///     Could not set logon information for this user.
        /// </summary>
        public const int NERR_LogonTrackingError = 0x00000996; // 2454

        /// <summary>
        ///     The Netlogon service has not been started.
        /// </summary>
        public const int NERR_NetlogonNotStarted = 0x00000997; // 2455

        /// <summary>
        ///     Unable to add to the user accounts database.
        /// </summary>
        public const int NERR_CanNotGrowUASFile = 0x00000998; // 2456

        /// <summary>
        ///     This server's clock is not synchronized with the primary domain controller's clock.
        /// </summary>
        public const int NERR_TimeDiffAtDC = 0x00000999; // 2457

        /// <summary>
        ///     A password mismatch has been detected.
        /// </summary>
        public const int NERR_PasswordMismatch = 0x0000099A; // 2458

        /// <summary>
        ///     The server identification does not specify a valid server.
        /// </summary>
        public const int NERR_NoSuchServer = 0x0000099C; // 2460

        /// <summary>
        ///     The session identification does not specify a valid session.
        /// </summary>
        public const int NERR_NoSuchSession = 0x0000099D; // 2461

        /// <summary>
        ///     The connection identification does not specify a valid connection.
        /// </summary>
        public const int NERR_NoSuchConnection = 0x0000099E; // 2462

        /// <summary>
        ///     There is no space for another entry in the table of available servers.
        /// </summary>
        public const int NERR_TooManyServers = 0x0000099F; // 2463

        /// <summary>
        ///     The server has reached the maximum number of sessions it supports.
        /// </summary>
        public const int NERR_TooManySessions = 0x000009A0; // 2464

        /// <summary>
        ///     The server has reached the maximum number of connections it supports.
        /// </summary>
        public const int NERR_TooManyConnections = 0x000009A1; // 2465

        /// <summary>
        ///     The server cannot open more files because it has reached its maximum number.
        /// </summary>
        public const int NERR_TooManyFiles = 0x000009A2; // 2466

        /// <summary>
        ///     There are no alternate servers registered on this server.
        /// </summary>
        public const int NERR_NoAlternateServers = 0x000009A3; // 2467

        /// <summary>
        ///     Try down-level (remote admin protocol) version of API instead.
        /// </summary>
        public const int NERR_TryDownLevel = 0x000009A6; // 2470

        /// <summary>
        ///     The UPS driver could not be accessed by the UPS service.
        /// </summary>
        public const int NERR_UPSDriverNotStarted = 0x000009B0; // 2480

        /// <summary>
        ///     The UPS service is not configured correctly.
        /// </summary>
        public const int NERR_UPSInvalidConfig = 0x000009B1; // 2481

        /// <summary>
        ///     The UPS service could not access the specified Comm Port.
        /// </summary>
        public const int NERR_UPSInvalidCommPort = 0x000009B2; // 2482

        /// <summary>
        ///     The UPS indicated a line fail or low battery situation. Service not started.
        /// </summary>
        public const int NERR_UPSSignalAsserted = 0x000009B3; // 2483

        /// <summary>
        ///     The UPS service failed to perform a system shut down.
        /// </summary>
        public const int NERR_UPSShutdownFailed = 0x000009B4; // 2484

        /// <summary>
        ///     The program below returned an MS-DOS error code:
        /// </summary>
        public const int NERR_BadDosRetCode = 0x000009C4; // 2500

        /// <summary>
        ///     The program below needs more memory:
        /// </summary>
        public const int NERR_ProgNeedsExtraMem = 0x000009C5; // 2501

        /// <summary>
        ///     The program below called an unsupported MS-DOS function:
        /// </summary>
        public const int NERR_BadDosFunction = 0x000009C6; // 2502

        /// <summary>
        ///     The workstation failed to boot.
        /// </summary>
        public const int NERR_RemoteBootFailed = 0x000009C7; // 2503

        /// <summary>
        ///     The file below is corrupt.
        /// </summary>
        public const int NERR_BadFileCheckSum = 0x000009C8; // 2504

        /// <summary>
        ///     No loader is specified in the boot-block definition file.
        /// </summary>
        public const int NERR_NoRplBootSystem = 0x000009C9; // 2505

        /// <summary>
        ///     NetBIOS returned an error: The NCB and SMB are dumped above.
        /// </summary>
        public const int NERR_RplLoadrNetBiosErr = 0x000009CA; // 2506

        /// <summary>
        ///     A disk I/O error occurred.
        /// </summary>
        public const int NERR_RplLoadrDiskErr = 0x000009CB; // 2507

        /// <summary>
        ///     Image parameter substitution failed.
        /// </summary>
        public const int NERR_ImageParamErr = 0x000009CC; // 2508

        /// <summary>
        ///     Too many image parameters cross disk sector boundaries.
        /// </summary>
        public const int NERR_TooManyImageParams = 0x000009CD; // 2509

        /// <summary>
        ///     The image was not generated from an MS-DOS diskette formatted with /S.
        /// </summary>
        public const int NERR_NonDosFloppyUsed = 0x000009CE; // 2510

        /// <summary>
        ///     Remote boot will be restarted later.
        /// </summary>
        public const int NERR_RplBootRestart = 0x000009CF; // 2511

        /// <summary>
        ///     The call to the Remoteboot server failed.
        /// </summary>
        public const int NERR_RplSrvrCallFailed = 0x000009D0; // 2512

        /// <summary>
        ///     Cannot connect to the Remoteboot server.
        /// </summary>
        public const int NERR_CantConnectRplSrvr = 0x000009D1; // 2513

        /// <summary>
        ///     Cannot open image file on the Remoteboot server.
        /// </summary>
        public const int NERR_CantOpenImageFile = 0x000009D2; // 2514

        /// <summary>
        ///     Connecting to the Remoteboot server...
        /// </summary>
        public const int NERR_CallingRplSrvr = 0x000009D3; // 2515

        /// <summary>
        ///     Connecting to the Remoteboot server...
        /// </summary>
        public const int NERR_StartingRplBoot = 0x000009D4; // 2516

        /// <summary>
        ///     Remote boot service was stopped; check the error log for the cause of the problem.
        /// </summary>
        public const int NERR_RplBootServiceTerm = 0x000009D5; // 2517

        /// <summary>
        ///     Remote boot startup failed; check the error log for the cause of the problem.
        /// </summary>
        public const int NERR_RplBootStartFailed = 0x000009D6; // 2518

        /// <summary>
        ///     A second connection to a Remoteboot resource is not allowed.
        /// </summary>
        public const int NERR_RPL_CONNECTED = 0x000009D7; // 2519

        /// <summary>
        ///     The browser service was configured with MaintainServerList=No.
        /// </summary>
        public const int NERR_BrowserConfiguredToNotRun = 0x000009F6; // 2550

        /// <summary>
        ///     Service failed to start since none of the network adapters started with this service.
        /// </summary>
        public const int NERR_RplNoAdaptersStarted = 0x00000A32; // 2610

        /// <summary>
        ///     Service failed to start due to bad startup information in the registry.
        /// </summary>
        public const int NERR_RplBadRegistry = 0x00000A33; // 2611

        /// <summary>
        ///     Service failed to start because its database is absent or corrupt.
        /// </summary>
        public const int NERR_RplBadDatabase = 0x00000A34; // 2612

        /// <summary>
        ///     Service failed to start because RPLFILES share is absent.
        /// </summary>
        public const int NERR_RplRplfilesShare = 0x00000A35; // 2613

        /// <summary>
        ///     Service failed to start because RPLUSER group is absent.
        /// </summary>
        public const int NERR_RplNotRplServer = 0x00000A36; // 2614

        /// <summary>
        ///     Cannot enumerate service records.
        /// </summary>
        public const int NERR_RplCannotEnum = 0x00000A37; // 2615

        /// <summary>
        ///     Workstation record information has been corrupted.
        /// </summary>
        public const int NERR_RplWkstaInfoCorrupted = 0x00000A38; // 2616

        /// <summary>
        ///     Workstation record was not found.
        /// </summary>
        public const int NERR_RplWkstaNotFound = 0x00000A39; // 2617

        /// <summary>
        ///     Workstation name is in use by some other workstation.
        /// </summary>
        public const int NERR_RplWkstaNameUnavailable = 0x00000A3A; // 2618

        /// <summary>
        ///     Profile record information has been corrupted.
        /// </summary>
        public const int NERR_RplProfileInfoCorrupted = 0x00000A3B; // 2619

        /// <summary>
        ///     Profile record was not found.
        /// </summary>
        public const int NERR_RplProfileNotFound = 0x00000A3C; // 2620

        /// <summary>
        ///     Profile name is in use by some other profile.
        /// </summary>
        public const int NERR_RplProfileNameUnavailable = 0x00000A3D; // 2621

        /// <summary>
        ///     There are workstations using this profile.
        /// </summary>
        public const int NERR_RplProfileNotEmpty = 0x00000A3E; // 2622

        /// <summary>
        ///     Configuration record information has been corrupted.
        /// </summary>
        public const int NERR_RplConfigInfoCorrupted = 0x00000A3F; // 2623

        /// <summary>
        ///     Configuration record was not found.
        /// </summary>
        public const int NERR_RplConfigNotFound = 0x00000A40; // 2624

        /// <summary>
        ///     Adapter ID record information has been corrupted.
        /// </summary>
        public const int NERR_RplAdapterInfoCorrupted = 0x00000A41; // 2625

        /// <summary>
        ///     An internal service error has occurred.
        /// </summary>
        public const int NERR_RplInternal = 0x00000A42; // 2626

        /// <summary>
        ///     Vendor ID record information has been corrupted.
        /// </summary>
        public const int NERR_RplVendorInfoCorrupted = 0x00000A43; // 2627

        /// <summary>
        ///     Boot block record information has been corrupted.
        /// </summary>
        public const int NERR_RplBootInfoCorrupted = 0x00000A44; // 2628

        /// <summary>
        ///     The user account for this workstation record is missing.
        /// </summary>
        public const int NERR_RplWkstaNeedsUserAcct = 0x00000A45; // 2629

        /// <summary>
        ///     The RPLUSER local group could not be found.
        /// </summary>
        public const int NERR_RplNeedsRPLUSERAcct = 0x00000A46; // 2630

        /// <summary>
        ///     Boot block record was not found.
        /// </summary>
        public const int NERR_RplBootNotFound = 0x00000A47; // 2631

        /// <summary>
        ///     Chosen profile is incompatible with this workstation.
        /// </summary>
        public const int NERR_RplIncompatibleProfile = 0x00000A48; // 2632

        /// <summary>
        ///     Chosen network adapter ID is in use by some other workstation.
        /// </summary>
        public const int NERR_RplAdapterNameUnavailable = 0x00000A49; // 2633

        /// <summary>
        ///     There are profiles using this configuration.
        /// </summary>
        public const int NERR_RplConfigNotEmpty = 0x00000A4A; // 2634

        /// <summary>
        ///     There are workstations, profiles, or configurations using this boot block.
        /// </summary>
        public const int NERR_RplBootInUse = 0x00000A4B; // 2635

        /// <summary>
        ///     Service failed to backup Remoteboot database.
        /// </summary>
        public const int NERR_RplBackupDatabase = 0x00000A4C; // 2636

        /// <summary>
        ///     Adapter record was not found.
        /// </summary>
        public const int NERR_RplAdapterNotFound = 0x00000A4D; // 2637

        /// <summary>
        ///     Vendor record was not found.
        /// </summary>
        public const int NERR_RplVendorNotFound = 0x00000A4E; // 2638

        /// <summary>
        ///     Vendor name is in use by some other vendor record.
        /// </summary>
        public const int NERR_RplVendorNameUnavailable = 0x00000A4F; // 2639

        /// <summary>
        ///     (boot name, vendor ID) is in use by some other boot block record.
        /// </summary>
        public const int NERR_RplBootNameUnavailable = 0x00000A50; // 2640

        /// <summary>
        ///     Configuration name is in use by some other configuration.
        /// </summary>
        public const int NERR_RplConfigNameUnavailable = 0x00000A51; // 2641

        /// <summary>
        ///     The internal database maintained by the Dfs service is corrupt.
        /// </summary>
        public const int NERR_DfsInternalCorruption = 0x00000A64; // 2660

        /// <summary>
        ///     One of the records in the internal Dfs database is corrupt.
        /// </summary>
        public const int NERR_DfsVolumeDataCorrupt = 0x00000A65; // 2661

        /// <summary>
        ///     There is no DFS name whose entry path matches the input Entry Path.
        /// </summary>
        public const int NERR_DfsNoSuchVolume = 0x00000A66; // 2662

        /// <summary>
        ///     A root or link with the given name already exists.
        /// </summary>
        public const int NERR_DfsVolumeAlreadyExists = 0x00000A67; // 2663

        /// <summary>
        ///     The server share specified is already shared in the Dfs.
        /// </summary>
        public const int NERR_DfsAlreadyShared = 0x00000A68; // 2664

        /// <summary>
        ///     The indicated server share does not support the indicated DFS namespace.
        /// </summary>
        public const int NERR_DfsNoSuchShare = 0x00000A69; // 2665

        /// <summary>
        ///     The operation is not valid on this portion of the namespace.
        /// </summary>
        public const int NERR_DfsNotALeafVolume = 0x00000A6A; // 2666

        /// <summary>
        ///     The operation is not valid on this portion of the namespace.
        /// </summary>
        public const int NERR_DfsLeafVolume = 0x00000A6B; // 2667

        /// <summary>
        ///     The operation is ambiguous because the link has multiple servers.
        /// </summary>
        public const int NERR_DfsVolumeHasMultipleServers = 0x00000A6C; // 2668

        /// <summary>
        ///     Unable to create a link.
        /// </summary>
        public const int NERR_DfsCantCreateJunctionPoint = 0x00000A6D; // 2669

        /// <summary>
        ///     The server is not Dfs Aware.
        /// </summary>
        public const int NERR_DfsServerNotDfsAware = 0x00000A6E; // 2670

        /// <summary>
        ///     The specified rename target path is invalid.
        /// </summary>
        public const int NERR_DfsBadRenamePath = 0x00000A6F; // 2671

        /// <summary>
        ///     The specified DFS link is offline.
        /// </summary>
        public const int NERR_DfsVolumeIsOffline = 0x00000A70; // 2672

        /// <summary>
        ///     The specified server is not a server for this link.
        /// </summary>
        public const int NERR_DfsNoSuchServer = 0x00000A71; // 2673

        /// <summary>
        ///     A cycle in the Dfs name was detected.
        /// </summary>
        public const int NERR_DfsCyclicalName = 0x00000A72; // 2674

        /// <summary>
        ///     The operation is not supported on a server-based Dfs.
        /// </summary>
        public const int NERR_DfsNotSupportedInServerDfs = 0x00000A73; // 2675

        /// <summary>
        ///     This link is already supported by the specified server-share.
        /// </summary>
        public const int NERR_DfsDuplicateService = 0x00000A74; // 2676

        /// <summary>
        ///     Can't remove the last server-share supporting this root or link.
        /// </summary>
        public const int NERR_DfsCantRemoveLastServerShare = 0x00000A75; // 2677

        /// <summary>
        ///     The operation is not supported for an Inter-DFS link.
        /// </summary>
        public const int NERR_DfsVolumeIsInterDfs = 0x00000A76; // 2678

        /// <summary>
        ///     The internal state of the Dfs Service has become inconsistent.
        /// </summary>
        public const int NERR_DfsInconsistent = 0x00000A77; // 2679

        /// <summary>
        ///     The Dfs Service has been installed on the specified server.
        /// </summary>
        public const int NERR_DfsServerUpgraded = 0x00000A78; // 2680

        /// <summary>
        ///     The Dfs data being reconciled is identical.
        /// </summary>
        public const int NERR_DfsDataIsIdentical = 0x00000A79; // 2681

        /// <summary>
        ///     The DFS root cannot be deleted. Uninstall DFS if required.
        /// </summary>
        public const int NERR_DfsCantRemoveDfsRoot = 0x00000A7A; // 2682

        /// <summary>
        ///     A child or parent directory of the share is already in a Dfs.
        /// </summary>
        public const int NERR_DfsChildOrParentInDfs = 0x00000A7B; // 2683

        /// <summary>
        ///     Dfs internal error.
        /// </summary>
        public const int NERR_DfsInternalError = 0x00000A82; // 2690

        /// <summary>
        ///     This computer is already joined to a domain.
        /// </summary>
        public const int NERR_SetupAlreadyJoined = 0x00000A83; // 2691

        /// <summary>
        ///     This computer is not currently joined to a domain.
        /// </summary>
        public const int NERR_SetupNotJoined = 0x00000A84; // 2692

        /// <summary>
        ///     This computer is a domain controller and cannot be unjoined from a domain.
        /// </summary>
        public const int NERR_SetupDomainController = 0x00000A85; // 2693

        /// <summary>
        ///     The destination domain controller does not support creating machine accounts in OUs.
        /// </summary>
        public const int NERR_DefaultJoinRequired = 0x00000A86; // 2694

        /// <summary>
        ///     The specified workgroup name is invalid.
        /// </summary>
        public const int NERR_InvalidWorkgroupName = 0x00000A87; // 2695

        /// <summary>
        ///     The specified computer name is incompatible with the default language used on the domain controller.
        /// </summary>
        public const int NERR_NameUsesIncompatibleCodePage = 0x00000A88; // 2696

        /// <summary>
        ///     The specified computer account could not be found.
        /// </summary>
        public const int NERR_ComputerAccountNotFound = 0x00000A89; // 2697

        /// <summary>
        ///     This version of Windows cannot be joined to a domain.
        /// </summary>
        public const int NERR_PersonalSku = 0x00000A8A; // 2698

        /// <summary>
        ///     The password must change at the next logon.
        /// </summary>
        public const int NERR_PasswordMustChange = 0x00000A8D; // 2701

        /// <summary>
        ///     The account is locked out.
        /// </summary>
        public const int NERR_AccountLockedOut = 0x00000A8E; // 2702

        /// <summary>
        ///     The password is too long.
        /// </summary>
        public const int NERR_PasswordTooLong = 0x00000A8F; // 2703

        /// <summary>
        ///     The password does not meet the complexity policy.
        /// </summary>
        public const int NERR_PasswordNotComplexEnough = 0x00000A90; // 2704

        /// <summary>
        ///     The password does not meet the requirements of the password filter DLLs.
        /// </summary>
        public const int NERR_PasswordFilterError = 0x00000A91; // 2705

        /// <summary>
        ///     The offline join completion information was not found.
        /// </summary>
        public const int NERR_NoOfflineJoinInfo = 0x00000A95; // 2709

        /// <summary>
        ///     The offline join completion information was bad.
        /// </summary>
        public const int NERR_BadOfflineJoinInfo = 0x00000A96; // 2710

        /// <summary>
        ///     Unable to create offline join information. Please ensure you have access to the specified path location and
        ///     permissions to modify its contents. Running as an elevated administrator may be required.
        /// </summary>
        public const int NERR_CantCreateJoinInfo = 0x00000A97; // 2711

        /// <summary>
        ///     The domain join info being saved was incomplete or bad.
        /// </summary>
        public const int NERR_BadDomainJoinInfo = 0x00000A98; // 2712

        /// <summary>
        ///     Offline join operation successfully completed but a restart is needed.
        /// </summary>
        public const int NERR_JoinPerformedMustRestart = 0x00000A99; // 2713

        /// <summary>
        ///     There was no offline join operation pending.
        /// </summary>
        public const int NERR_NoJoinPending = 0x00000A9A; // 2714

        /// <summary>
        ///     Unable to set one or more requested machine or domain name values on the local computer.
        /// </summary>
        public const int NERR_ValuesNotSet = 0x00000A9B; // 2715

        /// <summary>
        ///     Could not verify the current machine's hostname against the saved value in the join completion information.
        /// </summary>
        public const int NERR_CantVerifyHostname = 0x00000A9C; // 2716

        /// <summary>
        ///     Unable to load the specified offline registry hive. Please ensure you have access to the specified path location
        ///     and permissions to modify its contents. Running as an elevated administrator may be required.
        /// </summary>
        public const int NERR_CantLoadOfflineHive = 0x00000A9D; // 2717

        /// <summary>
        ///     The minimum session security requirements for this operation were not met.
        /// </summary>
        public const int NERR_ConnectionInsecure = 0x00000A9E; // 2718

        /// <summary>
        ///     Computer account provisioning blob version is not supported.
        /// </summary>
        public const int NERR_ProvisioningBlobUnsupported = 0x00000A9F; // 2719
    }
}