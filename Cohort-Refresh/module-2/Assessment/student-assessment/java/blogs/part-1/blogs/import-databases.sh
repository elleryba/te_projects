dropdb -U postgres assessment
createdb -U postgres assessment
psql -U postgres -d assessment -f posts.sql
psql -U postgres -d assessment -f comments.sql