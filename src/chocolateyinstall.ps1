$ErrorActionPreference = 'Stop';

$packageArgs = @{
	packageName    = $env:ChocolateyPackageName
	unzipLocation  = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
	softwareName   = "fleet"
	url64bit       = "https://github.com/rancher/fleet/releases/download/v0.3.2/fleet_0.3.2_windows_amd64.zip";
	checksum64     = "7183AB2D6BD33D37E186F252ABA446A402747A2FBAA7AB68BC6EF7AD8E05A0E9";
	checksumType64 = "sha256";
}

Install-ChocolateyZipPackage @packageArgs
