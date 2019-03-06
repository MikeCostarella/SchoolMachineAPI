-- Returns the districts with their schools, ordered by district name
SELECT
  district.name AS DistrictName,
  school.name AS "SchoolName"
FROM 
  ((schooldata.school  
	INNER JOIN schooldata.district_school
		ON district_school.school_id = school.id)		
	INNER JOIN schooldata.district
		ON district_school.district_id = district.id)
ORDER BY district.name;


-- List each school that has students, from highest to lowest, in terms of number of students.
-- Then alphabetically by name for schools with the same number of students
-- NOTE: to get all schools change the INNER JOIN to a LEFT JOIN
SELECT DISTINCT
	MAX(schooldata.school.name) AS SchoolName,
	COUNT(school_student.student_id) AS NumberOfStudents
FROM schooldata.school
    INNER JOIN schooldata.school_student ON school_student.school_id = school.id
GROUP BY school.id
ORDER BY COUNT(school_student.student_id) DESC, SchoolName;