namespace Ummati.Infrastructure;

using System.Collections.Generic;
using Pulumi.AzureNative.ContainerService;

public interface IConfiguration
{
    /// <summary>
    /// Gets the application name.
    /// </summary>
    string ApplicationName { get; }

    /// <summary>
    /// Gets the environment name e.g. development, production.
    /// </summary>
    string Environment { get; }

    /// <summary>
    /// Gets the location where common resources can be placed.
    /// </summary>
    string CommonLocation { get; }

    /// <summary>
    /// Gets one or more locations where resources can be duplicated.
    /// </summary>
    IEnumerable<string> Locations { get; }

    /// <summary>
    /// Gets the days that maintenance is allowed on the cluster.
    /// </summary>
    IEnumerable<WeekDay> KubernetesMaintenanceDays { get; }

    /// <summary>
    /// Gets the hours of the day that maintenance is allowed on the cluster.
    /// </summary>
    IEnumerable<int> KubernetesMaintenanceHourSlots { get; }

    /// <summary>
    /// Gets the tier of the cluster SKU. The Paid tier results in higher availability.
    /// </summary>
    ManagedClusterSKUTier KubernetesSKUTier { get; }

    /// <summary>
    /// Gets the upgrade channel used to upgrade the cluster automatically.
    /// </summary>
    UpgradeChannel KubernetesUpgradeChannel { get; }

    IEnumerable<string> KubernetesSystemNodesAvailabilityZones { get; }

    /// <summary>
    /// Gets the maximum number of pods allowed on a node. Minimum is one and maximum is 250.
    /// </summary>
    int KubernetesSystemNodesMaximumPods { get; }

    /// <summary>
    /// Gets the maximum number of nodes allowed in the cluster. Maximum is 100.
    /// </summary>
    int KubernetesSystemNodesMaximumNodeCount { get; }

    /// <summary>
    /// Gets the maximum number of nodes to update at any one time. This can be a number e.g. 10 or a
    /// percentage e.g. 10%. 33% is recommended and you need enough IP addresses available on your subnet to support
    /// the extra nodes during the upgrade.
    /// </summary>
    string KubernetesSystemNodesMaximumSurge { get; }

    /// <summary>
    /// Gets the minimum number of nodes in the cluster. Minimum is zero. A minimum of three is recommended
    /// in production.
    /// </summary>
    int KubernetesSystemNodesMinimumNodeCount { get; }

    /// <summary>
    /// Gets the size of the disk used by the nodes operating system.
    /// </summary>
    int KubernetesSystemNodesOsDiskSizeGB { get; }

    /// <summary>
    /// Gets the type of the disk used by the nodes. Ephemeral is cheaper and faster but requires a VM size which
    /// supports 32GB of temporary storage.
    /// </summary>
    OSDiskType KubernetesSystemNodesOSDiskType { get; }

    /// <summary>
    /// Gets the policy used to scale down the number of nodes.
    /// Delete (Default) - Stops nodes when scaling down. This is faster to scale up.
    /// Deallocate - Stops and deletes nodes when scaling down. This is cheaper.
    /// </summary>
    ScaleSetEvictionPolicy KubernetesSystemNodesScaleSetEvictionPolicy { get; }

    /// <summary>
    /// Gets the virtual machine size. DS3_v2 is the minimum recommended and DS4_v2 is recommended in production.
    /// </summary>
    string KubernetesSystemNodesVmSize { get; }

    IEnumerable<string> KubernetesUserNodesAvailabilityZones { get; }

    /// <summary>
    /// Gets the maximum number of pods allowed on a node. Minimum is one and maximum is 250.
    /// </summary>
    int KubernetesUserNodesMaximumPods { get; }

    /// <summary>
    /// Gets the maximum number of nodes allowed in the cluster. Maximum is 100.
    /// </summary>
    int KubernetesUserNodesMaximumNodeCount { get; }

    /// <summary>
    /// Gets the maximum number of nodes to update at any one time. This can be a number e.g. 10 or a
    /// percentage e.g. 10%. 33% is recommended and you need enough IP addresses available on your subnet to support
    /// the extra nodes during the upgrade.
    /// </summary>
    string KubernetesUserNodesMaximumSurge { get; }

    /// <summary>
    /// Gets the minimum number of nodes in the cluster. Minimum is zero. A minimum of three is recommended
    /// in production.
    /// </summary>
    int KubernetesUserNodesMinimumNodeCount { get; }

    /// <summary>
    /// Gets the size of the disk used by the nodes operating system.
    /// </summary>
    int KubernetesUserNodesOsDiskSizeGB { get; }

    /// <summary>
    /// Gets the type of the disk used by the nodes. Ephemeral is cheaper and faster but requires a VM size which
    /// supports 32GB of temporary storage.
    /// </summary>
    OSDiskType KubernetesUserNodesOSDiskType { get; }

    /// <summary>
    /// Gets the policy used to scale down the number of nodes.
    /// Delete (Default) - Stops nodes when scaling down. This is faster to scale up.
    /// Deallocate - Stops and deletes nodes when scaling down. This is cheaper.
    /// </summary>
    ScaleSetEvictionPolicy KubernetesUserNodesScaleSetEvictionPolicy { get; }

    /// <summary>
    /// Gets the virtual machine size. DS3_v2 is the minimum recommended and DS4_v2 is recommended in production.
    /// </summary>
    string KubernetesUserNodesVmSize { get; }

    string ContainerImageName { get; }

    double ContainerCpu { get; }

    string ContainerMemory { get; }

    int ContainerMaxReplicas { get; }

    int ContainerMinReplicas { get; }

    int ContainerConcurrentRequests { get; }
}
