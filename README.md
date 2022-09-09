# Medibuddy
A training mini project

# 08/Sep
- Tables
  - Patient
    - PID
    - FirstName
    - MidName
    - LastName
    - Mobile
    - Email
    - Address
    - Gender
    - DOB


  - Department
    - DepID
    - DepName


  - Doctor
    - ID
    - Name
    - Type
    - Mobile
    - Email
    - Gender
    - Fees
    - Salary

  - Nurse
    - ID
    - Name
    - Mobile
    - Email
    - Gender
    - Salary

  - OPDBilling
    - ID
    - PID
    - DocID
    - Medicine
    - Test

  - IPDBilling

  - Test

  - Ward
    - ID
    - DepID
    - RoomSpecialCapacity
    - RoomSharedCapacity
    - RoomGeneralCapacity
  
  - Room(type,rate,capacity)
    - ID
    - WardID
    - Type
    - Rate
    - CurrentBedCapacity
    - MaxBedCapacity

  - OPDPatient
    - ID
    - PID
    - DocID
    - VisitDate
    - OPDBillingID

  - IPDPatient
  
  - Medicines
    - ID
    - Name
    - Price

  - Canteen
    - MealID
    - Price
