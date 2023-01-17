﻿# Entities
The entities has been implemented with encapsulation in mind. This means that there has been given consideration into if a property has a public setter or not. Also inside the constructor there are guard clauses that prevents an illegal instance of the object to be created.

In this implementation I have decided not to have referenced classes (e.g. a list of contacts on the company) this is done to show encapsulation and some of the elements you need to be aware of. The considerations for not having a `public` list of contacts on a company is that I cannot control when contacts are added or removed. This means that there is really no encapsulation of this property. This is the case in an anemic class, if this was a rich class the list of contacts would be private and there should be exposed methods such as `AddContact(Contact contact)` and similar methods to manage the access to the list of contacts.