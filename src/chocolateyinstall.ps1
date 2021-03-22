$ErrorActionPreference = 'Stop';

$packageArgs = @{
	packageName    = $env:ChocolateyPackageName
	unzipLocation  = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
	softwareName   = "fleet"
	url64bit       = "https://github.com/rancher/fleet/releases/download/v0.3.4/fleet_0.3.4_windows_amd64.zip";
	checksum64     = "F6A7D20600315A57C5816F8C404C135862397FA7927B22B9FCDA4C010E9D5599";
	checksumType64 = "sha256";
}

Install-ChocolateyZipPackage @packageArgs
