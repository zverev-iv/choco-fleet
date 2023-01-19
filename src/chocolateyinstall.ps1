$ErrorActionPreference = 'Stop';

$packageArgs = @{
	packageName    = $env:ChocolateyPackageName
	unzipLocation  = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
	softwareName  = "${softwareName}"
	url64bit      = "${url64bit}"
	checksum64    = "${checksum64}"
  	checksumType64= "${checksumType64}"
}

Install-ChocolateyZipPackage @packageArgs
