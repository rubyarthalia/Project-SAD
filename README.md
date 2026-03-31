# Frosty Bites - Order Management System for MSMEs

**Frosty Bites** is a Micro, Small, and Medium Enterprise (MSME) that serves as the case study and primary user of this system. This application was specifically developed to address its operational needs, including order processing, product management, and business reporting.
## 📂 Project Structure

The repository is divided into two primary solutions:

### 1. Customer Frosty Bites
The client-side application where customers can browse catalogs, place orders, and view their history.
* **Entry Point:** `Login_Page`
* **Key Features:**
    * **Authentication:** Dedicated Login and Signup pages.
    * **Catalog:** Browse available products.
    * **Ordering:** Interactive order placement interface.
    * **History:** Track previous orders.

### 2. Team Frosty Bites
The management-side application used by staff to handle operations and reporting.
* **Entry Point:** `Login_Page`
* **Key Features:**
    * **Team Management:** Add and edit team member details.
    * **Catalog Management:** Update product listings and availability.
    * **Pre-Order Handling:** Manage incoming pre-orders.
    * **Reporting:** Generate detailed reports by Batch, Month, or Year.

## 🛠 Technical Stack

* **Language:** C#
* **Framework:** .NET Framework 4.7.2
* **UI Library:** Windows Forms (System.Windows.Forms)
* **Database Integration:** MySQL (via `MySql.Data.dll`)
* **Security/Utility:** BouncyCastle for cryptography and Google Protobuf

## 🚀 Getting Started

### Prerequisites
* Visual Studio 2019 or newer.
* .NET Framework 4.7.2 SDK.
* MySQL Server (for database connectivity).

### Installation
1.  Clone the repository.
2.  Open the desired solution file:
    * For the Customer app: `Customer Frosty Bites.sln`
    * For the Team app: `Team Frosty Bites.sln`
3.  Restore NuGet packages if prompted.
4.  Update any database connection strings in the `App.config` files if necessary.
5.  Build and Run the project.

## 🖼 Asset Credits
The application utilizes various graphical assets located in the `Pictures` directories of both projects, including custom sidebar icons, QRIS payment images, and branding logos.
