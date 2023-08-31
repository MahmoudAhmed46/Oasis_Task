# Oasis Task Comany
## Technology
using .NET 7.0 Core API, Entity FrameWork Core, JWT Authentication & Authorization and Identity.
## Feature
- Register & Login End Point and Create Refresh Token.
- Make CRUD Operation on ToDo Entity .
- Consume the Todos API from [jsonPlaceholder](https://jsonplaceholder.typicode.com/todos)
## Setup
- First of all in appsettings.json file change connection string with your connection string.
- second run this command in package console manager
  Migration command and update database
  ```
  add-migration anyName
  update-database
  ```
-  ### before to call endpoint in LiveToDo Controller please uncomment from line 30 to line 32 before call endpoint first time only to store fetched data in your database then comment this line again (this optinal step to store data).
<div>
  <p>This screen for Register</p>
    <img src="https://github.com/MahmoudAhmed46/Oasis_Task/assets/46374430/5f15b791-15f3-4b37-babc-8025f91f3eed" width="150">
  <p>This screen for login</p>
    <img src="https://github.com/MahmoudAhmed46/Oasis_Task/assets/46374430/8a59cedc-af88-4483-af72-b7ee5573c15d" width="150">
  <p>This screen for Fetsh data from consume API Todo</p>
    <img src="https://github.com/MahmoudAhmed46/Oasis_Task/assets/46374430/3be16f53-a59e-4442-b2cc-ff41b21d33a8" width="150">
  <p>This screen for test pagination</p>
    <img src="https://github.com/MahmoudAhmed46/Oasis_Task/assets/46374430/54b0a934-b1e5-4c13-b6ce-473ea32e0206" width="150">
  <p>This screen for test Create Todo End Point</p>
    <img src="https://github.com/MahmoudAhmed46/Oasis_Task/assets/46374430/e770f816-9c8c-4cbf-a877-ef3fa4dcb595" width="150">
  <p>This screen for test Update Todo End Point</p>
    <img src="https://github.com/MahmoudAhmed46/Oasis_Task/assets/46374430/48ade6b2-4682-4d68-88e6-77319adcd7e5" width="150">
  <p>This screen for test Get Todo By Id End Point</p>
    <img src="https://github.com/MahmoudAhmed46/Oasis_Task/assets/46374430/d61b79bd-7aa2-455d-bf61-2decf72e8c84" width="150">
  <p>This screen for test Delete Todo End Point</p>
    <img src="https://github.com/MahmoudAhmed46/Oasis_Task/assets/46374430/ef25050d-e030-44d4-a1ae-c07994c89b6f" width="150">
</div>
