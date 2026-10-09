# Business Rules

Domain: spare parts distribution center.
Warehouse → Zone → Location (code like `A-01-03`: rack-level-position).

1. Every location has a maximum capacity, measured in units.
2. Occupancy states: **Available** (0 units), **Partial** (has units and still fits more), **Full** (units equal capacity).
3. Available, Partial and Full are **calculated** from units and capacity, never stored. **Blocked** is stored, because it is a human decision.
4. A location can be blocked even if it holds parts. While blocked, no units can enter, but units can leave.
5. A location holds **one part type at a time**. (Future improvement: mixed parts with shared capacity.)
6. A movement (move X units of part P from Origin to Destination) is **rejected** when:
   - the quantity is zero or negative,
   - origin and destination are the same location,
   - the quantity exceeds the units in the origin,
   - the destination is blocked,
   - the destination does not have enough free space,
   - the destination already holds a different part type.
7. A location code is unique **within its warehouse**.