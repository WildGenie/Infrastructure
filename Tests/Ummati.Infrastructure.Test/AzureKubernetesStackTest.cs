namespace Ummati.Infrastructure.Test;

using System.Collections.Immutable;
using Pulumi;
using Pulumi.Utilities;
using Ummati.Infrastructure.Stacks;
using Xunit;

public class AzureKubernetesStackTest
{
    [Fact]
    public async Task AllAzureActiveDirectoryResourcesHaveTagsAsync()
    {
        AzureKubernetesStack.Configuration = new TestConfiguration()
        {
            ApplicationName = "test-app",
            CommonLocation = "northeurope",
            Environment = "test",
            Locations = ImmutableArray.Create("northeurope", "canadacentral"),
        };

        var resources = await Testing.RunAsync<AzureKubernetesStack>().ConfigureAwait(false);

        foreach (var resource in resources)
        {
            var tagsOutput = GetAzureActiveDirectoryTags(resource);
            if (tagsOutput is not null)
            {
                var tags = await OutputUtilities.GetValueAsync(tagsOutput).ConfigureAwait(false);

                Assert.NotNull(tags);
                Assert.Equal($"{TagName.Application}=test-app", tags![0]);
                Assert.Equal($"{TagName.Environment}=test", tags![1]);
                var location = tags![2];
                Assert.True(string.Equals($"{TagName.Location}=northeurope", location, StringComparison.Ordinal) ||
                    string.Equals($"{TagName.Location}=canadacentral", location, StringComparison.Ordinal));
            }
        }
    }

    [Fact]
    public async Task AllAzureResourcesHaveTagsAsync()
    {
        AzureKubernetesStack.Configuration = new TestConfiguration()
        {
            ApplicationName = "test-app",
            CommonLocation = "northeurope",
            Environment = "test",
            Locations = ImmutableArray.Create("northeurope", "canadacentral"),
        };

        var resources = await Testing.RunAsync<AzureKubernetesStack>().ConfigureAwait(false);

        foreach (var resource in resources)
        {
            var tagsOutput = GetAzureTags(resource);
            if (tagsOutput is not null)
            {
                var tags = await OutputUtilities.GetValueAsync(tagsOutput).ConfigureAwait(false);

                Assert.NotNull(tags);
                Assert.Equal("test-app", tags![TagName.Application]);
                Assert.Equal("test", tags![TagName.Environment]);
                var location = tags![TagName.Location];
                Assert.True(string.Equals("northeurope", location, StringComparison.Ordinal) ||
                    string.Equals("canadacentral", location, StringComparison.Ordinal));
            }
        }
    }

    private static Output<ImmutableList<string>?>? GetAzureActiveDirectoryTags(Resource resource)
    {
        var tagsProperty = resource.GetType().GetProperty("Tags");
        if (tagsProperty?.PropertyType == typeof(Output<ImmutableList<string>?>))
        {
            return (Output<ImmutableList<string>?>?)tagsProperty.GetValue(resource);
        }

        return null;
    }

    private static Output<ImmutableDictionary<string, string>?>? GetAzureTags(Resource resource)
    {
        var tagsProperty = resource.GetType().GetProperty("Tags");
        if (tagsProperty?.PropertyType == typeof(Output<ImmutableDictionary<string, string>?>))
        {
            return (Output<ImmutableDictionary<string, string>?>?)tagsProperty.GetValue(resource);
        }

        return null;
    }
}
