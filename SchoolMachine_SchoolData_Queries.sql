-- Returns the districts with their schools, ordered by district name
SELECT
  district.name AS "DistrictName",
  school.name AS "SchoolName"
FROM 
  ((schooldata.school  
	INNER JOIN schooldata.district_school
		ON district_school.school_id = school.id)		
	INNER JOIN schooldata.district
		ON district_school.district_id = district.id)
ORDER BY district.name;