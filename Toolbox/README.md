# C# Toolbox Interface for Windows

*The Toolbox Interface is for an easy to use elmProject. At the*
*moment we are under development so there may be some bugs. For*
*any information please do not hesitate to contact us.*

* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! *
* !! The SSH Class is based on the Renci.SSH.NET	!! *
* !! Library. https://github.com/sshnet/SSH.NET		!! *
*	!! Have a look for more Informatione						!! *
* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! *

* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! *
* !! Images and ICONs in the Project are mostly		!! *
* !! used from Microsoft. Please have a look to		!! *
*	!! The EULA of Microsoft for mor Information		!! *
* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! *

# Toolbox Libraries
	1. SSH
		1. Functions
			* SSH()
			* SSH(string ipadress, string port, string username, string password = null)
			* SSH(string ipadress, string port, string username, string certificate, string passphrase)
			* SSH(ConnectionInfo connection)
			* SSHconnect()
			* SFTPconnect()
			* SSHexec(string command)
			* SFTPupload(string filename, string uploaddir)
			* SSHdisconnect()
			* SFTPdisconnect()
		1. Properties
			* CheckSSHConnnection(r)
			* CheckSFTPConnnection(r)
			* IPaddress(r)
			* Port(r)
			* Username(r)
			* Certificate(r)
			* GetBashTool(r)
			* GetBashToolVersion(r)
			* GetSSHClassVersion(r)

		1. Network()
			1.Functions
				* checkip(string ipaddress)
				* pinghost(string hostname, int timeout)
				* pingip(string ipaddress, int timeout)
				*	pingip(byte[] ipaddress, int timeout)
			1. Properties
				GetIP(r)

*Please read the copyright*

*sunriax@elmProject*
----------------------------------------------------------------------