// See https://aka.ms/new-console-template for more information
using AMTDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
DapperExample dapperExample = new DapperExample();

adoDotNetExample.Read();
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
Console.ReadKey();

