﻿using System;
using System.IO;
using Xunit;

namespace MarkdownToKeywords.Test
{
    public class BasicTest
    {
        [Fact]
        public void TestMarkdown01()
        {
            // copied from https://raw.githubusercontent.com/dotnet/docs/master/docs/csharp/tutorials/microservices.md
            var testMarkdownFile = "testdata/microservices.md";
            var content = File.ReadAllText(testMarkdownFile);
            var result = Program.Transform(testMarkdownFile, "testdata");
            var expected = @"microservices hosted docker introduction tutorial details tasks necessary build deploy asp.net core microservice docker container course tutorial you&#39;ll learn : generate asp.net core application using yeoman create development docker environment build docker image based existing image deploy service docker container along way you&#39;ll also see c# language features : convert c# objects json payloads build immutable data transfer objects process incoming http requests generate http response work nullable value types  view download sample app https://github.com/dotnet/docs/tree/master/samples/csharp/getting-started/WeatherMicroservice topic download instructions see samples tutorials ../../samples-and-tutorials/index.md%23viewing-and-downloading-samples  docker? docker makes easy create standard machine images host services data center public cloud docker enables configure image replicate needed scale installation application code tutorial work net core environment additional tasks docker installation work asp.net core application prerequisites you’ll need setup machine run net core find installation instructions net core https://www.microsoft.com/net/core page run application windows ubuntu linux macos docker container you’ll need install favorite code editor descriptions use visual studio code https://code.visualstudio.com/ open source cross platform editor however use whatever tools comfortable you&#39;ll also need install docker engine see docker installation page http://www.docker.com/products/docker instructions platform docker installed many linux distributions macos windows page referenced contains sections available installations components installed done package manager node.js&#39;s package manager installed skip step otherwise install latest nodejs nodejs.org https://nodejs.org install npm package manager point need install number command line tools support asp.net core development command line templates use yeoman bower grunt gulp installed good otherwise type following favorite shell :  option indicates global install tools available system wide local install scopes package single project you&#39;ve installed core tools need install yeoman asp.net template generators : create application you&#39;ve installed tools create new asp.net core application use command line generator execute following yeoman command favorite shell : command prompts select type application want create microservice want simplest lightweight web application possible select &#39;empty web application&#39 template prompt name select &#39;weathermicroservice&#39 template creates eight files : gitignore customized asp.net core applications startup.cs file contains basis application program.cs file contains entry point application weathermicroservice.csproj file build file application dockerfile script creates docker image application readme.md contains links asp.net core resources web.config file contains basic configuration information runtimeconfig.template.json file contains debugging settings used ides run template generated application that&#39;s done using series tools command line command runs tools necessary net development verb executes different command first step restore dependencies : dotnet restore uses nuget package manager install necessary packages application directory also generates project.json.lock file file contains information package referenced restoring dependencies build application : build application run command line : default configuration listens http://localhost:5000 open browser navigate page see &quot;hello world !&quot message anatomy asp.net core application you&#39;ve built application let&#39;s look functionality implemented two generated files particularly interesting point : project.json startup.cs project.json contains information project two nodes you&#39;ll often work &#39;dependencies&#39 &#39;frameworks&#39 dependencies node lists packages needed application moment small node needing packages run web server &#39;frameworks&#39 node specifies versions configurations net framework run application application implemented startup.cs file contains startup class two methods called asp.net core infrastructure configure run application method describes services necessary application you&#39;re building lean microservice doesn&#39;t need configure dependencies method configures handlers incoming http requests template generates simple handler responds request text &#39;hello world !&#39 build microservice service you&#39;re going build deliver weather reports anywhere around globe production application you&#39;d call service retrieve weather data sample we&#39;ll generate random weather forecast number tasks you&#39;ll need perform order implement random weather service : parse incoming request read latitude longitude generate random forecast data convert random forecast data c# objects json packets set response header indicate service sends back json write response next sections walk steps parsing query string you&#39;ll begin parsing query string service accept &#39;lat&#39 &#39;long&#39 arguments query string form :  changes need make lambda expression defined argument startup class argument lambda expression request one properties object object property contains dictionary values query string request first addition find latitude longitude values : ../../../samples/csharp/getting-started/WeatherMicroservice/Startup.cs query dictionary values type type contain collection strings weather service value single string that&#39;s there&#39;s call code next need convert strings doubles method you&#39;ll use convert string double : method leverages c# parameters indicate input string converted double string represent valid representation double method returns true argument contains value string represent valid double method returns false adapt api use extension method returns nullable double  nullable value type type represents value type also hold missing null value nullable type represented appending character type declaration extension methods methods defined static methods adding modifier first parameter called though members class extension methods may defined static classes here&#39;s definition class containing extension method parse : ../../../samples/csharp/getting-started/WeatherMicroservice/Extensions.cs  expression returns default value type default value null missing value use extension method convert query string arguments double type : ../../../samples/csharp/getting-started/WeatherMicroservice/Startup.cs easily test parsing code update response include values arguments : ../../../samples/csharp/getting-started/WeatherMicroservice/Startup.cs point run web application see parsing code working add values web request browser see updated results build random weather forecast next task build random weather forecast let&#39;s start data container holds values you&#39;d want weather forecast : next build constructor randomly sets values constructor uses values latitude longitude seed random number generator means forecast location change arguments latitude longitude you&#39;ll get different forecast start different seed ../../../samples/csharp/getting-started/WeatherMicroservice/WeatherReport.cs generate 5-day forecast response method : ../../../samples/csharp/getting-started/WeatherMicroservice/Startup.cs build json response final code task server convert weatherreport array json packet send back client let&#39;s start creating json packet you&#39;ll add newtonsoft json serializer list dependencies using cli : use class write object string : ../../../samples/csharp/getting-started/WeatherMicroservice/Startup.cs code converts forecast object list objects json packet you&#39;ve constructed response packet set content type write string application runs returns random forecasts build docker image final task run application docker we&#39;ll create docker container runs docker image represents application  docker image file defines environment running application  docker container represents running instance docker image analogy think docker image  class  docker container object instance class dockerfile created asp.net template serve purposes let&#39;s go contents first line specifies source image : docker allows configure machine image based source template means don&#39;t supply machine parameters start need supply changes changes include application first sample we&#39;ll use version dotnet image easiest way create working docker environment image include dotnet core runtime dotnet sdk makes easier get started build create larger image next five lines setup build application : copy project file current directory docker vm restore packages using dotnet cli means docker image must include net core sdk rest application gets copied dotnet publish command builds packages application final line file runs application : configured port referenced argument last line dockerfile command informs docker command command line options start service building running image container let&#39;s build image run service inside docker container don&#39;t want files local directory copied image instead you&#39;ll build application container you&#39;ll create file specify directories copied image don&#39;t want build assets copied specify build publish directories file : build image using docker build command run following command directory containing code command builds container image based information dockerfile argument provides tag name container image command line tag used docker container command completes container ready run new service run following command start container launch service :  option means run container detached current terminal means won&#39;t see command output terminal option indicates port mapping service host says incoming request port 80 forwarded port 5000 container using 5000 matches port service listening command line arguments specified dockerfile argument names running container it&#39;s convenient name use work container see image running checking command : container running you&#39;ll see line lists running processes may one test service opening browser navigating localhost specifying latitude longitude : attaching running container ran sevice command window could see diagnostic information printed request don&#39;t see information container running detached mode docker attach command enables attach running container see log information run command command window :  argument means commands get sent container process rather stop command final argument name given container command also use docker assigned container id refer container didn&#39;t specify name container must use container id open browser navigate service you&#39;ll see diagnostic messages command windows attached running container press stop attach process done working container stop : container image still available restart want remove container machine use command : want remove unused images machine use command : conclusion tutorial built asp.net core microservice added simple features built docker container image service ran container machine attached terminal window service saw diagnostic messages service along way saw several features c# language action ";

            Assert.Equal(expected, result);
        }
    }
}