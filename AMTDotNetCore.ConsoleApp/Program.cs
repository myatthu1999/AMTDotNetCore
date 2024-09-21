// See https://aka.ms/new-console-template for more information
using AMTDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
DapperExample dapperExample = new DapperExample();
EFCoreExample eFCoreExample = new EFCoreExample();

//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Edit();
//adoDotNetExample.Update();
//adoDotNetExample.Delete();
//dapperExample.Read();
//dapperExample.Create("uiux","phoe","intern");
//dapperExample.Edit(12);
//dapperExample.Edit(13);
//dapperExample.Update(15,"ai","instructor","introduction");
//dapperExample.Delete(2);

eFCoreExample.Read();
//eFCoreExample.Create("furniture", "phyo", "is used for");
//eFCoreExample.Edit(17);
//eFCoreExample.Update(17,"skincare","phyu","is good");
//eFCoreExample.Delete(17);
Console.ReadKey();

