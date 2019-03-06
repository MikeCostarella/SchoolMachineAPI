SELECT 
  school_districts.name, 
  school_districts.school_district_id
FROM 
  school_data.school_districts INNER JOIN school_data.school_district_schools ON school_district_schools.school_district_id = school_districts.school_district_id