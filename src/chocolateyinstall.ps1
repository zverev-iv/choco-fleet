$ErrorActionPreference = 'Stop';

$packageArgs = @{
	packageName    = $env:ChocolateyPackageName
	unzipLocation  = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
	softwareName   = "fleet"
	url64bit       = "https://github.com/rancher/fleet/releases/download/v0.3.3/fleet_0.3.3_windows_amd64.zip";
	checksum64     = "56B0B25630E7E5470D6999775FE66E640BD850F3D8D3FDCE8332C4680562A26A";
	checksumType64 = "sha256";
}

Install-ChocolateyZipPackage @packageArgs
