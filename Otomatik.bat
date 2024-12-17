@echo off
setlocal enabledelayedexpansion

:loop
set /a "random_days= %random% %% 22 + 23"
set /a "random_hours= %random% %% 24"
set /a "random_minutes= %random% %% 60"
set /a "random_seconds= %random% %% 60"

for /f "tokens=1-4 delims=/ " %%a in ('powershell -command "[datetime]::Now.AddDays(!random_days!).AddHours(!random_hours!).AddMinutes(!random_minutes!).AddSeconds(!random_seconds!).ToString('yyyy-MM-ddTHH:mm:ss.fffzzz')"') do (
    set random_date=%%a
)

set /a "random_size= %random% %% 6 + 1"

set /a "random_personel= %random% %% 21 + 1"

set /a "random_operation= %random% %% 19 + 1"

set /a "random_quantity= %random% %% 19 + 1"


curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonelId\": !random_personel!,\"SizeId\": !random_size!,\"OperationId\": !random_operation!,\"Quantity\":!random_quantity!,\"CreateDate\":\"!random_date!\"}"

timeout /t 2 >nul
goto loop
