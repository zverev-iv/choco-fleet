var target = Argument("target", "Publish");

var packageInfo = new ChocolateyPackSettings {
    //PACKAGE SPECIFIC SECTION
    Id                       = "fleet",
    Version                  = "0.3.2",
    PackageSourceUrl         = new Uri("https://github.com/zverev-iv/choco-fleet"),
    Owners                   = new[] {"zverev-iv"},
    //SOFTWARE SPECIFIC SECTION
    Title                    = "fleet",
    Authors                  = new[] {
        "Rancher Labs"
        },
    Copyright                = "2021 Rancher Labs",
    ProjectUrl               = new Uri("https://fleet.rancher.io/"),
    ProjectSourceUrl         = new Uri("https://github.com/rancher/fleet/"),
    DocsUrl                  = new Uri("https://github.com/rancher/fleet/blob/master/README.md"),
    BugTrackerUrl            = new Uri("https://github.com/rancher/fleet/issues"),
    IconUrl                  = new Uri("https://cdn.statically.io/gh/zverev-iv/choco-fleet/master/fleet/logo.png"),
    LicenseUrl               = new Uri("https://raw.githubusercontent.com/orf/gping/master/LICENSE"),
    RequireLicenseAcceptance = false,
    Summary                  = "Fleet is GitOps at scale",
    Description              = @"Fleet is GitOps at scale. Fleet is designed to manage up to a million clusters. It's also lightweight enough that is works great for a single cluster too, but it really shines when you get to a large scale. By large scale we mean either a lot of clusters, a lot of deployments, or a lot of teams in a single organization.

Fleet can manage deployments from git of raw Kubernetes YAML, Helm charts, or Kustomize or any combination of the three. Regardless of the source all resources are dynamically turned into Helm charts and Helm is used as the engine to deploy everything in the cluster. This give a high degree of control, consistency, and auditability. Fleet focuses not only on the ability to scale, but to give one a high degree of control and visibility to exactly what is installed on the cluster.",
    ReleaseNotes             = new [] {"https://github.com/rancher/fleet/releases"},
    Files                    = new [] {
        new ChocolateyNuSpecContent {Source = System.IO.Path.Combine("src", "**"), Target = "tools"}
        },
    Tags                     = new [] {
        "fleet", 
        "rancher",
        "kubernetes",
        "docker",
        "container",
        "containerd",
        "git",
        "gitops",
        "cluster",
        "helm"
        }
    };

Task("Clean")
    .Does(() =>
{
    DeleteFiles("./**/*.nupkg");
	DeleteFiles("./**/*.nuspec");
});

Task("Pack")
    .IsDependentOn("Clean")
    .Does(() =>
{
    ChocolateyPack(packageInfo);
});

Task("Publish")
    .IsDependentOn("Pack")
    .Does(() =>
{
	var publishKey = EnvironmentVariable<string>("CHOCOAPIKEY", null);
    var package = $"{packageInfo.Id}.{packageInfo.Version}.nupkg";

    ChocolateyPush(package, new ChocolateyPushSettings {
        ApiKey = publishKey
    });
});

RunTarget(target);
