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

set /a "random_operation= %random% %% 8 + 1"

set /a "random_quantity1= %random% %% 19 + 1"
set /a "random_quantity2= %random% %% 19 + 1"
set /a "random_quantity3= %random% %% 19 + 1"
set /a "random_quantity4= %random% %% 19 + 1"
set /a "random_quantity5= %random% %% 19 + 1"
set /a "random_quantity6= %random% %% 19 + 1"
set /a "random_quantity7= %random% %% 19 + 1"
set /a "random_quantity8= %random% %% 19 + 1"
set /a "random_quantity9= %random% %% 19 + 1"
set /a "random_quantity10= %random% %% 19 + 1"
set /a "random_quantity11= %random% %% 19 + 1"
set /a "random_quantity12= %random% %% 19 + 1"
set /a "random_quantity13= %random% %% 19 + 1"
set /a "random_quantity14= %random% %% 19 + 1"
set /a "random_quantity15= %random% %% 19 + 1"
set /a "random_quantity16= %random% %% 19 + 1"
set /a "random_quantity17= %random% %% 19 + 1"
set /a "random_quantity18= %random% %% 19 + 1"
set /a "random_quantity19= %random% %% 19 + 1"
set /a "random_quantity20= %random% %% 19 + 1"
set /a "random_quantity21= %random% %% 19 + 1"
set /a "random_quantity22= %random% %% 19 + 1"
set /a "random_quantity23= %random% %% 19 + 1"
set /a "random_quantity24= %random% %% 19 + 1"



curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 1,\"SizeId\": 1,\"OperationId\": 2,\"Quantity\":!random_quantity1!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 2,\"SizeId\": 2,\"OperationId\": 2,\"Quantity\":!random_quantity2!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 3,\"SizeId\": 3,\"OperationId\": 2,\"Quantity\":!random_quantity3!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 4,\"SizeId\": 4,\"OperationId\": 2,\"Quantity\":!random_quantity4!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 5,\"SizeId\": 5,\"OperationId\": 2,\"Quantity\":!random_quantity5!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 6,\"SizeId\": 6,\"OperationId\": 2,\"Quantity\":!random_quantity6!,\"CreateDate\":\"!random_date!\"}"

curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 7,\"SizeId\": 1,\"OperationId\": 3,\"Quantity\":!random_quantity7!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 8,\"SizeId\": 2,\"OperationId\": 3,\"Quantity\":!random_quantity8!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 9,\"SizeId\": 3,\"OperationId\": 3,\"Quantity\":!random_quantity9!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 10,\"SizeId\": 4,\"OperationId\": 3,\"Quantity\":!random_quantity10!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 11,\"SizeId\": 5,\"OperationId\": 3,\"Quantity\":!random_quantity11!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 12,\"SizeId\": 6,\"OperationId\": 3,\"Quantity\":!random_quantity12!,\"CreateDate\":\"!random_date!\"}"

curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 13,\"SizeId\": 1,\"OperationId\": 5,\"Quantity\":!random_quantity13!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 14,\"SizeId\": 2,\"OperationId\": 5,\"Quantity\":!random_quantity14!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 15,\"SizeId\": 3,\"OperationId\": 5,\"Quantity\":!random_quantity15!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 16,\"SizeId\": 4,\"OperationId\": 5,\"Quantity\":!random_quantity16!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 17,\"SizeId\": 5,\"OperationId\": 5,\"Quantity\":!random_quantity17!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 18,\"SizeId\": 6,\"OperationId\": 5,\"Quantity\":!random_quantity18!,\"CreateDate\":\"!random_date!\"}"

curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 19,\"SizeId\": 1,\"OperationId\": 6,\"Quantity\":!random_quantity19!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 20,\"SizeId\": 2,\"OperationId\": 6,\"Quantity\":!random_quantity20!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 21,\"SizeId\": 3,\"OperationId\": 6,\"Quantity\":!random_quantity21!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 22,\"SizeId\": 4,\"OperationId\": 6,\"Quantity\":!random_quantity22!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 23,\"SizeId\": 5,\"OperationId\": 6,\"Quantity\":!random_quantity23!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 24,\"SizeId\": 6,\"OperationId\": 6,\"Quantity\":!random_quantity24!,\"CreateDate\":\"!random_date!\"}"

curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 19,\"SizeId\": 1,\"OperationId\": 14,\"Quantity\":!random_quantity19!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 20,\"SizeId\": 2,\"OperationId\": 14,\"Quantity\":!random_quantity20!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 21,\"SizeId\": 3,\"OperationId\": 14,\"Quantity\":!random_quantity21!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 22,\"SizeId\": 4,\"OperationId\": 14,\"Quantity\":!random_quantity22!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 23,\"SizeId\": 5,\"OperationId\": 14,\"Quantity\":!random_quantity23!,\"CreateDate\":\"!random_date!\"}"
curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonId\": 24,\"SizeId\": 6,\"OperationId\": 14,\"Quantity\":!random_quantity24!,\"CreateDate\":\"!random_date!\"}"

timeout /t 5 >nul
goto loop
