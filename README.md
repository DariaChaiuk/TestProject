1 Step.
Open console in project folder and enter command: docker-compose up --build

2 Step.
Open another console in project folder and enter command: sh run.sh

3 Step.
To check api you can use urls:

1) Example of url:
To get user and device registration dynamics endpoint for specific month.
         GET {apiUrl}/api/registration/bymonth/year + date
Example: GET {apiUrl}/api/registration/bymonth/202107
Output: {Year: 2021, month: 7, registeredUsers: 32, registeredDevices: [{type: "laptop", value: "15"}, {type: "mobile phone", value: "8"}, {type: "tablet", value: "9"}]}
Output if data is not available: status code 404.

2) Example of url:
To get number of concurrent logins, total session time for the hour, and cumulative time for the hour.
         GET {apiUrl}/api/sessions/byhour?startTime&endTime

Example: GET {apiUrl}/api/sessions/byhour?startTime=2021-06-30T01:00:00
Output: it will return data available after startTime.

Example: GET {apiUrl}/api/sessions/byhour?endTime=2021-06-30T03:00:00
Output: it will return data available before endTime.

Example: {apiUrl}/api/sessions/byhour?startTime=2021-06-30T01:00:00&endTime=2021-06-30T03:00:00
Output: it will return data available between startTime and endTime.

Output if data is available: [{ date: “2021-06-30”, hour: 1, concurrentSessions: 5, totalTimeForHour: 500, qumulativeForHour: 2400}, { date: “2021-
06-30”, hour: 2, concurrentSessions: 15, totalTimeForHour: 300, qumulativeForHour: 2700}, ...]
Output if data is not available: []

3) Example of url:
To get list of users and devices with concurrent logins extended with the last occurence of the login from unexpected country.

Example: GET {apiUrl}/api/users/anomalies
Output if data is available: [{ userName: “John Doe”, device: “John’s Laptop”, loginTime: “2021-07-01 17:35:18”, unexpectedLogin: { country:
“Switzerland”, loginTime: “2021-07-01 17:35:18”}, { userName: “John Doe”, device: “John’s Mobile phone”, loginTime:
“2021-07-01 17:35:18”, unexpectedLogin: { country: “Switzerland”, loginTime: “2021-07-01 17:35:18”}, { userName:
“Billy Piper”, device: “BPLaptop”, loginTime: “2021-07-02 17:35:18”, unexpectedLogin: null }]
Output if data is not available: []

Api key you can find in appsettings.json . 