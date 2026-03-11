# Get Harvest API V2 Client 

This library allows connecting to the Harvest Timetracking API v2 and requesting and modifying all entities from there.
https://www.getharvest.com/

Instead of other library it is using the new version 2 OAuth based API.

## Getting Started

At the begining you need to generate your Personal Access token. The easiest way is by following the manual of Harvest https://help.getharvest.com/api-v2/authentication-api/authentication/authentication/#personal-access-tokens or directly navigating to https://id.getharvest.com/developers.

The API client is available as a nuget package and can easily be installed from there.

Creating the client by specifying the secrets you received in the step before:
```
HarvestClient c = new HarvestClient("%AccountId%", "%PersonalAccessToken%");

           
            
```

### Retrieving Objects

Retrieve a list or a single item:
```
ResultEstimates e = c.Estimates.List();
ResultTasks t = c.Tasks.List();
ResultTimeEntries te = c.TimeEntries.List();
ResultClients cl = c.Clients.List();

Client ExistingClient = c.Clients.Get(12143655);

```

Adding a new item:
```
Client newClient = new Client() { Name = "TestKUR", Address = "TestStrasse" };
Client newCreatedClient = c.Clients.Add(newClient);
```

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Release Notes

### 2.1.3
- Features:
  - None
- Bug fixes:
  - Update libraries: RestSharp, Json.Net

### 2.1.2
- Features:
  - Add retry handling and event listener
- Bug fixes:
  - None

### 2.1.1
- Features:
  - None
- Bug fixes:
  - Update libraries

### 2.1.0
- Features:
  - Update to .NET 8 and new libraries
- Bug fixes:
  - None

### 2.0.1
- Features:
  - None
- Bug fixes:
  - Stable release with new libraries

### 2.0.0-alpha
- Features:
  - Support RestSharp 107 and Newtonsoft 13
- Bug fixes:
  - None

### 1.0.1
- Features:
  - Make `ShouldSerialize` methods virtual to allow override
- Bug fixes:
  - None

### 1.0.0
- Features:
  - First release
- Bug fixes:
  - None

## Authors

* **Thomas Kurth** - *Initial work* 

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

