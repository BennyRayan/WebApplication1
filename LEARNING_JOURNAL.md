# Event Sourcing Learning Journey - Session 1

## 📅 Date: September 17, 2025

## 🎯 Session Overview
Today we began the event sourcing learning journey outlined in `Plan.md`, focusing on Phase 1: C# Basics & Simple Entities. Successfully completed the first 4 tasks and established the foundation for our domain model.

## ✅ Tasks Completed

### **Task 1: Create Your First Entity** ✅
**File:** `Therapist.cs`
- ✅ Created entity with `Id`, `Name`, `LicenseNumber`
- ✅ Constructor validation: Name not empty, LicenseNumber exactly 8 digits
- ✅ Property encapsulation: `public get; private set;`
- ✅ Auto-generated GUID for identity

**Key Learning:**
- Domain entities need identity and validation
- Property encapsulation prevents external state mutations
- Constructor is the gatekeeper for valid entity creation

**Debugging Process:** Learned about common mistakes:
- ID assignment logic errors (initializing vs constructor parameter)
- Property visibility patterns (private vs public accessors)
- Validation order (null checks before length checks)

### **Task 2: Value Objects** ✅
**File:** `TimeSlot.cs`
- ✅ Created record with `StartTime`, `EndTime`
- ✅ Immutable properties with `init` accessors
- ✅ Validation: EndTime must be after StartTime
- ✅ Business method: `GetDuration()` returns minutes

**Key Learning:**
- **Records vs Classes:** Records for value objects (immutable, value equality)
- **Entities vs Value Objects:** TimeSlot has no identity - defined by its values
- **DateTime arithmetic:** `EndTime - StartTime` returns `TimeSpan`
- Records can have methods, constructors, and validation like classes

### **Task 3: Entity with Business Logic** ✅
**File:** `Patient.cs`
- ✅ Created entity with `Id`, `Name`, `DateOfBirth`
- ✅ Business methods: `GetAge()`, `IsMinor()`
- ✅ Complex age calculation handling birthdays correctly

**Key Learning:**
- **Age Calculation Logic:** Understanding the birthday adjustment pattern:
  ```csharp
  if (DateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;
  ```
  This checks if birthday hasn't occurred yet this year
- **DateTime vs TimeSpan:** Cannot do `DateTime - DateTime = DateTime`
- **Business logic in entities:** Age and minor status are computed properties

**Technical Deep Dive:** Analyzed the birthday logic systematically:
- `DateTime.Today.AddYears(-age)` = "What date was it X years ago?"
- Comparison determines if birthday has passed this year
- Essential for accurate age calculation

### **Task 4: Collections in Entities** ✅
**File:** `Therapist.cs` (Enhanced)
- ✅ Added `List<DayOfWeek> FreeDays` with private setter
- ✅ Method `IsAvailableOn(DayOfWeek day)`
- ✅ Method `AddAvailableDay(DayOfWeek day)` with duplicate prevention
- ✅ Used built-in `System.DayOfWeek` enum

**Key Learning:**
- **Collection Management:** Private setters prevent external list manipulation
- **Enum Usage:** Leveraged built-in enums vs creating custom ones
- **Duplicate Prevention:** Check `Contains()` before adding
- **API Design:** Method names should be intuitive (`IsAvailableOn` vs `CheckFreeDay`)

**Debugging Journey:** Encountered and fixed:
- Custom enum conflicts with built-in enums
- Invalid syntax: `enum DayOfWeek day` → `DayOfWeek day`
- Wrong variable reference: `Add(DayOfWeek)` → `Add(day)`

## 🧠 Key Concepts Mastered

### **Entity vs Value Object Design**
- **Entities:** Have identity, mutable, use classes
  - `Therapist`, `Patient` - represent "things" with identity
- **Value Objects:** No identity, immutable, use records
  - `TimeSlot` - represents a value, not a thing

### **Property Encapsulation Patterns**
```csharp
public Guid Id { get; } = Guid.NewGuid();           // Read-only, auto-generated
public string Name { get; private set; }            // Readable, internally mutable
public DateTime StartTime { get; init; }            // Set once during construction
```

### **Validation Strategies**
1. **Constructor validation:** Ensure objects are born valid
2. **Null checks first:** Prevent NullReferenceException
3. **Business rule validation:** Domain-specific constraints
4. **Meaningful exceptions:** `ArgumentException`, `ArgumentNullException`

### **C# DateTime Mastery**
- `DateTime.Today` vs `DateTime.Now`
- `DateTime - DateTime = TimeSpan`
- `AddYears()` for date arithmetic
- `.Date` property strips time component

## 📊 Progress Against Roadmap

### **Phase 1: C# Basics & Simple Entities** - COMPLETED ✅
- [x] Task 1: Create Your First Entity
- [x] Task 2: Value Objects
- [x] Task 3: Entity with Business Logic
- [x] Task 4: Collections in Entities

### **Phase 2: Your First Aggregate** - NEXT UP 🎯
- [ ] Task 5: Simple Session Entity (MediationSession)
- [ ] Task 6: Add First Business Rule
- [ ] Task 7: Add More State Transitions

## 🔧 Technical Setup Completed

### **Version Control Established**
- ✅ Initialized git repository
- ✅ Created GitHub repository: https://github.com/BennyRayan/WebApplication1
- ✅ Initial commit with all domain entities
- ✅ Public repository for learning progress tracking

### **Project Structure**
```
WebApplication1/
├── CLAUDE.md              # Project instructions
├── Plan.md                # 25-task learning roadmap
├── LEARNING_JOURNAL.md    # This file
├── WebApplication1/
│   ├── Therapist.cs       # Task 1 & 4
│   ├── Patient.cs         # Task 3
│   ├── TimeSlot.cs        # Task 2
│   └── Program.cs         # ASP.NET Core 9.0 setup
```

## 💡 Teaching Methodology Insights

### **Effective Learning Pattern**
1. **Implement first** - Let learner try
2. **Review systematically** - Identify specific issues
3. **Explain problems** - Don't give solutions immediately
4. **Guide debugging** - Teach problem-solving process
5. **Provide context** - Explain "why" behind patterns

### **Code Review Approach**
- Focus on one issue at a time
- Use concrete examples showing failure cases
- Explain business impact of technical decisions
- Encourage learner to fix issues themselves

## 🎯 Next Session Goals

### **Task 5: Simple Session Entity**
- Understand aggregate design patterns
- Implement `MediationSession` with proper ID relationships
- Learn about entity relationships via IDs (not direct references)
- Status enum implementation and business rules

### **Conceptual Focus**
- **Aggregate boundaries:** What belongs in MediationSession?
- **Entity relationships:** Why use IDs instead of object references?
- **Status enums:** Modeling state in domain entities
- **Business rule validation:** When can sessions transition states?

## 🚀 Looking Ahead

**Short-term (Next 2-3 sessions):**
- Complete Phase 2: First Aggregate (Tasks 5-7)
- Begin Phase 3: Introduction to Events (Tasks 8-10)
- Understand state machines and business rules

**Medium-term (Next 5-10 sessions):**
- Master command/event patterns (Phase 4)
- Build in-memory event store (Phase 5)
- Integrate with Marten (Phase 6)

**Long-term (Full Journey):**
- Production-ready event sourcing with projections
- Real-world patterns and conflict resolution
- Complete therapy session management system

## 📚 Resources and References

- **GitHub Repository:** https://github.com/BennyRayan/WebApplication1
- **Learning Roadmap:** `Plan.md` (25 tasks, 8 phases)
- **Project Setup:** ASP.NET Core 9.0 with minimal APIs
- **Next Focus:** Phase 2 - Building your first aggregate

---

*This journal captures our systematic approach to learning event sourcing through practical, incremental tasks. Each task builds foundation knowledge while creating a real therapy session management domain.*