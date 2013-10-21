# Initial Changes

by Michael Sync

1. Changed `unirest-net` to `Class Library (Windows Store Apps)`
2. Changed `unirest-net-` to `Unit Test Library (Windows Store Apps)`
3. Added `Microsoft.Net.Http` nuget package that was relased with Portable Library for RT and Phone. 
4. Added `Newtonsoft.Json` nuget package because System.Web.Script.Serialization is not available in Windows RT
5. The original test project was using `nunit` unit test framework because `Nunit Adapter VS` extension (beta 5) doesn't work with `Win RT` for _some_ reason. So, I changed it to `VS` unit test framework and removed the `Nunit` nuget package. 
6. The original code is using the capital `P` (e.g. Unitest.Post(..)..) so I made it lowercase. 
