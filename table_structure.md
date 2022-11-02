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
    

  - OPDTest
    - OPDBillingID
    - TestID

  - OPDMedicine
    - OPDBillingID
    - MedicineID

  - IPDBilling
    - ID
    - PID
    - DocID

  - IPDTest
    - IPDBillingID
    - TestID

  - IPDMedicine
    - IPDBillingID
    - MedicineID

  - Test
    - ID
    - Name
    - Price

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
    - ID
    - PID
    - DocID
    - EntryDate
    - ExitDate
    - IPDBillingID

  - Medicines
    - ID
    - Name
    - Price

  - Canteen
    - MealID
    - Price
