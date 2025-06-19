# Pull Request Template

## 📋 Description
<!-- Provide a brief description of the changes in this PR -->

### What does this PR do?
- [ ] Adds new functionality
- [ ] Fixes a bug
- [ ] Improves performance
- [ ] Refactors existing code
- [ ] Updates documentation
- [ ] Updates dependencies
- [ ] Other (please specify):

### Related Issues
<!-- Link any related issues using #issue_number -->
Fixes #
Closes #
Related to #

---

## 🧮 Mathematical Changes
<!-- If this PR affects mathematical functions or algorithms -->

### New Mathematical Functions
- [ ] Basic math operations
- [ ] Advanced math functions
- [ ] Trigonometric functions
- [ ] Statistical functions
- [ ] Linear algebra operations
- [ ] Numerical methods
- [ ] Other:

### Algorithm Changes
- [ ] Improved accuracy
- [ ] Better performance
- [ ] New implementation approach
- [ ] Bug fix in calculation
- [ ] Enhanced error handling

### Mathematical Accuracy
- [ ] All calculations have been verified manually
- [ ] Edge cases have been considered
- [ ] Numerical stability has been tested
- [ ] Performance impact has been evaluated

---

## ✅ Testing Checklist

### Code Quality
- [ ] All existing tests pass
- [ ] New tests have been added for new functionality
- [ ] Test coverage is maintained or improved
- [ ] Code follows established coding standards
- [ ] No compiler warnings introduced

### Mathematical Validation
- [ ] Mathematical correctness verified with known values
- [ ] Edge cases tested (zero, infinity, NaN, negative values)
- [ ] Precision and accuracy validated
- [ ] Performance benchmarks completed (if applicable)

### Documentation
- [ ] XML documentation added/updated for new public APIs
- [ ] README updated if necessary
- [ ] Examples updated/added if applicable
- [ ] CHANGELOG.md updated

---

## 🔧 Implementation Details

### Breaking Changes
- [ ] This PR introduces breaking changes
- [ ] All breaking changes are documented
- [ ] Migration guide provided (if needed)

### Dependencies
- [ ] No new dependencies added
- [ ] New dependencies are justified and documented
- [ ] All dependencies are compatible with target frameworks

### Performance Impact
- [ ] No performance regression
- [ ] Performance improvements measured and documented
- [ ] Memory usage impact considered

---

## 🧪 Test Results

### Unit Tests
```
Total Tests: ___
Passed: ___
Failed: ___
Skipped: ___
Coverage: ___%
```

### Manual Testing
<!-- Describe any manual testing performed -->
- [ ] Examples project runs successfully
- [ ] Mathematical accuracy verified with external tools
- [ ] Performance tested with large datasets
- [ ] Memory usage tested

### Specific Test Cases
<!-- List any specific scenarios tested -->
- [ ] Boundary conditions (min/max values)
- [ ] Invalid input handling
- [ ] Precision edge cases
- [ ] Large number calculations
- [ ] Zero and negative number handling

---

## 📊 Benchmarks (if applicable)
<!-- Include performance benchmarks for mathematical operations -->

### Before
```
Operation: ____________
Time: ___ ms/op
Memory: ___ MB
```

### After
```
Operation: ____________
Time: ___ ms/op
Memory: ___ MB
Improvement: ___%
```

---

## 💡 Design Decisions

### Why this approach?
<!-- Explain the reasoning behind your implementation choices -->

### Alternatives considered
<!-- List other approaches that were considered and why they were not chosen -->

### Trade-offs
<!-- Describe any trade-offs made (e.g., performance vs. accuracy, simplicity vs. flexibility) -->

---

## 🔍 Review Focus Areas
<!-- Help reviewers focus on the most important aspects -->

Please pay special attention to:
- [ ] Mathematical accuracy of new algorithms
- [ ] Edge case handling
- [ ] Performance implications
- [ ] API design consistency
- [ ] Documentation completeness
- [ ] Test coverage adequacy

---

## 📚 References
<!-- Include links to mathematical references, algorithms, or documentation -->

- Mathematical reference: 
- Algorithm source: 
- Related documentation: 
- External validation: 

---

## ✋ Pre-merge Checklist

### Code Review
- [ ] Code has been reviewed by at least one other developer
- [ ] Mathematical accuracy reviewed by someone with domain expertise
- [ ] All feedback addressed or discussed

### Final Validation
- [ ] All CI/CD checks pass
- [ ] No merge conflicts
- [ ] Branch is up to date with target branch
- [ ] Version number updated (if applicable)

### Deployment Readiness
- [ ] Changes are backward compatible (or breaking changes documented)
- [ ] No sensitive information exposed
- [ ] Ready for production deployment

---

## 🏷️ Labels
<!-- Add appropriate labels to categorize this PR -->

Suggested labels:
- `enhancement` / `bug` / `documentation` / `performance`
- `math-core` / `statistics` / `linear-algebra` / `numerical-methods`
- `breaking-change` / `needs-review` / `ready-to-merge`

---

## 👥 Reviewers
<!-- @mention specific reviewers if needed -->

**Required reviewers:**
- [ ] Code maintainer
- [ ] Mathematical expert (for algorithm changes)
- [ ] Performance expert (for performance-critical changes)

**Optional reviewers:**
- [ ] Documentation reviewer
- [ ] Security reviewer (for input validation changes)

---

*Thank you for contributing to MathLib! 🚀*
