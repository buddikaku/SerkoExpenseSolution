1. Change following configuration settings in web.config in SerkoExpense.Api as required

	1.1 GST percentage under appSettings
		<appSettings>
			<add key="GST" value="0.15" />
		</appSettings>

	1.2 Log file creation path under log4net
		<log4net>
			<!-- The file location can be anywhere as long as the running application has read/write/delete access.-->
			<file type="log" value="E:\Assignments\Logs\Logger.log" />
		</log4net>

	1.3 CORS settings under customHeaders
		<httpProtocol>
			<customHeaders>
				<!--Allowed all origins,headers and methods.Can restrict if required-->
				<add name="Access-Control-Allow-Origin" value="*" />
				<add name="Access-Control-Allow-Headers" value="*" />
				<add name="Access-Control-Allow-Methods" value="*" />
			</customHeaders>
		</httpProtocol>

2.Serko Expense API.pdf contains documentation about implementation