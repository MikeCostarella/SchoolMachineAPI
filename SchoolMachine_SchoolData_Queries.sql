-- Returns the districts with their schools, ordered by district name
SELECT
  district.name AS "DistrictName",
  school.name AS "SchoolName"
FROM 
  schooldata.school
	INNER JOIN schooldata.district_school ON district_school.school_id = school.id
	INNER JOIN schooldata.district ON district_school.district_id = district.id
ORDER BY district.name;

-- List All Districts, Schools, Grade Levels and Students in that order
SELECT
	districts.name AS "District",
	schools.name AS "School",
	schoolstudents.grade_level AS "GradeLevel",
	students.first_name AS "FirstName",
	students.middle_name AS "MiddleName",
	students.last_name AS "LastName"
FROM
  schooldata.student AS students
	RIGHT JOIN schooldata.school_student AS schoolstudents ON schoolstudents.student_id = students.id
	RIGHT JOIN schooldata.school AS schools ON schoolstudents.school_id = schools.id
	RIGHT JOIN schooldata.district_school AS districtschools ON districtschools.school_id = schools.id
	RIGHT JOIN schooldata.district AS districts ON districtschools.district_id = districts.id
ORDER BY "District", "School", "GradeLevel", "LastName", "FirstName", "MiddleName";

-- List each school that has students, from highest to lowest, in terms of number of students.
-- Then alphabetically by name for schools with the same number of students
-- NOTE: to get all schools change the INNER JOIN to a LEFT JOIN
SELECT DISTINCT
	MAX(schooldata.school.name) AS "SchoolName",
	COUNT(school_student.student_id) AS "NumberOfStudents"
FROM schooldata.school
    INNER JOIN schooldata.school_student ON school_student.school_id = school.id
GROUP BY school.id
ORDER BY COUNT(school_student.student_id) DESC, "SchoolName";
